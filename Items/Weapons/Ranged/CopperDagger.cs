using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class CopperDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Dagger");
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
            item.damage = 12;
            item.knockBack = 1f;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<CopperDaggerProjectile>();
			item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 10);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}