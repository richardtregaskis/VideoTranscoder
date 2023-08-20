using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VideoTranscoderCore
{
	internal static class VarCore
	{
		public static string ApplicationBinDirectory = Environment.CurrentDirectory;
		public static string SourceFolder = "";
		public static string TargetFolder = "";		
		public static string WatchDirectory = "";
	}
}
