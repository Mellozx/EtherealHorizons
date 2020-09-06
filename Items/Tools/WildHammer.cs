using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Tools
{
    public class WildHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Hammer");
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
            item.hammer = 55;
			item.damage = 9;
            item.knockBack = 5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 20);
        }
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
