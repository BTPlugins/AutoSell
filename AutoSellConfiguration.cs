using AutoSell.Services;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoSell
{
    public class AutoSellConfiguration : IRocketPluginConfiguration
    {
        public bool useUconomy { get; set; }
        public bool useExperience { get; set; }
        [XmlArrayItem(ElementName = "Sell")]
        public List<PickupNote> AutoSell { get; set; }
        public void LoadDefaults()
        {
            useUconomy = true;
            useExperience = false;
            AutoSell = new List<PickupNote>()
            {
                new PickupNote()
                {
                    id = (ushort)1051,
                    IncreaseAmount = (uint)5,
                    Permission = "NoteTransfer.PermissionAccess"
                },
                new PickupNote()
                {
                    id = (ushort)1052,
                    IncreaseAmount = (uint)10,
                    Permission = "NoteTransfer.PermissionAccess"
                },
                new PickupNote()
                {
                    id = (ushort)1053,
                    IncreaseAmount = (uint)20,
                    Permission = "NoteTransfer.PermissionAccess"
                },
                new PickupNote()
                {
                    id = (ushort)1054,
                    IncreaseAmount = (uint)50,
                    Permission = "NoteTransfer.PermissionAccess"
                },
                new PickupNote()
                {
                    id = (ushort)1055,
                    IncreaseAmount = (uint)100,
                    Permission = "NoteTransfer.PermissionAccess"
                }
            };
        }
    }
}
