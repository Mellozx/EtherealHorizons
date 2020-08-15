using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class WildlifeFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wildlife Fragment");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.width = 28;
            item.height = 24;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 2);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ModContent.ItemType<Leaf>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Nut>(), 2);
            recipe.AddIngredient(ModContent.ItemType<AncientTwig>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}