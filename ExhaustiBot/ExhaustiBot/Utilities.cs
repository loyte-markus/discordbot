using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ExhaustiBot
{
	class Utilities
	{
		private static Dictionary<string, string> alerts;
		static Utilities()
		{
			string json = File.ReadAllText("system/alert.json");
			var data = JsonConvert.DeserializeObject<dynamic>(json);
			alerts = data.ToObject<Dictionary<string, string>>();
		}

		public static string getAlert(string key)
		{
			if (alerts.ContainsKey(key)) return alerts[key];
			return "";
		}

		public static string getFormattedAlert(string key, params object[] param)
		{
			if (alerts.ContainsKey(key))
			{
				return String.Format(alerts[key], param);
			}

			return "";
		}

		public static string getFormattedAlert(string key, object param)
		{
			return getFormattedAlert(key, new object[] { param });
		}
	}
}
