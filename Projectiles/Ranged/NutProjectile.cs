using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Ranged
{
    public class NutProjectile : ModProjectile
    {
        public override string Texture => EtherealHorizons.Placeholder;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
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

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, projectile.position);
        }
    }
}
