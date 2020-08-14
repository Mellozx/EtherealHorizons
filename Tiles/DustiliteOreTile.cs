using EtherealHorizons.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Tiles
{
	public class DustiliteOreTile : ModTile
	{
		public override void SetDefaults()
		{
            TileID.Sets.Ore[Type] = true;
            Main.tileValue[Type] = 280;
			Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[Type][TileID.Stone] = true;

            drop = ModContent.ItemType<DustiliteShard>();
            minPick = 55;
            mineResist = 2f;
            soundType = SoundID.Tink;
            soundStyle = 1;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Dustilite Ore");
            AddMapEntry(Color.Yellow, name);
		}

        public override bool CanExplode(int i, int j)
        {
            return NPC.downedSlimeKing;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.2f;
            b = 0.2f;
        }
    }
}