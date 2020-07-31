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
			DisplayName.SetDefault("Wild Warrior Greaves");
			Tooltip.SetDefault("Increases movement speed by 10%");
		}

		public override void SetDefaults() 
		{
			item.width = 22;
			item.height = 16;
			item.value = Item.sellPrice(silver: 40);
			item.rare = 1;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) 
		{
            player.moveSpeed += 0.1f;
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}