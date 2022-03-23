using PickupSwapper.Services;
using Rocket.Core.Plugins;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fr34kyn01535.Uconomy;
using Rocket.Core.Logging;
using Rocket.API.Collections;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace PickupSwapper
{
    public class Main : RocketPlugin<PickupSwapperConfiguration>
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("#############################################", ConsoleColor.Yellow);
            Logger.Log("###          PickupSwapper Loaded         ###", ConsoleColor.Yellow);
            Logger.Log("###   Plugin Created By blazethrower320   ###", ConsoleColor.Yellow);
            Logger.Log("###            Join my Discord:           ###", ConsoleColor.Yellow);
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###", ConsoleColor.Yellow);
            Logger.Log("#############################################", ConsoleColor.Yellow);
            UnturnedPlayerEvents.OnPlayerInventoryAdded += OnPlayerInventoryAdded;
        }


        protected override void Unload()
        {
            Logger.Log("PickupSwapper Unloaded");
            UnturnedPlayerEvents.OnPlayerInventoryAdded -= OnPlayerInventoryAdded;
        }
        private void OnPlayerInventoryAdded(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex, ItemJar P)
        {
            PickupNote Pickup = this.Configuration.Instance.PickupNotes.FirstOrDefault<PickupNote>((Func<PickupNote, bool>)(x => (int)x.id == (int)P.item.id));
            if(Pickup == null)
            {
                return;
            }
            player.Inventory.removeItem((byte)inventoryGroup, inventoryIndex);
            if(Main.Instance.Configuration.Instance.useUconomy == true && Main.Instance.Configuration.Instance.useExperience == false)
            {
                Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.ToString(), Pickup.IncreaseAmount);
            }
            else if(Main.Instance.Configuration.Instance.useExperience == true && Main.Instance.Configuration.Instance.useUconomy == false)
            {
                player.Experience = player.Experience + Pickup.IncreaseAmount;
            }
            ChatManager.say(player.CSteamID, Main.Instance.Translate("PickupSwapped", Pickup.IncreaseAmount.ToString()), Color.red, true);
        }
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"PickupSwapped", "<color=#FF0000>[Swapper] </color><color=#4CDB3D>${0}</color> <color=#F3F3F3>was added to your balance!</color>"},
        };
    }
}
