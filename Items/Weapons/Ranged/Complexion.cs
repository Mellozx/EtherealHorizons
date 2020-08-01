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
			item.useTime = 27;
			item.useAnimation = 27;
			item.UseSound = SoundID.Item5;
			item.damage = 16;
			item.knockBack = 3f;
			item.shootSpeed = 7f;
			item.shoot = 1;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 15);
			item.useAmmo = 40;
        }

		public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            if (Main.rand.NextBool(10))
            {
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<FriendlyNutProj>(), damage, knockBack, player.whoAmI);
            }
            return true;
		}
    }
}