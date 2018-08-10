using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;


namespace ExhaustiBot
{
	class Program
	{
		DiscordSocketClient client;
		CmdHandler handler;

		static void Main(string[] args)
		=> new Program().startAsync().GetAwaiter().GetResult();
		public async Task startAsync()
		{
			if (Config.exhaustiBot.token == "" || Config.exhaustiBot.token == null) return;
			client = new DiscordSocketClient(new DiscordSocketConfig
			{
				LogLevel = LogSeverity.Verbose
			});
			client.Log += Log;
			await client.LoginAsync(TokenType.Bot, Config.exhaustiBot.token);
			await client.StartAsync();
			handler = new CmdHandler();
			await handler.InitializeAsync(client);
			await Task.Delay(-1);
		}

		private async Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.Message);
		}
	}
}
