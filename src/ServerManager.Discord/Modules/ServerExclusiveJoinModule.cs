using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using ServerManagerTool.DiscordBot.Delegates;
using ServerManagerTool.DiscordBot.Enums;
using ServerManagerTool.DiscordBot.Interfaces;

namespace ServerManagerTool.DiscordBot.Modules
{
    [Name("Exclusive join")]
    public sealed class ServerExclusiveJoinModule : ModuleBase<SocketCommandContext>
    {
        private const int COMMAND_RESPONSE_DELAY = 500;

        private readonly IServerManagerBot _serverManagerBot;
        private readonly HandleCommandDelegate _handleCommandCallback;


        public ServerExclusiveJoinModule(IServerManagerBot serverManagerBot, HandleCommandDelegate handleCommandCallback)
        {
            _serverManagerBot = serverManagerBot;
            _handleCommandCallback = handleCommandCallback;
        }

        [Command("addId", RunMode = RunMode.Async)]
        [Summary("Adds an Exclusive Join ID")]
        [Remarks("info profileId|alias")]
        [RequireBotPermission(ChannelPermission.ViewChannel | ChannelPermission.SendMessages)]
        public async Task AddIdAsync(string profileIdOrAlias, string arkId)
        {
            try
            {
                var serverId = Context?.Guild?.Id.ToString() ?? string.Empty;
                var channelId = Context?.Channel?.Id.ToString() ?? string.Empty;

                var response = _handleCommandCallback?.Invoke(CommandType.AddId, serverId, channelId, profileIdOrAlias, _serverManagerBot.Token, arkId);
                if (response is null)
                {
                    await ReplyAsync("No servers associated with this channel.");
                }
                else
                {
                    foreach (var output in response)
                    {
                        if (output is null)
                            continue;
                        await ReplyAsync(output.Replace("&", "_"));
                        await Task.Delay(COMMAND_RESPONSE_DELAY);
                    }

                    await ReplyAsync($"'{Context.Message}' command complete.");
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync($"'{Context.Message}' command sent and failed with exception ({ex.Message})");
            }
        }

        [Command("removeId", RunMode = RunMode.Async)]
        [Summary("Removes an Exclusive Join ID")]
        [Remarks("info profileId|alias")]
        [RequireBotPermission(ChannelPermission.ViewChannel | ChannelPermission.SendMessages)]
        public async Task RemoveIdAsync(string profileIdOrAlias, string arkId)
        {
            try
            {
                var serverId = Context?.Guild?.Id.ToString() ?? string.Empty;
                var channelId = Context?.Channel?.Id.ToString() ?? string.Empty;

                var response = _handleCommandCallback?.Invoke(CommandType.RemoveId, serverId, channelId, profileIdOrAlias, _serverManagerBot.Token, arkId);
                if (response is null)
                {
                    await ReplyAsync("No servers associated with this channel.");
                }
                else
                {
                    foreach (var output in response)
                    {
                        if (output is null)
                            continue;
                        await ReplyAsync(output.Replace("&", "_"));
                        await Task.Delay(COMMAND_RESPONSE_DELAY);
                    }

                    await ReplyAsync($"'{Context.Message}' command complete.");
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync($"'{Context.Message}' command sent and failed with exception ({ex.Message})");
            }
        }

        [Command("checkId", RunMode = RunMode.Async)]
        [Summary("Checks ID in Excusive Join list")]
        [Remarks("info profileId|alias")]
        [RequireBotPermission(ChannelPermission.ViewChannel | ChannelPermission.SendMessages)]
        public async Task CheckIdAsync(string profileIdOrAlias, string arkId)
        {
            try
            {
                var serverId = Context?.Guild?.Id.ToString() ?? string.Empty;
                var channelId = Context?.Channel?.Id.ToString() ?? string.Empty;

                var response = _handleCommandCallback?.Invoke(CommandType.CheckId, serverId, channelId, profileIdOrAlias, _serverManagerBot.Token, arkId);
                if (response is null)
                {
                    await ReplyAsync("No servers associated with this channel.");
                }
                else
                {
                    foreach (var output in response)
                    {
                        if (output is null)
                            continue;
                        await ReplyAsync(output.Replace("&", "_"));
                        await Task.Delay(COMMAND_RESPONSE_DELAY);
                    }

                    await ReplyAsync($"'{Context.Message}' command complete.");
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync($"'{Context.Message}' command sent and failed with exception ({ex.Message})");
            }
        }
    }
}
