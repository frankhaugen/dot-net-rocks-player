using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dot_Net_Rocks_Player_WPF.Classes
{
	public class Episode
	{
		public int Number { get; set; }
		public string Date { get; set; }
		public string Title { get; set; }
		public Uri Link { get; set; }
		public int Progress { get; set; }
		public string Description { get; set; }
		public bool Completed { get; set; }
	}
}
