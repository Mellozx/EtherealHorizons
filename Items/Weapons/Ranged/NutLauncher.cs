using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Ranged;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
    public class NutLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut Launcher");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.useTurn = false;
            item.autoReuse = true;
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 25;
            item.useAnimation = 25;
            item.damage = 3;
            item.knockBack = 0f;
            item.shootSpeed = 4f;
            item.shoot = ModContent.ProjectileType<NutProjectile>();
            item.useAmmo = ModContent.ItemType<Nut>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item56;
            item.value = Item.sellPrice(copper: 30);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddIngredient(ModContent.ItemType<Nut>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
