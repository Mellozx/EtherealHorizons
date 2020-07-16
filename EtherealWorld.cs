using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Terraria.ModLoader.IO;

namespace EtherealHorizons
{
	public class EtherealWorld : ModWorld
    {
        // Bosses
        public static bool downedAwakeCheeks;

        public override void Initialize()
        {
            downedAwakeCheeks = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();

            if (downedAwakeCheeks)
            {
                downed.Add("AwakeCheeks");
            }

            return new TagCompound
            {
                ["downed"] = downed
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            downedAwakeCheeks = downed.Contains("AwakeCheeks");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();

            flags[0] = downedAwakeCheeks;
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();

            downedAwakeCheeks = flags[0];
        }
    }
}