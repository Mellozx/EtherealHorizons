using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles.Magic;

namespace EtherealHorizons.Items.Weapons.Magic
{
	public class CarnationCane : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carnation Cane"); 
            Item.staff[item.type] = true;
		}
        public override void SetDefaults()
		{
			item.damage = 15;
			item.width = 38;
			item.height = 38;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.Blue;
			item.knockBack = 2;
			item.noMelee = true;
			item.mana = 8;
			item.UseSound = SoundID.Item20;
			item.shoot = ModContent.ProjectileType<PetalProj>();
			item.shootSpeed = 8f;
			item.autoReuse = true;
			item.magic = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 5);
			recipe.AddIngredient(ItemID.YellowMarigold, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}