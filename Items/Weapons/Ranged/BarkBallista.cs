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
			item.value = Item.sellPrice(silver: 18);
			item.useAmmo = 40;
        }
		public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}            