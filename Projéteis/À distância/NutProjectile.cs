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
            projectile.tileCollide = false; 
            projectile.ranged = true; 
            proejctile.ignoreWater = true; 
            projectile.timeLeft = 180;
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
            projectile.rotation = 0.2f * projectile.direction; 
            projectile.velocity.X *= 0.90f; 
            projectile.velocity.Y += 0.10f; 
        }

        public override Kill(int timeLeft) 
        {
            Main.PlaySound(SoundID.Dig, projectile.position); 
        }
    }
}
