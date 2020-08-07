using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Ranged
{
	public class CopperDaggerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Dagger");
        }

        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.width = 12;
            projectile.height = 20;
            projectile.timeLeft = 300;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
            projectile.rotation += 0.2f * projectile.direction;
projectile.velocity.Y = MathHelper.SmoothStep(projectile.velocity.Y, 16f, 0.075f);
projectile.velocity.X *= 0.975f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, projectile.Center);
        }
    }
}