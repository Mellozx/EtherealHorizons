using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Hostile
{
	public class HostileNutProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            projectile.rotation += 0.2f * projectile.direction;

            projectile.ai[1]++;
            if (projectile.ai[1] > 30)
            {
                projectile.velocity.X *= 0.95f;
                projectile.velocity.Y += 0.5f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, projectile.Center);
            return true;
        }
    }
}