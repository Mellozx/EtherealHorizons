using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class WildlifeFragment : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wildlife Fragment");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 10;
            item.height = 10;
            item.maxStack = 999;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 12);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 4);
            recipe.AddIngredient(ModContent.ItemType<Nut>(), 2);
            recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}