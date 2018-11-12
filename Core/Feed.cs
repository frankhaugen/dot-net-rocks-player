using Newtonsoft.Json;
using System.Collections.Generic;

namespace dot_net_rocks_player_console_core
{
	public class RootObject
	{
		[JsonProperty("?xml")]
		public Xml Xml { get; set; }
		[JsonProperty("rss")]
		public Rss Rss { get; set; }
	}
	public class Xml
	{
		[JsonProperty("@version")]
		public string Version { get; set; }
		[JsonProperty("@encoding")]
		public string Encoding { get; set; }
	}
	public class Rss
	{
		[JsonProperty("@xmlns:itunes")]
		public string Xmlnsitunes { get; set; }
		[JsonProperty("@xmlns:atom")]
		public string Xmlnsatom { get; set; }
		[JsonProperty("@version")]
		public string Version { get; set; }
		[JsonProperty("channel")]
		public Channel Channel { get; set; }
	}
	public class Channel
	{
		[JsonProperty("ttl")]
		public string Ttl { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("language")]
		public string Language { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("copyright")]
		public string Copyright { get; set; }
		[JsonProperty("managingEditor")]
		public string ManagingEditor { get; set; }
		[JsonProperty("webMaster")]
		public string WebMaster { get; set; }
		[JsonProperty("rating")]
		public string Rating { get; set; }
		[JsonProperty("pubDate")]
		public string PubDate { get; set; }
		[JsonProperty("lastBuildDate")]
		public string LastBuildDate { get; set; }
		[JsonProperty("cloud")]
		public Cloud Cloud { get; set; }
		[JsonProperty("atom:link")]
		public Atomlink Atomlink { get; set; }
		[JsonProperty("image")]
		public Image Image { get; set; }
		[JsonProperty("category")]
		public List<string> Category { get; set; }
		[JsonProperty("itunes:subtitle")]
		public string Itunessubtitle { get; set; }
		[JsonProperty("itunes:explicit")]
		public string Itunesexplicit { get; set; }
		[JsonProperty("itunes:author")]
		public string Itunesauthor { get; set; }
		[JsonProperty("itunes:summary")]
		public string Itunessummary { get; set; }
		[JsonProperty("itunes:owner")]
		public Itunesowner Itunesowner { get; set; }
		[JsonProperty("itunes:image")]
		public Itunesimage Itunesimage { get; set; }
		[JsonProperty("itunes:category")]
		public List<Itunescategory> Itunescategory { get; set; }
		[JsonProperty("item")]
		public List<Item> Item { get; set; }
	}
	public class Cloud
	{
		[JsonProperty("@domain")]
		public string Domain { get; set; }
		[JsonProperty("@port")]
		public string Port { get; set; }
		[JsonProperty("@path")]
		public string Path { get; set; }
		[JsonProperty("@registerProcedure")]
		public string RegisterProcedure { get; set; }
		[JsonProperty("@protocol")]
		public string Protocol { get; set; }
	}
	public class Atomlink
	{
		[JsonProperty("@href")]
		public string Href { get; set; }
		[JsonProperty("@rel")]
		public string Rel { get; set; }
		[JsonProperty("@type")]
		public string Type { get; set; }
	}
	public class Image
	{
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("width")]
		public string Width { get; set; }
		[JsonProperty("height")]
		public string Height { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
	}
	public class Itunesowner
	{
		[JsonProperty("itunes:name")]
		public string Itunesname { get; set; }
		[JsonProperty("itunes:email")]
		public string Itunesemail { get; set; }
	}
	public class Itunesimage
	{
		[JsonProperty("@href")]
		public string Href { get; set; }
	}
	public class Itunescategory
	{
		[JsonProperty("@text")]
		public string Text { get; set; }
		[JsonProperty("itunes:category")]
		public Itunescategory itunescategory { get; set; }
	}
	public class Item
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("pubDate")]
		public string PubDate { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("source")]
		public Source Source { get; set; }
		[JsonProperty("guid")]
		public Guid Guid { get; set; }
		[JsonProperty("itunes:author")]
		public string Itunesauthor { get; set; }
		[JsonProperty("itunes:subtitle")]
		public string Itunessubtitle { get; set; }
		[JsonProperty("itunes:summary")]
		public string Itunessummary { get; set; }
		[JsonProperty("enclosure")]
		public Enclosure Enclosure { get; set; }
		[JsonProperty("itunes:duration")]
		public string Itunesduration { get; set; }
		[JsonProperty("itunes:keywords")]
		public string Ituneskeywords { get; set; }
	}
	public class Source
	{
		[JsonProperty("@url")]
		public string Url { get; set; }
		[JsonProperty("#text")]
		public string Text { get; set; }
	}
	public class Guid
	{
		[JsonProperty("@isPermaLink")]
		public string IsPermaLink { get; set; }
		[JsonProperty("#text")]
		public string Text { get; set; }
	}
	public class Enclosure
	{
		[JsonProperty("@url")]
		public string Url { get; set; }
		[JsonProperty("@length")]
		public string Length { get; set; }
		[JsonProperty("@type")]
		public string Type { get; set; }
	}

}
