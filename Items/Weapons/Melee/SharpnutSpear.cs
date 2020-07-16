using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Melee.Spears;
using Microsoft.Xna.Framework;

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

            item.damage = 8;
            item.useTime = 25;
            item.useAnimation = 25;

            item.width = 28;
            item.height = 28;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<SharpnutSpearProj>()] < 1; // only 1 spear
        }
    }
}