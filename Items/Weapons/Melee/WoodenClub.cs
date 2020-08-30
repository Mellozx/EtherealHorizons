using Terraria;
using Terraria.ID;	
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class WoodenClub : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Club");
			Tooltip.SetDefault("Ooga Booga");
		}
		
		public override void SetDefaults()
		{
			item.melee = true;
			item.autoReuse = true;
			item.useTurn = false;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 24;
			item.damage = 5;
			item.knockBack = 3f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(copper: 50);
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}