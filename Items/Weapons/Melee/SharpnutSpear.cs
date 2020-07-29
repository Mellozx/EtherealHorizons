using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class SharpnutSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Sharpnut Spear");
		}

		public override void SetDefaults() 
		{
			item.damage = 5;
			item.melee = true;
			item.width = 32;
			item.height = 28;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 5;
			item.knockBack = 3f;
			item.value = Item.sellPrice(copper: 50);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("SharpnutSpearProj");
            item.shootSpeed = 2.5f;
		}
        public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
				public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 16);
			recipe.AddIngredient(mod.ItemType("Nut"), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}