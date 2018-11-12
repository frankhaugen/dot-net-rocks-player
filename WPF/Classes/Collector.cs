using System;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using NAudio.Wave;
using System.Threading;
using System.Collections.Generic;

namespace Dot_Net_Rocks_Player_WPF.Classes
{
	static class Collector
	{
		public static RootObject Collect(string input = "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master")
		{
			WebClient client = new WebClient();
			Stream data = client.OpenRead(input);
			StreamReader reader = new StreamReader(data);
			string xml = reader.ReadToEnd();
			data.Close();

			XmlDocument xmlDocument = new XmlDocument();

			xmlDocument.LoadXml(xml);
			
			string json = JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.Indented);
			RootObject result = JsonConvert.DeserializeObject<RootObject>(json);
			return result;
		}
	}
}
