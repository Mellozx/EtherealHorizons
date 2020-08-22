using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class WoodenClub : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Wooden Club");
            Tooltip.SetDefault("Ooga Booga!");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.melee = true;
			item.width = 32;
			item.height = 34;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(copper: 30);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
            item.scale = 1.1f;
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}