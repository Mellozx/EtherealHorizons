using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EtherealHorizons.Projectiles.Hostile;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
    public class AwakeCheeks : ModNPC
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER"; 

        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks");
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lavaImmune = true;

            npc.width = 46;
            npc.height = 46;
            npc.lifeMax = 2200;
            npc.damage = 20;
            npc.defense = 4;
			npc.knockBackResist = 0f;

            music = MusicID.Boss2;
            musicPriority = MusicPriority.BossMedium;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {

            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            EtherealWorld.downedAwakeCheeks = true;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                // NPC.NewNPC (Death Scene)
            }
        }

		public float State
        {
            get => npc.ai[0]; // States (Phases)
            set => npc.ai[0] = value;
        }

        public float Attack
        {
            get => npc.ai[1]; // Attacks (Duh)
            set => npc.ai[1] = value;
        }

        public float AttackTimer
        {
            get => npc.ai[2]; // Attack Timer (Use to switch attacks for example)
            set => npc.ai[2] = value;
        }

        // Phases
        private const float FirstPhase = 0f;
        private const float PhaseSwitch = 1f;
        private const float SecondPhase = 2f;

        // Attacks
        private const float Idle = 0f;
        private const float StompAttack = 1f;
        private const float VomitAttack = 2f;
        private const float GlideAttack = 3f;
        private const float SummonAttack = 4f;

        // Variables
        private int shootTimer;
        private int stompTimer;
        private int jumpTimer;

        public override void AI()
        {
            Target();

            if (!player.active || player.dead || player.ghost)
            {
                DespawnHandler();
            }

            if (State == FirstPhase)
            {
                if (npc.life <= npc.lifeMax / 2)
                {
                    State = PhaseSwitch;
                }

                if (Attack == Idle)
                {
                    npc.TargetClosest(true);
                    shootTimer++;
                    if (shootTimer >= 120)
                    {
                        // Basically shoot it in a diagonal towards the player direction, since it will automatically fall according to its AI
                        Projectile.NewProjectile(npc.Center, (Vector2.Normalize(player.MountedCenter - npc.Center) * 4).RotatedBy(MathHelper.ToRadians(60)), ModContent.ProjectileType<HostileNutProjectile>(), npc.damage, 0, Main.myPlayer);
                        shootTimer = 0;
                        npc.netUpdate = true;
                    }

                    if (npc.position.X - 4 > player.position.X)
                    {
                        npc.velocity.X = -2f;
                    }
                    else if (npc.position.X + 4 < player.position.X)
                    {
                        npc.velocity.X = 2f;
                    }
                    else
                    {
                        npc.velocity.X = 0f;
                    }

                    if (!npc.WithinRange(player.Center, 59 * 16f))
                    {
                        if (npc.position.X > player.position.X)
                        {
                            npc.velocity.X = -4f;
                        }
                        else if (npc.position.X < player.position.X)
                        {
                            npc.velocity.X = 4f;
                        }
                    }

					if (npc.velocity.Y == 0)
					{
						jumpTimer++;
					}
					else
					{
						jumpTimer = 0;
					}

					//if have been on ground for at least 1.5 seonds, and are hitting wall or there is a hole
					if (jumpTimer >= 90 && (HoleBelow() || (npc.collideX && npc.position.X == npc.oldPosition.X)))
					{
						//jump
						npc.velocity.Y = Main.rand.Next(-11, -8);
						npc.netUpdate = true;
					}

					if (npc.velocity.Y >= 0f)
					{
						Collision.StepUp(ref npc.position, ref npc.velocity, npc.width, npc.height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false, 1);
					}

                    /*jumpTimer++;
                    if (jumpTimer >= 180)
                    {
                        if (npc.position.Y > player.position.Y - -12 * 16f && npc.velocity.Y == 0)
                        {
                            npc.velocity.Y = Main.rand.Next(-11, -8);
                            jumpTimer = 0;
                            npc.netUpdate = true;
                            return;
                        }
                        else if (npc.position.Y > player.position.Y + 12 * 16f && npc.velocity.Y == 0)
                        {
                            npc.velocity.Y = Main.rand.Next(8, 11);
                            jumpTimer = 0;
                            npc.netUpdate = true;
                            return;
                        }
                    }*/

                    AttackTimer++;
                    if (AttackTimer >= 900)
                    {
						//Attack = StompAttack;
						AttackTimer = 0;
                        npc.netUpdate = true;
                    }
                }

                else if (Attack == StompAttack)
                {
                    npc.TargetClosest(true);
                    // Its borken ;-;
                }
            }

            else if (State == PhaseSwitch)
            {
                npc.TargetClosest(true);
                npc.velocity = new Vector2(0f, 0f);
                if (npc.WithinRange(player.Center, 15 * 16f))
                {
                    State = SecondPhase;
                    npc.netUpdate = true;
                }
            }

            else if (State == SecondPhase)
            {
                npc.damage = npc.damage + npc.damage / 2;

                if (Attack == Idle)
                {
                    npc.TargetClosest(true);
                    shootTimer++;
                    if (shootTimer >= 300)
                    {
                        // Basically shoot it in a diagonal towards the player direction, since it will automatically fall according to its AI
                        Projectile.NewProjectile(npc.Center, (Vector2.Normalize(player.MountedCenter - npc.Center) * 6).RotatedBy(MathHelper.ToRadians(-60)), ModContent.ProjectileType<HostileNutProjectile>(), npc.damage, 0, Main.myPlayer);
                        shootTimer = 0;
                        npc.netUpdate = true;
                    }

                    if (npc.position.X - 4 > player.position.X)
                    {
                        npc.velocity.X = -4f;
                    }
                    else if (npc.position.X + 4 < player.position.X)
                    {
                        npc.velocity.X = 4f;
                    }
                    else
                    {
                        npc.velocity.X = 0f;
                    }

                    if (!npc.WithinRange(player.Center, 59 * 16f))
                    {
                        if (npc.position.X > player.position.X)
                        {
                            npc.velocity.X = -8f;
                        }
                        else if (npc.position.X < player.position.X)
                        {
                            npc.velocity.X = 8f;
                        }
                    }

					if (npc.velocity.Y == 0)
					{
						jumpTimer++;
					}
					else
					{
						jumpTimer = 0;
					}

					//if have been on ground for at least 1.5 seonds, and are hitting wall or there is a hole
					if (jumpTimer >= 90 && (HoleBelow() || (npc.collideX && npc.position.X == npc.oldPosition.X)))
					{
						//jump
						npc.velocity.Y = Main.rand.Next(-12, -9);
						npc.netUpdate = true;
					}

					if (npc.velocity.Y >= 0f)
					{
						Collision.StepUp(ref npc.position, ref npc.velocity, npc.width, npc.height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false, 1);
					}

                    /*jumpTimer++;
                    if (jumpTimer >= 180)
                    {
                        if (npc.position.Y > player.position.Y - -12 * 16f && npc.velocity.Y == 0)
                        {
                            npc.velocity.Y = Main.rand.Next(-12, -9); 
                            jumpTimer = 0; 
                            npc.netUpdate = true;
                            return;
                        }
                        else if (npc.position.Y > player.position.Y + 12 * 16f && npc.velocity.Y == 0)
                        { 
                            npc.velocity.Y = Main.rand.Next(9, 12);
                            jumpTimer = 0;
                            npc.netUpdate = true;
                            return;
                        }
                    }*/
                }
            }
        }

        private bool HoleBelow()
        {
            //width of npc in tiles
            int tileWidth = (int)Math.Round(npc.width / 16f);
            int tileX = (int)(npc.Center.X / 16f) - tileWidth;
            if (npc.velocity.X > 0) //if moving right
            {
                tileX += tileWidth;
            }
            int tileY = (int)((npc.position.Y + npc.height) / 16f);
            for (int y = tileY; y < tileY + 2; y++)
            {
                for (int x = tileX; x < tileX + tileWidth; x++)
                {
                    if (Main.tile[x, y].active())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(shootTimer);
            writer.Write(stompTimer);
            writer.Write(jumpTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            shootTimer = reader.ReadInt32();
            stompTimer = reader.ReadInt32();
            jumpTimer = reader.ReadInt32();
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        private void DespawnHandler()
        {
            npc.TargetClosest(false);
            npc.timeLeft = 300;
            if (npc.timeLeft < 120)
            {
                npc.velocity.Y = -0.5f;
            }
            else
            {
                npc.velocity.Y = 8f;
            }
        }
    }
}