using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.Olden
{
    [AutoloadEquip(EquipType.Body)]
    public class OldenMantle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Olden Mantle");
            Tooltip.SetDefault("");
        }


        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 30);
            item.rare = ItemRarityID.Blue;
            item.defense = 4;
        }

        // i didnt add any special effects to the chestplate since i was unsure you could add anything below

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
