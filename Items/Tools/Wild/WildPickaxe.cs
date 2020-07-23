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
			item.height = 34;
            item.damage = 6;
			item.useTime = 20;
			item.useAnimation = 20;
			item.pick = 57;
			item.knockBack = 2.5f; 
			item.rare = ItemRarityID.Green;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 26);
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