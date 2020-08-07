using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Weapons.Ranged
{
    public class GoldDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Dagger");
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
            item.useTime = 17;
            item.useAnimation = 17;
            item.damage = 17;
            item.knockBack = 2f;
            item.shootSpeed = 14f;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<GoldDaggerProjectile>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 30);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}