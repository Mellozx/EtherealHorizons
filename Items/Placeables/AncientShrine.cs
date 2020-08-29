using Terraria.ModLoader;
using Terraria.ID;
using EtherealHorizons.Tiles;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Placeables
{
	public class AncientShrine : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Shrine");
		}

		public override void SetDefaults()
		{
			item.useTurn = true;
			item.autoReuse = true;
			item.consumable = true;
			item.width = 44;
			item.height = 30;
			item.maxStack = 999;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.createTile = ModContent.TileType<AncientShrineTile>();
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.StoneBlock, 18);
			recipe.AddIngredient(ItemID.Acorn, 6);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 8);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}