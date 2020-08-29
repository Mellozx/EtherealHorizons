using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class WildlifeFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wildlife Fragment");
		}
		
		public override void SetDefaults()
		{
			item.material = true;
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 25);
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Leaf>(), 4);
			recipe.AddIngredient(ModContent.ItemType<Nut>(), 2);
			recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 1);
			recipe.AddTile(TileID.Workbenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
