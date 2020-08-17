using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EtherealHorizons.Items.Armor.WildWarrior
{
	[AutoloadEquip(EquipType.Legs)]
	public class WildWarriorGreaves : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Wild Warrior Greaves");
		}

		public override void SetDefaults() 
		{
			item.width = 22;
			item.height = 16;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Blue;
			item.defense = 5;
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}