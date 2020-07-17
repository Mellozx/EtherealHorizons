using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Melee.Spears
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
            projectile.friendly = true;
            projectile.ownerHitCheck = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.width = 54;
            projectile.height = 54;
            drawOffsetX = -10;
            drawOriginOffsetX = 10;
            drawOriginOffsetY = 10;
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            const int x = 20;
            const int y = 20;
            hitbox.Width -= x;
            hitbox.X += x / 2;
            hitbox.Height -= y;
            hitbox.Y += y / 2;
        }

        public override void AI()
        {
            float rot = projectile.velocity.ToRotation();
            projectile.rotation = rot + MathHelper.PiOver4;
            Player player = Main.player[projectile.owner];
            if (player.itemAnimation == 0) // when the use is over
                projectile.Kill();
            float progress = 1f / player.itemAnimationMax * player.itemAnimation;
            // First the progress from 0 to 1 of the used item (when the item use is over, the value is 1) (0 > 0.25 > 0.5 > 0.75 > 1)
            // Then double the progress so it's from 0 to 2 (0 > 0.5 > 1 > 1.5 > 2)
            // Then substract 1 to the progress for -1 to 1 (-1 > -0.5 > 0 > 0.5 > 1)
            // Then take the absolute value (1 > 0.5 > 0 > 0.5 > 1)
            // Then flip the progress (1 - progress) (0 > 0.5 > 1 > 0.5 > 0)
            projectile.Center = Vector2.Lerp(player.MountedCenter, player.MountedCenter + new Vector2(40, 0).RotatedBy(rot), 1f - Math.Abs(1f - progress * 2));
        }
    }
}