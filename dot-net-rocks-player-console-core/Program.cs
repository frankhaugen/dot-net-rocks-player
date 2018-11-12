using System;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;

namespace dot_net_rocks_player_console_core
{
	class Program
	{

		private static readonly string feedURL = "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master";
		private static readonly string feedFile = "dotnetrocks.json";

		static void Main(string[] args)
		{
			Console.WriteLine("Starting...");

			WriteFeedFile();
			Console.WriteLine("Finished");

			Console.ReadLine();
		}

		private static void WriteFeedFile()
		{
			if (File.Exists(feedFile))
			{
				File.Delete(feedFile);
			}

			File.WriteAllText(feedFile, JSON());
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
			xmlDocument.LoadXml(XML());

			Console.WriteLine("Conversion finished...");
			return JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.Indented);
		}

		private static void CheckFileExist3()
		{
			
		}
	}
}
