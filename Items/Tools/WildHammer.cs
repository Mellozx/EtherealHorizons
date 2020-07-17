using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools.Wild
{
	public class WildHammer : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Hammer");
        }

        public override void SetDefaults()
        {
            item.useTurn = true;
            item.melee = true;
            item.autoReuse = true;
            item.width = 20;
            item.height = 20;
            item.damage = 7;
            item.useTime = 28;
            item.useAnimation = 28;
            item.knockBack = 5f;
            item.hammer = 42;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 30);
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