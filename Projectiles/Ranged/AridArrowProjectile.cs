using Terraria;
using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Ranged
{
    public class AridArrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Arrow");
        }

		public override void SetDefaults()
		{
            projectile.knockBack = 4f;
			projectile.width = 14;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.arrow = true;
		}
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {

        }
    }
}
