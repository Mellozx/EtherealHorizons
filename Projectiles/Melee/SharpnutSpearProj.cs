using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Melee
{
	public class SharpnutSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpnut Spear");
        }

        public override void SetDefaults()
        {
            projectile.melee = true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + (MathHelper.Pi * 3/4);
            var player = Main.player[projectile.owner];
            if(player.itemAnimation == 0)
                projectile.Kill();
            float progress = (1f / player.itemAnimationMax) * player.itemAnimation; // form 0 to 1 player swing
            // then double the progress so it's from 0 - 2
            // then substract 1 so it's from -1 to 1 (-1, -0.5, 0, 0.5, 1)
            // and then take absolute value so it's 1, 0.5, 0, 0.5, 1
            // and then flip it so it starts from 0 (1 - n) ((0, 0.5, 1, 0.5, 0))
            projectile.Center = Vector2.Lerp(player.Center, projectile.Center + new Vector2(10, 0).RotatedBy(projectile.rotation), 1f - Math.Abs(1f - progress * 2f)); 
        }
    }
}