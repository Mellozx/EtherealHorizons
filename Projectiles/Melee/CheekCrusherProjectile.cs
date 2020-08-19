using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Weapons.Melee;

namespace EtherealHorizons.Projectiles.Melee
{
	public class CheekCrusherProjectile : ModProjectile
	{
		private bool crashed;
		private bool stomp;
		public static int hits;
		private Player player;
		
		public override void SetDefaults()
		{
			projectile.tileCollide = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 0;
			projectile.penetrate = 1;
		}
		
		public override void AI()
		{
			player = Main.player[projectile.owner];
			projectile.rotation += 0.4f * projectile.direction;		
			
			if (hits == 6)
			{
				stomp = true;
				CombatText.NewText(player.getRect(), Color.Yellow, "Special attack charged!", false, false);
				hits = 7;
				return;
			}
			
			else if (hits == 7)
			{
				hits = 0;
			}
			
			if (!stomp)
			{
				projectile.ai[0]++;
				if (projectile.ai[0] >= 50 || crashed)
				{
					projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * new Vector2(CheekCrusher.speed, CheekCrusher.speed);
					projectile.tileCollide = false;
					if (projectile.WithinRange(player.Center, 1f * 16f))
					{
						projectile.Kill();
					}            
				}
			}
			else
			{
				projectile.ai[0]++;
				if (projectile.ai[0] >= 30)
				{
					projectile.velocity.Y = 16f;
					projectile.ai[1]++;
					if (projectile.ai[1] <= 90)
					{
						projectile.velocity.Y = -1f;
					}
					else
					{
						projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * new Vector2(CheekCrusher.speed, CheekCrusher.speed);
						if (projectile.WithinRange(player.Center, 1f * 16f))
						{
							projectile.Kill();
						}  
					}
				}
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			player = Main.player[projectile.owner];

			for (int k = 0; k < 20; k++)
            {
				Dust.NewDust(projectile.position, 0, 0, DustID.Grass);
            }

			if (stomp)
            {
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.velocity.Y == 0f && npc.position.Y == projectile.position.Y)
					{
						int npcHit = (int)npc.StrikeNPC(40, 6f, projectile.direction, Main.rand.NextBool(4), false, false);
						Dust.NewDust(Main.npc[npcHit].position, 0, 0, DustID.Grass);
					}
				}
			}
			
			crashed = true;
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
		{
			hits++;
		}
	}
}
