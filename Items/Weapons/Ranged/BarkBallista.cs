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
			item.autoReuse = false;
			item.width = 48;
			item.height = 24;
			item.useTime = 32;
			item.useAnimation = 32;
			item.UseSound = SoundID.Item5;
			item.damage = 20;
			item.knockBack = 3f;
			item.shootSpeed = 7f;
			item.shoot = 1;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 32);
			item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}            