using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;

namespace EtherealHorizons.Tiles 
{
	public class AncientShrineTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.Width = 5;
			TileObjectData.newTile.Height = 3; // because the template is for 1x2 not 1x3
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16 }; // because height changed
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(Type);
			minPick = 55;
			dustType = 22;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Ancient Shrine");
			AddMapEntry(new Color(73, 63, 51), name);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("AncientShrineItem"));
        }
	}
}