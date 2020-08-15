using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using EtherealHorizons.Projectiles.Ranged;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class BarkBallista : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bark Ballista");
		}
		public override void SetDefaults()
        {
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.width = 48;
			item.height = 24;
			item.useTime = 30;
			item.useAnimation = 30;
			item.UseSound = SoundID.Item5;
			item.damage = 24;
			item.knockBack = 3f;
			item.shootSpeed = 7f;
			item.shoot = 1;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 20);
			item.useAmmo = AmmoID.Arrow;
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

        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}            