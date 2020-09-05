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
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.hostile = false;
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = 0;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
            projectile.rotation += 0.2f * projectile.direction;
            projectile.velocity.Y += 0.10f;
            projectile.velocity.X *= 0.90f;
        }

        public override void Kill(int timeLeft)
        {
            Dust.NewDust(projectile.position, 0, 0, DustID.Grass, 0, 0, 0, default, 0.7f);
            Main.PlaySound(SoundID.Dig, projectile.position);
        }
    }
}