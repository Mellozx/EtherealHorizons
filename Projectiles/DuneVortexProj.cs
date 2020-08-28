using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace EtherealHorizons.Projectiles
{
	public class DuneVortexProj : ModProjectile
	{
		public override string Texture => EtherealHorizons.PlaceholderTexture;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Vortex");
		}
		
		public override void SetDefaults()
		{
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			aiType = -1;
		}
		
		public override void AI()
		{
			projectile.velocity = new Vector2(0f, 0f);
			projectile.rotation += 0.10f;
			
			int npcs = 0;
			
			for (int i = 0; i < Main.npc.Length; i++)
			{
				npcs++;
				NPC npc = Main.npc[i];	
				
				if (npc.WithinRange(projectile.Center, 15f * 16f) && npc.lifeMax <= 100 && npcs <= 10)
				{
					npc.velocity = Vector2.Normalize(projectile.Center - npc.Center) * new Vector2(1.5f, 1.5f);
					npc.netUpdate = true;
					
					for (int k = 0; k < 10; k++)
					{
						Vector2 speed = Vector2.Normalize(projectile.Center - npc.Center) * new Vector2(2f, 2f);
						int dust = Dust.NewDust(npc.Center, 0, 0, DustID.Grass, speed.X, speed.Y, 0, Color.Yellow, 0.7f);
						Main.dust[dust].fadeIn = 60;
					}
				}
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC npc = Main.npc[i];
				
				if (npc.WithinRange(projectile.Center, 16f) && npc.lifeMax <= 80)
				{
					float rand = Main.rand.NextFloat(-5f, 5f);
					npc.velocity = new Vector2(rand, -8f);
					npc.netUpdate = true;
				}
			}
			
			for (int k = 0; k < 20; k++)
			{
				float rand = Main.rand.NextFloat(-4f, 4f);
				Dust.NewDust(projectile.position, 0, 0, DustID.Grass, rand, -6f);
			}
		}
	}
}