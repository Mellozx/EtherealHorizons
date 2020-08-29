using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using EtherealHorizons.Items.Placeables;
using EtherealHorizons.Items.BossSummons;
using EtherealHorizons.NPCs.Bosses.AwakeCheeks;

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
			TileObjectData.newTile.Height = 3; 
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16 };
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
            Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<AncientShrine>());
        }

        public override bool NewRightClick(int i, int j)
        {
			var player = Main.LocalPlayer;
			if (player.HeldItem.type ==	ModContent.ItemType<SquirrelIdol>())
            {
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<AwakeCheeks>());
				Main.PlaySound(SoundID.Roar, player.position, 0);
				return true;
            }
			return false;
        }

        public override void MouseOver(int i, int j)
        {
			var player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = ModContent.ItemType<SquirrelIdol>();
        }
    }
}