using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Ranged
{
	public class FriendlyNutProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nut");
		}

		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 30;
			projectile.aiStyle = 18;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.timeLeft = 2000;
			projectile.extraUpdates = 1;
			projectile.aiStyle = 0;
		}
		
		public override void AI()
		{
			projectile.rotation += 0.1f * (float)projectile.direction;
			projectile.ai[0] += 1f;
			projectile.velocity.Y = projectile.velocity.Y + 0.11f;    // projectile fall velocity
			projectile.velocity.X = projectile.velocity.X * 0.99f;    // projectile velocity
		}
		
		public override void Kill(int timeLeft) 
		{
			Main.PlaySound(SoundID.Item49, projectile.position);
		}
	}
}