using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons.Projectiles.Hostile
{
	public class SerpentSpit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poisonous Spit");
        }

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.width = 6;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.alpha = 204;
            projectile.extraUpdates = 2;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 44, Main.rand.Next(2, 3), Main.rand.Next(2, 3), 0, default(Color), 0.5f);
            }
    }
        public override void OnHitPlayer (Player target, int damage, bool crit)
        {
            if (Main.rand.NextBool(4))
            {
			target.AddBuff(BuffID.Poisoned, 300);
                }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, projectile.Center);
            return true;
        }
    }
}