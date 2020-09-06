using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Tools
{
	public class Hoe : ModItem 
    {
		public override string Texture => EtherealHorizons.PlaceholderTexture;
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hoe");
            Tooltip.SetDefault("This is a hoe, what are you expecting?");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 25;
            item.useAnimation = 25;
            item.damage = 10;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item1;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddRecipeGroup("IronBar", 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}