using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Body)]
	public class WildGarb : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 22;
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