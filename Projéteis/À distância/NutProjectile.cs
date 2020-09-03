using Terraria; 
using Terraria.ID; 
using Terraria.ModLoader; 

namespace EtherealHorizons.Projectiles.Ranged
{
    public class NutProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            projectile.ranged = true; 
            proejctile.ignoreWater = true; 
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
            projectile.rotation = projectile.direction * 0.4f; 
            projectile.velocity.X *= 0.90f; 
            projectile.velocity.Y += 0.10f; 
        }
    }
}
