using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Head)]
	public class OldenHeadgear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Olden Headgear");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 22;
			item.value = 0;
			item.rare = ItemRarityID.Blue;
			item.defense = 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<OldenMantle>();
		}
		
		public override void UpdateEquip(Player player) 
		{

		}

		public override void UpdateArmorSet(Player player) 
		{

		}

		/*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EquipMaterial>(), 30);
			recipe.AddTile(TileType<ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}