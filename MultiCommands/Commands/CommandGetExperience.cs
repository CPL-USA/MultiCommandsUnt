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
    public class CommandGetExperience : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "exp";

        public string Help => string.Empty;

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command) // /exp [nick] [count]
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 2)
            {
                UnturnedPlayer toPlayer = UnturnedPlayer.FromName(command[0]);
                if (toPlayer != null)
                {
                    if (uint.TryParse(command[1], out uint experience))
                    {
                        toPlayer.Experience += experience;
                        ChatManager.serverSendMessage(MultiCommands.Instance.Translate("command_get_experience_to_player", toPlayer.Experience, experience), Color.white, null, player.SteamPlayer(), EChatMode.GLOBAL, null, true);
                        ChatManager.serverSendMessage(MultiCommands.Instance.Translate("command_get_experience_to_player_successfully", player.CharacterName, experience), Color.white, null, toPlayer.SteamPlayer(), EChatMode.GLOBAL, null, true);
                    }
                    else
                    {
                        UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_get_experience_failed"), Color.red);
                        return;
                    }
                }
                else
                {
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_get_experience_to_player_not_found"), Color.red);
                    return;
                }
            }
            else if(command.Length == 1)
            {
                if (uint.TryParse(command[0], out uint experience))
                {
                    player.Experience += experience;
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_get_experience_successfully"), Color.white);
                }
                else
                {
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_get_experience_failed"), Color.red);
                    return;
                }
            }
            else
            {
                ChatManager.serverSendMessage(MultiCommands.Instance.Translate("command_get_experience_help"), Color.red, null, player.SteamPlayer(), EChatMode.GLOBAL, null, true);
            }
            
        }
    }
}
//if (command.Length == 0)
//{
//    UnturnedChat.Say(player, MultiCommands.Instance.Translate("experience_error"), Color.red);
//    return;
//}

//uint.TryParse(command[0], out uint result);
//if (command.Length == 1)
//{
//    player.Experience += result;
//    UnturnedChat.Say(player, MultiCommands.Instance.Translate("experience_successfully"), Color.green);

//}
//else if (command.Length == 2)
//{
//    UnturnedPlayer toPlayer = UnturnedPlayer.FromName(command[1]);
//    if (toPlayer == null)
//    {
//        UnturnedChat.Say(player, MultiCommands.Instance.Translate("exp_player_not_found", command[1]), Color.red);
//        return;
//    }

//    toPlayer.Experience += result;

//    UnturnedChat.Say(toPlayer, MultiCommands.Instance.Translate("exp_toplayer", player.CharacterName, result));
//    UnturnedChat.Say(player, MultiCommands.Instance.Translate("exp_give_player", result, toPlayer.CharacterName));
//}