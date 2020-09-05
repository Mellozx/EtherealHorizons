using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
    public class WoodenClub : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Club");
            Tooltip.SetDefault("Ooga Booga");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = false;
            item.width = 20;
            item.height = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.damage = 10;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(copper: 30);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

