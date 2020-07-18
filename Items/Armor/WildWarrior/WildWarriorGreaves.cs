using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.WildWarrior
{
    // [AutoloadEquip(EquipType.Legs)]
	public class WildWarriorGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Warrior Greaves");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.defense = 2;
            item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}