using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ExhaustiBot
{
	class Config
	{
		private const string configDir = "resources";
		private const string configFile = "config.json";
		public static BotConfig exhaustiBot;

		static Config()
		{
			if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir); //If configuration directory does not exist, create.
			if (!File.Exists(configDir + "/" + configFile))
			{
				exhaustiBot = new BotConfig();
				string json = JsonConvert.SerializeObject(exhaustiBot, Formatting.Indented);
				File.WriteAllText(configDir + "/" + configFile, json);
			}
			else
			{
				string json = File.ReadAllText(configDir + "/" + configFile);
				exhaustiBot = JsonConvert.DeserializeObject<BotConfig>(json);
			}
		}
	}

	public struct BotConfig
	{
		public string token;
		public string cmdPrefix;
	}

}
