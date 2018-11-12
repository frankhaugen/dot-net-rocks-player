using System;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using ConsoleTables;
using NAudio;
using NAudio.Wave;
using System.Threading;
using System.Collections.Generic;

namespace dot_net_rocks_player_console_core
{
	class Program
	{

		private static readonly string feedURL = "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master";
		private static readonly string feedFileJSON = "dotnetrocks.json";
		private static readonly string feedFileXML = "dotnetrocks.xml";

		private static List<string> mp3Links = new List<string>();

		static void Main(string[] args)
		{
		
			Console.SetBufferSize(16384, 16384);

			Console.WriteLine("Starting...");

			CollectFeed();


			DisplayResult();


			Console.WriteLine("Finished");
			Console.WriteLine("Playing MP3...");

			if (File.Exists("tmp.mp3"))
			{
				File.Delete("tmp.mp3");
			}

			Random random = new Random();
			using (var mf = new MediaFoundationReader(mp3Links[random.Next(0, mp3Links.Count)]))
			using (var wo = new WaveOutEvent())
			{
				wo.Init(mf);
				wo.Play();
				while (wo.PlaybackState == PlaybackState.Playing)
				{
					Thread.Sleep(1000);
				}
			}


			Console.ReadLine();
		}

		private static void DisplayResult()
		{
			Console.WriteLine("Displaying result...");

			if (File.Exists(feedFileJSON))
			{
			Console.WriteLine("Reading JSON from file...");
				RootObject result = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(feedFileJSON));

				var table = new ConsoleTable("Episode #", "Title", "Date");

				foreach (var item in result.Rss.Channel.Item)
				{
					mp3Links.Add(item.Enclosure.Url);
					table.AddRow(item.Link.Split('=')[1], item.Title, DateTime.ParseExact(item.PubDate, "ddd, dd MMM yyyy HH:mm:ss EDT", null).ToString("yyyy-MM-dd"));
				}

				table.Write();
				
			}
			else
			{
				Console.WriteLine(feedFileJSON + " does not exist...");
			}
		}

		private static void WriteFile(string filepath, string data)
		{
			if (File.Exists(filepath))
			{
				File.Delete(filepath);
			}

			File.WriteAllText(filepath, data);
		}

		private static string XML()
		{
			Console.WriteLine("Dowloading XML...");

			WebClient client = new WebClient();
			Stream data = client.OpenRead(feedURL);
			StreamReader reader = new StreamReader(data);
			string feed = reader.ReadToEnd();
			data.Close();

			Console.WriteLine("Download finished...");
			return feed;
		}

		private static string JSON()
		{
			Console.WriteLine("Converting to JSON...");

			XmlDocument xmlDocument = new XmlDocument();

			string xml = File.ReadAllText(feedFileXML);
			
			xmlDocument.LoadXml(xml);
			

			Console.WriteLine("Conversion finished...");
			return JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.Indented);
		}

		private static void CollectFeed()
		{
			WriteFile(feedFileXML, XML());
			WriteFile(feedFileJSON, JSON());
		}
	}
}
