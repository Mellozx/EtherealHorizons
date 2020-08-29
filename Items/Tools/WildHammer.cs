using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools
{
	public class WildHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wild Hammer");
		}
		
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useTurn = true;
			item.melee = true;
			item.damage = 12;
			item.hammer = 59;
			item.width = 20;
			item.height = 20;
			item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 30);
		}	
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 3);
			recipe.AddTile(TileID.Workbenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}