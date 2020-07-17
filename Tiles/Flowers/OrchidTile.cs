using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Tiles.Flowers
{
	public class OrchidTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileWaterDeath[Type] = false;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileFrameImportant[Type] = true;
            disableSmartCursor = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinatePadding = 2;
            // TileObjectData.newTile.Width = 2;
            // TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);

            dustType = DustID.Grass;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}