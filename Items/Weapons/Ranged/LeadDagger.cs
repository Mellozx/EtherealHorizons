using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Weapons.Ranged
{
    public class LeadDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Dagger");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.consumable = true;
            item.autoReuse = true;
            item.useTurn = false;
            item.maxStack = 999;
            item.width = 22;
            item.height = 22;
            item.useTime = 18;
            item.useAnimation = 18;
            item.damage = 15;
            item.knockBack = 3f;
            item.shootSpeed = 8f;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<LeadDaggerProjectile>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 15);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}