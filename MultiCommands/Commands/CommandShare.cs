using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MultiCommands.Commands
{
    public class CommandShare : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "share";

        public string Help => string.Empty;

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>() { "sh" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length <= 1)
            {
                UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_not_found_player"), Color.red);
            }
            else
            {
                uint.TryParse(command[0], out uint result);
                UnturnedPlayer player2 = UnturnedPlayer.FromName(command[1]);
                if (player2 == null)
                {
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_player2_not_found", command[1]), Color.magenta);
                    return;
                }
                if (player.Experience < result)
                {
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_insufficient_experience"), Color.red);
                }
                else
                {
                    player.Experience -= result;
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_experience", result, player2.CharacterName), Color.green);
                    player2.Experience += result;
                    UnturnedChat.Say(player2, MultiCommands.Instance.Translate("command_share_get_experience", result, player.CharacterName), Color.green);
                }

            }

        }

    }
}
