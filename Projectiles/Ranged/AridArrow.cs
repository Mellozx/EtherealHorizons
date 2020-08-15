using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

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
            if (Main.rand.Next(15) > 10 && projectile.owner == Main.myPlayer)
				{
				Projectile.NewProjectile(target.Center, Vector2.Zero, ProjectileID.SandnadoFriendly, 4, projectile.knockBack, projectile.owner, 0f, 0f);
				}
        }
    }
}
