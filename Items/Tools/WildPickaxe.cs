using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools
<<<<<<< HEAD
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
            item.damage = 6;
			item.useTime = 17;
			item.useAnimation = 17;
			item.pick = 60;
			item.knockBack = 2.5f; 
			item.rare = ItemRarityID.Blue;
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
=======
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
			item.width = 20;
			item.height = 20;
			item.pick = 59;
			item.useTime = 18;
			item.useAnimation = 18;	
			item.damage = 9;
			item.knockBack = 2f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 30);
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
>>>>>>> master
}