using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PickupSwapper.Services
{
    public class PickupNote
    {
        [XmlText]
        public ushort id { get; set; }
        [XmlAttribute]
        public uint IncreaseAmount { get; set; }
        [XmlAttribute]
        public string Permission { get; set; }
    }
}
