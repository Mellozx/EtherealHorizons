using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools.Wild
{ 
	public class WildPickaxe : ModItem 
	{ 
		public override void SetStaticDefaults() 
		{ 
			DisplayName.SetDefault("Wild Pickaxe"); 
		} 

		public override void SetDefaults() 
		{ 
			item.melee = true; 
			item.autoReuse = true;
			item.useTurn = true;
			item.width = 34; 
			item.height = 30;
<<<<<<< HEAD
            item.damage = 6;
			item.useTime = 17;
			item.useAnimation = 17;
			item.pick = 60;
=======
            item.damage = 12;
			item.useTime = 10;
			item.useAnimation = 20;
			item.pick = 64;
>>>>>>> dda35c938d9033918cfefa03b0453036844bda76
			item.knockBack = 2.5f; 
			item.rare = ItemRarityID.Green;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.value = Item.buyPrice(0, 0, 26, 0);
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