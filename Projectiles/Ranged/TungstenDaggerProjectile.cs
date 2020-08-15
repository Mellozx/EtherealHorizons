using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Ranged
{
    public class TungstenDaggerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Dagger");
        }

        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.width = 12;
            projectile.height = 20;
            projectile.timeLeft = 300;
            projectile.aiStyle = 2;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, projectile.Center);
        }
    }
}