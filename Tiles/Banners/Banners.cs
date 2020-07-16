using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Placeables.Banners;
using EtherealHorizons.NPCs.Enemies.Forest;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons.Tiles.Banners
{
	public class SmallTreeEntBannerTile : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);
			dustType = -1;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			int style = frameX / 18;
			int item;
			switch (style)
            {
				case 0:
					item = ModContent.ItemType<SmallTreeEntBanner>();
					break;
				default:
					return;
            }
			Item.NewItem(i * 16, j * 16, 16, 48, item);
		}

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].frameX / 18;
				int type;
				switch (style)
				{
					case 0:
						type = ModContent.NPCType<SmallTreeEnt>();
						break;
					default:
						return;
				}
				player.NPCBannerBuff[type] = true;
				player.hasBanner = true;
			}
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
    }
}