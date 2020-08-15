using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class BigIron : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Iron");
		}
		
		public override void SetDefaults()
		{
			item.damage = 6;
			item.width = 42;
			item.height = 22;
			item.useTime = 25;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.buyPrice(silver: 2);
			item.rare = ItemRarityID.White;
			item.noMelee = true;
            item.knockBack = 5;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 7f;
			item.ranged = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 2);
		}
	}
}
