using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using NAudio;
using NAudio.Wave;
using System.Threading;
using Dot_Net_Rocks_Player_WPF.Classes;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Dot_Net_Rocks_Player_WPF
{

	
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<Item> FeedItems = new List<Item>();
		public ObservableCollection<Episode> episodes = new ObservableCollection<Episode>();


		public RootObject feed;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = episodes;
			//
			Episodes.ItemsSource = episodes;

			Episodes.DataContext = episodes;

			feed = Collector.Collect();

			FeedItems = feed.Rss.Channel.Item;

			foreach (Item item in FeedItems)
			{
				episodes.Add(new Episode() {
					Number = Convert.ToInt32(item.Link.Split('=')[1]),
					Title = item.Title,
					Link = new Uri(item.Enclosure.Url),
					Progress = 0,
					Date = DateTime.ParseExact(item.PubDate, "ddd, dd MMM yyyy HH:mm:ss EDT", null).ToString("yyyy-MM-dd"),
					Completed = false,
					Description = item.Description
				});
			}
			episodes.Reverse();
			
			
		}

		private void SaveFile()
		{
			File.WriteAllText("data.json", JsonConvert.SerializeObject(episodes));
		}

		private void Play(string input, ProgressBar progressBar)
		{
			using (var mf = new MediaFoundationReader(input))
			using (var wo = new WaveOutEvent())
			{
				wo.Init(mf);

				wo.Play();
				while (wo.PlaybackState == PlaybackState.Playing)
				{
					progressBar.Value = ((mf.CurrentTime.Seconds / mf.TotalTime.Seconds) * 100);
						Thread.Sleep(1000);
				}
			}
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			Button btn = sender as Button;
			StackPanel stack = btn.Content as StackPanel;
			Label label = stack.Children[1] as Label;

			SaveFile();

			string str = new string(label.Content.ToString().ToCharArray());
			//await Task.Run(() => Play(str, SongProgress));
			//await Task.Factory.StartNew(() => Play(str, SongProgress));

			var progress = new Progress<int>(value => { SongProgress.Value = value; });
			await Task.Run(() => GenerateAsync(progress, str));
		}

		

		void GenerateAsync(IProgress<int> progress, string input)
		{
			using (var mf = new MediaFoundationReader(input))
			using (var wo = new WaveOutEvent())
			{
				wo.Init(mf);

				wo.Play();
				while (wo.PlaybackState == PlaybackState.Playing)
				{
					var var1 = mf.CurrentTime.TotalSeconds;
					var var2 = mf.TotalTime.TotalSeconds;
					
					var var3 = var1 / var2;
					var var4 = var3 * 10000;
					int var5 = (int)Math.Round(var4);
					Console.WriteLine("{0} - {1} - {2} - {3} - {4}", var1, var2, var3, var4, var5);
					
					progress?.Report(var5);
					Thread.Sleep(1000);
				}
			};
		}

		private void progressUpdate()
		{
			
		}
	}
}
