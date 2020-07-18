using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Tools
{
	public class WildPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Pickaxe");
        }

        public override void SetDefaults()
        {
            item.useTurn = true;
            item.melee = true;
            item.autoReuse = true;
            item.width = 20;
            item.height = 20;
            item.damage = 5;
            item.useTime = 21;
            item.useAnimation = 21;
            item.knockBack = 2f;
            item.pick = 45;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 30);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}