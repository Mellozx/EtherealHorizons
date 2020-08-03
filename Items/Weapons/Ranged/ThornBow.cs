using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using EtherealHorizons.Projectiles.Ranged;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class ThornBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn Bow");
			Tooltip.SetDefault("Turns wooden arrows to spike arrows");
		}
		public override void SetDefaults()
		{
			item.damage = 7;
			item.ranged = true;
			item.width = 24;
			item.height = 38;
			item.useTime = 22;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = Item.buyPrice(0, 0, 2, 36);;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;;
			item.shoot = 2;
			item.shootSpeed = 5f;
		}
public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) 
            {
                type = ModContent.ProjectileType<SpikeArrow>(); 
            }
            return true; 
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Thorn>());
			recipe.AddIngredient(ItemID.Sandstone, 13);
			recipe.AddIngredient(ItemID.Cactus, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}            