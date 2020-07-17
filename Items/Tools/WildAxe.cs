using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools.Wild
{
	public class WildAxe : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Axe");
        }

        public override void SetDefaults()
        {
            item.useTurn = true;
            item.melee = true;
            item.autoReuse = true;
            item.width = 20;
            item.height = 20;
            item.damage = 7;
            item.useTime = 27;
            item.useAnimation = 27;
            item.knockBack = 3.5f;
            item.axe = 9;
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