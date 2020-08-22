using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.DuneRaider
{
    public class DuneRaidersChestplate : ModItem
    {
        public override string Texture => EtherealHorizons.PlaceholderTexture;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dune Raider's Chestplate");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 30);
            item.rare = ItemRarityID.White;
            item.defense = 2;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 40);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ModContent.ItemType<DustiliteChunk>(), 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}