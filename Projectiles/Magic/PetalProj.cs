using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Magic
{
	public class PetalProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petal");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 16;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.penetrate = 5;
			projectile.magic = true;
			projectile.timeLeft = 100;
			projectile.arrow = false;
		}
		public override void AI()
		{
			projectile.velocity = (projectile.velocity).RotatedBy(MathHelper.ToRadians(Main.rand.Next(90)));
		}
	}
}
