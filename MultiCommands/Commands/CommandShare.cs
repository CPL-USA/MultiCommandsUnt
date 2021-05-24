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
    public class CommandShare : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "share";

        public string Help => string.Empty;

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>() { "sh" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command) // /share [nick] [count]
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 2)
            {
                UnturnedPlayer toPlayer = UnturnedPlayer.FromName(command[0]);
                if (toPlayer != null)
                {
                    if (uint.TryParse(command[1], out uint experience))
                    {
                        player.Experience -= experience;
                        ChatManager.serverSendMessage(MultiCommands.Instance.Translate("command_share_successfully", experience, toPlayer.CharacterName), Color.white, null, player.SteamPlayer(), EChatMode.GLOBAL, null, true);
                        toPlayer.Experience += experience;
                        ChatManager.serverSendMessage(MultiCommands.Instance.Translate("command_share_to_player_successfully", toPlayer.CharacterName, experience), Color.white, null, toPlayer.SteamPlayer(), EChatMode.GLOBAL, null, true);
                    }
                    else
                    {
                        UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_failed"), Color.red);
                        return;
                    }
                }
                else
                {
                    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_get_experience_to_player_not_found"), Color.red);
                    return;
                }
            }
            else
            {
                UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_help"), Color.red);
            }

           

        }

    }
}

//if (command.Length <= 1)
//{
//    UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_not_found_player"), Color.red);
//}
//else
//{
//    uint.TryParse(command[0], out uint result);
//    UnturnedPlayer player2 = UnturnedPlayer.FromName(command[1]);
//    if (player2 == null)
//    {
//        UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_player2_not_found", command[1]), Color.magenta);
//        return;
//    }
//    if (player.Experience < result)
//    {
//        UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_insufficient_experience"), Color.red);
//    }
//    else
//    {
//        player.Experience -= result;
//        UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_share_experience", result, player2.CharacterName), Color.green);
//        player2.Experience += result;
//        UnturnedChat.Say(player2, MultiCommands.Instance.Translate("command_share_get_experience", result, player.CharacterName), Color.green);
//    }

//}