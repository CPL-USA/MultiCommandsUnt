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
    public class CommandDestroyObjects : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "destroy";

        public string Help => string.Empty;

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command) // /destroy [radius]
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 1)
            {
                float.TryParse(command[0], out float result);
                UnturnedChat.Say(player, "Удалено " + MultiCommands.Instance.DestroyBarricadesInRadius(player.Position, result) + " объектов.");
            }
            else
            {
                UnturnedChat.Say(player, "/destroy [radius].", Color.red);
            }

        }
    }
}
