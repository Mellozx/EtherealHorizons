using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Tiles
{
    public class SoilTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileBlockLight[Type] = false;
        }
    }
}