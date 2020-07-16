using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Tiles
{
	public class EtherealGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            // This shit is fucking OP since its counting EACH tree tile, not a single tree
            /* if (type == TileID.Trees)
            {
                if (Main.rand.NextBool(3))
                {
                    Item.NewItem(new Vector2(i * 16, j * 16), ModContent.ItemType<Nut>());
                }
            } */
            return true; 
        }
    }
}