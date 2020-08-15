using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Melee;
using System.Collections.Generic;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class ErgBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Erg's Blade");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.useTurn = false;
			item.width = 48;
			item.height = 52;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4f;
			item.value = Item.buyPrice(0, 0, 20, 12);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<DustiliteShardProj>();
			item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(5)) // A 1 in 5 chance
			{
				int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.

					// If you want to randomize the speed to stagger the projectiles
					float scale = 1f - (Main.rand.NextFloat() * 0.3f);
					perturbedSpeed = perturbedSpeed * scale; 
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage / 2, knockBack, player.whoAmI);
				}
			}
			return false;
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DustiliteShard>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}