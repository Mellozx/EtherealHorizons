using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Magic
{
    public class PetalProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Petal");
        }

        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.timeLeft = 180;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
			projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			projectile.velocity.X *= 0.99f;
            projectile.velocity.Y += 0.05f;

        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(projectile.position, 0, 0, DustID.Grass);
            }
            Main.PlaySound(SoundID.Dig, projectile.position); // Placeholder Sound
        }
    }
}
