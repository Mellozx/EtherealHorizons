using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
    public class BarkBallista : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bark Ballista");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.autoReuse = true;
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.damage = 20;
            item.knockBack = 4f;
            item.shootSpeed = 6f;
            item.shoot = AmmoID.Arrow; // Might be wrong
            item.useAmmo = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
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
