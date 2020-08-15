using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Magic
{
	public class FlowerProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flower");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 22;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 120;
			projectile.arrow = false;
		}
	}
}
