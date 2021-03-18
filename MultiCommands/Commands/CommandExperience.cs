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
    public class CommandExperience : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "Exp";

        public string Help => "Give Experience";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { "xp" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                UnturnedChat.Say(player, MultiCommands.Instance.Translate("experience_error"), Color.red);
                return;
            }

            uint.TryParse(command[0], out uint result);
            if (command.Length == 1)
            {
                player.Experience += result;
                UnturnedChat.Say(player, MultiCommands.Instance.Translate("experience_successfully"), Color.green);

            }
            else if (command.Length == 2)
            {
                UnturnedPlayer toPlayer = UnturnedPlayer.FromName(command[1]);
                if (toPlayer == null)
                {
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("exp_player_not_found", command[1]), Color.red);
                    return;
                }

                toPlayer.Experience += result;

                UnturnedChat.Say(toPlayer, MultiCommands.Instance.Translate("exp_toplayer", player.CharacterName, result));
                UnturnedChat.Say(player, MultiCommands.Instance.Translate("exp_give_player", result, toPlayer.CharacterName));
            }
        }
    }
}
