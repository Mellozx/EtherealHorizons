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
            // TODO - Drop nuts just like accorns
            return true;
        }
    }
}