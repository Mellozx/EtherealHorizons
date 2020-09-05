using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
    public class SharpnutSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpnut Spear");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 28;
            item.useAnimation = 28;
            item.damage = 5;
            item.knockBack = 4f;
            item.shootSpeed = 4f;
            item.shoot = ModContent.ProjectileType<SharpnutSpearProjectile>();
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.White;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(copper: 30);
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1; // Not using the item if theres more than one spear
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ModContent.ItemType<Nut>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}