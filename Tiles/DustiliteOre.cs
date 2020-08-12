using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace EtherealHorizons.Tiles
{
	public class DustiliteOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			drop = mod.ItemType("DustiliteShard");
			AddMapEntry(new Color(172, 113, 96));
			// Set other values here
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			dustType = 84;
			minPick = 55;
			soundType = SoundID.Tink;
			soundStyle = 1;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dustilite Ore");
		}
	}
}