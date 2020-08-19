using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Melee;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class WildNature : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Wild Nature");
		}

		public override void SetDefaults() 
		{
			item.damage = 21;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.buyPrice(silver: 26);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
            item.scale = 1.2f;
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}