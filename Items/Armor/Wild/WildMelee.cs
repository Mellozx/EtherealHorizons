using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Head)]
	public class WildMelee : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 22;
			item.value = 0;
			item.rare = 2;
			item.defense = 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<WildGarb>() && legs.type == ItemType<WildBoots>();
		}
		
		public override void UpdateEquip(Player player) 
		{
		}

		//set bonus
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