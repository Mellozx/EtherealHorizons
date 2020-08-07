using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class TheWallnut : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Wallnut");
		}
		
		public override void SetDefaults()
		{
			item.width = 46;
			item.height = 44;
			item.value = Item.buyPrice(0, 0, 4, 66);
			item.rare = ItemRarityID.Blue;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 20;
			item.knockBack = 6f;
			item.damage = 12;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("TheWallnutProjectile");
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 4;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(ItemID.Wood, 3);
			recipe.AddIngredient(mod.ItemType("Nut"), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
