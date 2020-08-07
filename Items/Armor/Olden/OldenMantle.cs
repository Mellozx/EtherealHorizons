using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Body)]
	public class OldenMantle : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
			item.width = 34;
			item.height = 18;
			item.value = 0;
			item.rare = 2;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player) 
		{
		}

		/*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EquipMaterial>(), 60);
			recipe.AddTile(TileType<ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
		
		public override void DrawHands(ref bool drawHands, ref bool drawArms) 
		{
			drawHands = true;
		}
	}
}