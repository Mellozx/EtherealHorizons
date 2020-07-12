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

            item.useStyle = ItemUseStyleID.SwingThrow;

            item.width = 28;
            item.height = 28;
        }
    }
}