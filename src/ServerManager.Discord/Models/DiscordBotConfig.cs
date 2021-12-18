﻿using ServerManagerTool.DiscordBot.Enums;
using System.Collections.Generic;

namespace ServerManagerTool.DiscordBot.Models
{
    public class DiscordBotConfig
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Info;

        public string DiscordToken { get; set; } = string.Empty;

        public string CommandPrefix { get; set; } = string.Empty;

        public string DataDirectory { get; set; } = string.Empty;

        public bool AllowAllBots { get; set; } = false;

        public IEnumerable<string> DiscordBotWhitelists { get; set; } = new List<string>();
    }
}