using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Ranged
{
	public class FriendlyNutProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.width = 20;
            projectile.height = 24;
            projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
        }

        public override void AI()
        {
            projectile.rotation++;
        }
    }
}