using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 

namespace EtherealHorizons.Items.Armor.DuneRaider
{
	public class DuneRaidersSandals : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dune Raider's Sandals");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.White;
            item.defense = 2;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 10);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ModContent.ItemType<DustiliteChunk>(), 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}