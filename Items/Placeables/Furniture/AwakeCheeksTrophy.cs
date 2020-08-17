using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Tiles.Furniture;

namespace EtherealHorizons.Items.Placeables.Furniture
{
	public class AwakeCheeksTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks Trophy");
        }

        public override void SetDefaults()
        {
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Blue;
			item.createTile = ModContent.TileType<BossTrophy>();
			item.placeStyle = 0;
		}
    }
}