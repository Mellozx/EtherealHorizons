using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.WildWarrior
{
    // [AutoloadEquip(EquipType.Body)]
	public class WildWarriorChestplate : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Warrior Chestplate");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.defense = 3;
            item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 9);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}