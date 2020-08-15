using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class Complexion : ModItem 
	{ 
		public override void SetStaticDefaults() 
		{ 
            Tooltip.SetDefault("Has a chance to shoot nuts");
		}

        public override void SetDefaults()
        {
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 24;
			item.UseSound = SoundID.Item5;
			item.damage = 15;
			item.knockBack = 3f;
			item.shootSpeed = 7f;
			item.shoot = 1;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 15);
			item.useAmmo = 40;
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(10))
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<FriendlyNutProj>(), damage, knockBack, player.whoAmI);
			}

			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedY, speedX)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
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