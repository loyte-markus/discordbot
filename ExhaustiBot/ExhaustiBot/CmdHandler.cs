using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExhaustiBot
{
	class CmdHandler
	{
		DiscordSocketClient client;
		CommandService service;

		public async Task InitializeAsync(DiscordSocketClient client)
		{
			this.client = client;
			service = new CommandService();
			await service.AddModulesAsync(Assembly.GetEntryAssembly());
			this.client.MessageReceived += HandleCmdAsync;
		}

		private async Task HandleCmdAsync(SocketMessage arg)
		{
			var msg = arg as SocketUserMessage;
			if (msg == null) return;
			var context = new SocketCommandContext(client, msg);
			int argPos = 0;
			if(msg.HasStringPrefix(Config.exhaustiBot.cmdPrefix, ref argPos) || msg.HasMentionPrefix(client.CurrentUser, ref argPos))
			{
				var result = await service.ExecuteAsync(context, argPos);
				if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
				{
					Console.WriteLine(result.ErrorReason);
				}
			}
		}
	}
}
