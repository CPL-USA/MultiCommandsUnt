using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MultiCommands.Commands
{
    public class CommandMaxSkills : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "maxskills";

        public string Help => string.Empty;

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>() {"ms"};

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command) // /ms
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            player.MaxSkills();

            ChatManager.serverSendMessage(MultiCommands.Instance.Translate("command_max_skills_successfully"), Color.white, null, player.SteamPlayer(), EChatMode.GLOBAL, null, true);

        }
    }
}
