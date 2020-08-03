using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Ranged
{
    public class AridArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Arrow");
        }

		public override void SetDefaults()
		{
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
            if(Main.rand.Next(15) > 10)
				{
                float projectileknockBack = 4f;
                int projectiledamage = 4;
				Projectile.NewProjectile(target.Center, Vector2.Zero, ProjectileID.SandnadoFriendly, projectiledamage, projectileknockBack, projectile.owner, 0f, 0f);
				}
        }
    }
}
