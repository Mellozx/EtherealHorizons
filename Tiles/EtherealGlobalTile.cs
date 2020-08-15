using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Tiles
{
	public class EtherealGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (type == TileID.Cactus)
            {
                if (Main.rand.NextBool(2))
                {
                    Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Thorn>(), Main.rand.Next(1, 3));
                }
            }
            return true;
        }
    }
}