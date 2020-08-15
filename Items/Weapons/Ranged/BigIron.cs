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

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedY, speedX)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 2);
		}
	}
}
