using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
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
			projectile.timeLeft = 600;
			projectile.arrow = false;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
   			float speedX = projectile.velocity.X;
			float speedY = projectile.velocity.Y;
			// Spawn the Projectile.
			for (int i = 0; i < 4; i++)
			{
				float spreadAmt = 15f;
				float SpeedX = speedX + Main.rand.NextFloat(-spreadAmt, spreadAmt) * 0.05f;
    			float SpeedY = speedY + Main.rand.NextFloat(-spreadAmt, spreadAmt) * 0.05f;
				Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("PetalProj"), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
			}
		}

	}
}
