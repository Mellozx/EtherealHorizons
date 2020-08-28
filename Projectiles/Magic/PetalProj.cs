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
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.magic = true;
			projectile.timeLeft = 600;
			projectile.arrow = false;
		}
	}
}
