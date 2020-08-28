using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools.Wild
{
	public class WildAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Axe");
        }

        public override void SetDefaults()
        {
			item.melee = true;
			item.autoReuse = true;
			item.useTurn = true;
			item.width = 36;
			item.height = 32;
			item.damage = 7;
			item.useTime = 18;
			item.useAnimation = 18;
			item.axe = 12;
			item.knockBack = 4.5f;
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