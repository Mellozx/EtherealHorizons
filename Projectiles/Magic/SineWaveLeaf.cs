using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace EtherealHorizons.Projectiles.Magic
{
	public class SineWaveLeaf : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Leaf");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults() 
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 0;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
		public override void AI()
		{
			//making it move in a sine wave
			projectile.position.Y = projectile.position.Y - (float)Math.Sin(Main.GlobalTime * 4) * 2;
			if(++projectile.ai[0] >= 10)
			{
			projectile.frame++;
			projectile.ai[0] = 0;
			if(projectile.frame == 4) projectile.frame = 0;
			}
		}
	}
}