using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace ExhaustiBot.modules
{
	public class Misc : ModuleBase<SocketCommandContext>
	{
		[Command("hjelp")]
		public async Task Help()
		{
			var embed = new EmbedBuilder();
			embed.WithTitle("Kommandoer:");
			embed.WithDescription("!repeter: !repeter din melding\n" +
				"!velg: !velg utfall1|utfall2|utfall3 osv...");
			embed.WithColor(new Color(0, 255, 0));
			await Context.Channel.SendMessageAsync("", false, embed);
		}

		[Command("repeter")]
		public async Task Echo([Remainder] string message)
		{
			var embed = new EmbedBuilder();
			embed.WithTitle("Repetert melding:");
			embed.WithDescription(message);
			embed.WithColor(new Color(0, 255, 0));
			await Context.Channel.SendMessageAsync("", false, embed);
		}

		[Command("velg")]
		public async Task Pick([Remainder] string message)
		{
			string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

			Random r = new Random();
			string picked = options[r.Next(0, options.Length)];

			var embed = new EmbedBuilder();
			embed.WithTitle(Context.User.Username + ", jeg velger: ");
			embed.WithDescription(picked);
			embed.WithColor(new Color(255, 255, 0));
			embed.WithThumbnailUrl("https://pbs.twimg.com/media/DAAB6X4UQAEAbqM.png");

			var embError = new EmbedBuilder();
			embError.WithTitle("Jeg beklager, " + Context.User.Username);
			embError.WithDescription("!velg krever minst to forskjellige utfall.\n" + "!velg utfall1|utfall2");
			embError.WithColor(new Color(255, 0, 0));
			embError.WithThumbnailUrl("https://cdn.frankerfacez.com/emoticon/119072/4");

			if (options.Length > 1)
			{
				await Context.Channel.SendMessageAsync("", false, embed);
			}
			else
			{
				await Context.Channel.SendMessageAsync("", false, embError);
			}

		}
	}
}
