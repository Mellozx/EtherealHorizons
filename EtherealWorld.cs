using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using EtherealHorizons.Tiles.Flowers;

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

        /* public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int sunflowersIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Sunflowers"));
            if (sunflowersIndex != 1)
            {
                tasks.Insert(sunflowersIndex, new PassLegacy("Scattered Flowers", ScatteredFlowers));
            }
        }

        private void ScatteredFlowers(GenerationProgress progress)
        {
            progress.Message = "Generating Scattered Flowers";
        } */
    }
}