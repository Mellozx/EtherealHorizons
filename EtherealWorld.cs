using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using EtherealHorizons.Tiles;

namespace EtherealHorizons
{
    public class EtherealWorld : ModWorld
    {
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

            return new TagCompound()
            {
                ["downed"] = downed,
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            downedAwakeCheeks = downed.Contains("AwakeCheeks");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var downed = new BitsByte();

            downed[0] = downedAwakeCheeks;

            writer.Write(downed);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte downed = reader.ReadByte();

            downedAwakeCheeks = downed[0];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(ae => ae.Name.Equals("Shinies"));
            if(shiniesIndex != - 1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Dustilite Ore", delegate (GenerationProgress generationProgress)
                {
                    generationProgress.Message = "Generating Dustilite";
                    for(int i = 0;i<(int)(Main.maxTilesX * Main.maxTilesY * 0.005f);i++)
                    {
                        int x = WorldGen.genRand.Next(200,Main.maxTilesX - 200);
                        int y = WorldGen.genRand.Next((int)WorldGen.rockLayerHigh,Main.maxTilesY - 300);
                        Tile tile = Framing.GetTileSafely(x,y);
                        if(tile.type == TileID.Sandstone || tile.type == TileID.Sand)
                        {
                            WorldGen.TileRunner(x,y,4,3,ModContent.TileType<DustiliteOre>());//Replace fossilOre with Dustilite Ore :wegud:
                        }
                    }
                }
                ));
            }
        }
    }
}