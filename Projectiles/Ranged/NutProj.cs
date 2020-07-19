using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Ranged
{
	public class FriendlyNutProj : ModProjectile
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.aiStyle = 1;
        }

        public override void AI()
        {
            projectile.rotation += 0.4f * projectile.direction;

            projectile.ai[2]++;
            if(projectile.ai[2] >= 15)
            {
                projectile.velocity.Y = 3f;
            }
        }
    }
}