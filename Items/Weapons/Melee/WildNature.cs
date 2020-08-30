using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

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
			item.melee = true;
			item.autoReuse = false;
			item.useTurn = false;
			item.width = 20;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.damage = 18;
			item.knockBack = 4f;
			item.UseSound = SoundID.Item1;
			item.useStyle = ItemUseStyleID.SwingThrow;
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
}