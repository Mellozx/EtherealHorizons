using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Melee;

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
            item.noMelee = true;
            item.noUseGraphic = true;

            item.shoot = ModContent.ProjectileType<SharpnutSpearProj>();
            item.shootSpeed = 10f;

            item.useStyle = ItemUseStyleID.HoldingOut;

            item.useTime = 40;
            item.useAnimation = 40;
            item.width = 28;
            item.height = 28;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<SharpnutSpearProj>()] < 1; // only 1 spear
        }
    }
}