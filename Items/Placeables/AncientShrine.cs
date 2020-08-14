using Terraria.ModLoader;
using Terraria.ID;
using EtherealHorizons.Tiles;

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
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}