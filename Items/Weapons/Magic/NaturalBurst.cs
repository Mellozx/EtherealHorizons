using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Magic
{
	public class NaturalBurst : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Natural Burst");
			Tooltip.SetDefault("Shoots a spread of leaves in a inaccurate speed");
			Item.staff[item.type] = true;
		}
		
		public override void SetDefaults()
		{
			item.magic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 24;
			item.mana = 10;
			item.knockBack = 3f;
			item.rare = ItemRarityID.Blue;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 16f;
			item.value = Item.sellPrice(silver: 30);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 4;
			float rotation = MathHelper.ToRadians(30);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * Main.rand.NextFloat(0.5f, 0.2f);
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}