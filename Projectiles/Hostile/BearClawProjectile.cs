using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Hostile
{
    public class BearClawProjectile : ModProjectile
    {
        public override string Texture => EtherealHorizons.PlaceholderTexture;

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false; 
            projectile.damage = 30;
            projectile.timeLeft = 120;
            projectile.width = 20;
            projectile.height = 20;
        }
    }
}