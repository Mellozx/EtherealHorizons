using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Materials
{
    public class Nut : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.damage = 2;
            item.knockBack = 0f;
            item.shootSpeed = 3f;
            item.shoot = ModContent.ProjectileType<NutProjectile>();
            item.ammo = item.type;
            item.rare = ItemRarityID.White;
        }

    
        
    }
}
