using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Placeables.Furniture;

namespace EtherealHorizons.Tiles.Furniture
{
	public class BossTrophy : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);

			dustType = 7;
			disableSmartCursor = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Trophy");
			AddMapEntry(new Color(120, 85, 60), name);
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			int item = 0;
			switch (frameX / 54)
            {
				case 0:
					item = ModContent.ItemType<AwakeCheeksTrophy>();
					break;
            }
			if (item > 0)
            {
				Item.NewItem(i * 16, j * 16, 48, 48, item);
            }
        }
    }
}