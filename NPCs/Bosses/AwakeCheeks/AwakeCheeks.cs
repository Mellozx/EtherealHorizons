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

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
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
        private bool SecondPhase;

        // Attacks
        private const float Idle = 0f;
        private const float Stomp = 1f;
        private const float Vomit = 2f;
        private const float Glide = 3f;
        private const float Summon = 4f;

        // Variables
        // - Timers
        private int shootTimer;
        private int stompTimer;
        private int jumpTimer;
        private int fallTimer;
        private int textTimer;

        // - Misc
        private float speed => SecondPhase ? 3f : 5f;
        private float runSpeed => SecondPhase ? 5f : 8f;
        private int stomps;

        // Multiplayer syncing stuff
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(shootTimer);
            writer.Write(stompTimer);
            writer.Write(jumpTimer);
            writer.Write(fallTimer);
            writer.Write(textTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            shootTimer = reader.ReadInt32();
            stompTimer = reader.ReadInt32();
            jumpTimer = reader.ReadInt32();
            fallTimer = reader.ReadInt32();
            textTimer = reader.ReadInt32();
        }

        public override void AI()
        {
            Target();

            // Despawning the boss if the player is dead
            if (!player.active || player.dead || player.ghost)
            {
                DespawnHandler();
            }

            // Changing to the Phase Switch part, regardless of what Attack/State the NPC is on
            if (npc.life <= npc.lifeMax / 2)
            {
                State = PhaseSwitch;
                SecondPhase = true;
                return;
            }

            // Changing attacks, no matter what State/Attack the NPC is on
            // - Attacks change like the following:
            // Idle -> Attack 1 -> Attack 2 -> Idle -> Attack 3 -> Attack 4 -> Repeats
            AttackTimer += 1f;
            if (FloatInRange(AttackTimer, 12 * 60, 24 * 60)) // Attack1 - Stomp
            {
                Attack = Stomp;
            }
            else if (FloatInRange(AttackTimer, 24 * 60, 36 * 60)) // Attack2 - Vomit
            {
                Attack = Vomit;
            }
            else if (FloatInRange(AttackTimer, 36 * 60, 48 * 60)) // Idle - Idle
            {
                Attack = Idle;
            }
            else if (FloatInRange(AttackTimer, 48 * 60, 60 * 60)) // Attack3 - Glide
            {
                Attack = Glide;
            }
            else if (FloatInRange(AttackTimer, 60 * 60, 72 * 60)) // Attack4 - Summon
            {
                Attack = Summon;
            }
            else if (AttackTimer > 72 * 60) // Repeating the cycle
            {
                AttackTimer = 0;
            }

            if (State == FirstPhase)
            {
                if (Attack == Idle)
                {
                    npc.TargetClosest(true);
                    shootTimer++;
                    if (shootTimer >= 120)
                    {
                        // Basically shoot it in a diagonal towards the player direction, since it will automatically fall according to its AI
                        shootTimer = 0;
                        npc.netUpdate = true;
                    }


                    if (npc.WithinRange(player.Center, 60 * 16f))
                    {
                        MoveTowardsPlayerX(speed, 4f);
                    }
                    else
                    {
                        MoveTowardsPlayerX(runSpeed, 4f);
                    }

                    if (npc.velocity.Y == 0)
                    {
                        jumpTimer++;
                    }
                    else
                    {
                        jumpTimer = 0;
                    }

                    // If have been on ground for at least 1.5 seonds, and are hitting wall or there is a hole
                    if (jumpTimer >= 90 && (HoleBelow() || (npc.collideX && npc.position.X == npc.oldPosition.X)))
                    {
                        // Jump
                        npc.velocity.Y = Main.rand.Next(-11, -8);
                        npc.netUpdate = true;
                    }

                    if (npc.velocity.Y >= 0f)
                    {
                        Collision.StepUp(ref npc.position, ref npc.velocity, npc.width, npc.height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false, 1);
                    }
                }

                else if (Attack == Stomp)
                {
                    npc.TargetClosest(true);

                    // Each stomp has a 2 seconds cooldown
                    stompTimer++;
                    if (stompTimer < 120)
                    {
                        // Making it "prepare" for the stomp, walking towards the player
                        MoveTowardsPlayerX(1f, 4f);
                    }

                    // Making it give a weak stomp within 4 seconds
                    else if (IntInRange(stompTimer, 120, 360))
                    {
                        // 2 weak stomps
                        if (stomps < 2)
                        {
                            jumpTimer++;
                            if (jumpTimer < 60) // 1 second jumping should be enough to get kinda high
                            {
                                MoveTowardsPlayerX(6f, 4f);
                                npc.velocity.Y = -6f;

                                // Giving it some stomp effect other than just jumping and falling
                                fallTimer++;
                                if (fallTimer >= 60 && npc.velocity.Y != 0f)
                                {
                                    npc.velocity.Y = 8f;
                                }
                            }

                            else
                            {
                                if (npc.velocity.Y == 0f)
                                {
                                    player.GetModPlayer<EtherealPlayer>().StartScreenShake(2f, 1);

                                    for (int k = 0; k < 25; k++)
                                    {
                                        Dust.NewDust(new Vector2((int)npc.position.X, (int)npc.position.Y), 0, 0, DustID.Grass);
                                    }

                                    if (player.velocity.Y == 0f)
                                    {
                                        player.Hurt(PlayerDeathReason.ByCustomReason("Awake Cheeks made everyone go nuts"), npc.damage, npc.direction, false, false, false);
                                    }

                                    jumpTimer = 0;
                                }
                                else
                                {
                                    npc.velocity.Y = 6f;
                                    npc.velocity.X = 0f;
                                }
                            }
                        }
                        // Then a strong stomp
                        else
                        {
                            jumpTimer++;
                            if (jumpTimer < 120)
                            {
                                MoveTowardsPlayerX(8f, 4f);
                                npc.velocity.Y = -8f;

                                // Giving it some stomp effect other than just jumping and falling
                                fallTimer++;
                                if (fallTimer >= 60 && npc.velocity.Y != 0f)
                                {
                                    npc.velocity.Y = 10f;
                                }
                            }

                            else
                            {
                                if (npc.velocity.Y == 0f)
                                {
                                    player.GetModPlayer<EtherealPlayer>().StartScreenShake(4f, 1);

                                    for (int k = 0; k < 50; k++)
                                    {
                                        Dust.NewDust(new Vector2((int)npc.position.X, (int)npc.position.Y), 0, 0, DustID.Grass);
                                    }

                                    if (player.velocity.Y == 0f)
                                    {
                                        player.Hurt(PlayerDeathReason.ByCustomReason("Awake Cheeks made everyone go nuts"), npc.damage + npc.damage / 2, npc.direction, false, false, false);
                                    }
                                }
                                else
                                {
                                    npc.velocity.Y = 6f;
                                    npc.velocity.X = 0f;
                                }

                            }
                        }
                    }
                }
            }

            else if (State == PhaseSwitch)
            {
                npc.TargetClosest(true);
                npc.velocity = new Vector2(0f, 0f);
                if (npc.WithinRange(player.Center, 15 * 16f))
                {
                    State = FirstPhase;
                    npc.netUpdate = true;
                }
            }
        }

        // Utilities         
        private bool FloatInRange(float val, float min, float max) => val > min && val < max;
        private bool IntInRange(int val, int min, int max) => val > min && val < max;

        private bool HoleBelow()
        {
            // Width of npc in tiles
            int tileWidth = (int)Math.Round(npc.width / 16f);
            int tileX = (int)(npc.Center.X / 16f) - tileWidth;
            if (npc.velocity.X > 0) // If moving right
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

        private void MoveTowardsPlayerX(float speed, float direction)
        {
            if (npc.position.X - direction > player.position.X)
            {
                npc.velocity.X = -speed;
            }
            else if (npc.position.X + direction < player.position.X)
            {
                npc.velocity.X = speed;
            }
            else
            {
                npc.velocity.X = 0f;
            }
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