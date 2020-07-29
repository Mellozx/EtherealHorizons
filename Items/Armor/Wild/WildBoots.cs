using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Legs)]
	public class WildBoots : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Ancient spirits are said to protect the wearer of this armor");
		}

		public override void SetDefaults() 
		{
			item.width = 22;
			item.height = 16;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = 2;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) 
		{
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}