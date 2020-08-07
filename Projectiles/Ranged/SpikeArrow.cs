using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Ranged
{
    public class SpikeArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spike Arrow");
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
            if (Main.rand.NextBool(5))
            {
			target.AddBuff(BuffID.Poisoned, 180);
            }
        }
    }
}
