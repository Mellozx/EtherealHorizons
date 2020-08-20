using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools.Wild
{
	public class WildHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wild Hammer");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.autoReuse = true;
			item.useTurn = true;
			item.width = 34;
			item.height = 34;
			item.damage = 7;
			item.useTime = 22;
			item.useAnimation = 22;
			item.hammer = 60;
			item.knockBack = 5.5f;
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
}