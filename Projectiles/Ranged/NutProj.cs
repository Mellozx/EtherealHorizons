using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Ranged
{
	public class NutProj : ModProjectile
    {
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
        }
    }
}