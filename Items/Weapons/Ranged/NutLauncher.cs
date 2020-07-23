using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class NutLauncher : ModItem 
	{ 
		public override void SetStaticDefaults() 
		{ 
			DisplayName.SetDefault("Nut Launcher"); 
		}

        public override void SetDefaults()
        {
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = false;
			item.width = 20;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30;
			item.UseSound = SoundID.Item56;
			item.damage = 24;
			item.knockBack = 2f;
			item.shootSpeed = 4f;
			item.shoot = ModContent.ProjectileType<FriendlyNutProj>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 4);
			item.useAmmo = ModContent.ItemType<Nut>();
        }

		public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ModContent.ItemType<Nut>(), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-24f, -4f);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
    }
}