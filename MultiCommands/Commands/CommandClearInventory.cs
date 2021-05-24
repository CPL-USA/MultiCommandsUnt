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
    public class CommandClearInventory : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "clearinventory";

        public string Help => string.Empty;

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>() {"ci"};

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            player.Player.equipment.dequip();

            for (byte page = 0; page < PlayerInventory.PAGES-2; page++)
            {
                byte itemCount = (byte)player.Player.inventory.items[page].items.Count;
                for (byte i = 0; i < itemCount; i++)
                {
                    player.Player.inventory.removeItem(page, 0);
                }
            }

            player.Player.channel.send("tellSlot", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[] { 0, 0, new byte[0] });
            player.Player.channel.send("tellSlot", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[] { 1, 0, new byte[0] });

            try
            {
                player.Player.clothing.askWearBackpack(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);

                player.Player.clothing.askWearGlasses(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);

                player.Player.clothing.askWearHat(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);

                player.Player.clothing.askWearMask(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);

                player.Player.clothing.askWearPants(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);

                player.Player.clothing.askWearShirt(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);

                player.Player.clothing.askWearVest(0, 0, new byte[0], true);
                removeCloth(player.Player.inventory);
            }
            catch (Exception x)
            {
                Console.WriteLine("Error:" + x.ToString());
            }
            UnturnedChat.Say(player, MultiCommands.Instance.Translate("command_clear_inventory_successfully"), Color.green);
        }

        private void removeCloth(PlayerInventory inventory)
        {
            for (byte b = 0; b < inventory.getItemCount(2); b++)
            {
                inventory.removeItem(2, 0);
            }
        }
    }
}
