using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons
{
    public class EHGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (type == TileID.Cactus)
                {
                    if (Main.rand.NextBool(5)) // 1 in 5 chance
                    {
                        Item.NewItem(i * 16, j * 16, 32, 32, ModContent.ItemType<Thorn>());
                    }
                }
            }

            return true;
        }
    }
}