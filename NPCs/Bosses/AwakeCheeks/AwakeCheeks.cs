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
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
    public class AwakeCheeks : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks");
        }

        public override void SetDefaults()
        {
            npc.buffImmune[BuffID.Confused] = true;
            npc.boss = true;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lavaImmune = true;
            npc.friendly = false;
            npc.width = 46;
            npc.height = 46;
            npc.lifeMax = 2200;
            npc.damage = 20;
            npc.defense = 4;
            npc.aiStyle = -1;
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

            }
        }

        public float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        public float Attack
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        public float AttackTimer
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        // States
        public const float Default = 0f;
        public const float Tired = 1f;
        public bool secondPhase;
        // Attacks
        public const float Idle = 0f;
        // Timers
        private int shootTimer;
        private int jumpTimer;

        public override void AI()
        {
            Target();

            if (!player.active || player.dead || player.ghost)
            {
                DespawnHandler();
            }

            if (State == Default)
            {
                if (Attack == Idle)
                {
                    npc.TargetClosest(true);
                    npc.velocity.X = MathHelper.Lerp(npc.velocity.X, 4 * Math.Sign(player.Center.X - npc.Center.X), 0.1f);

                    int shootCooldown = secondPhase ? 60 : 120;
                    int nutsQuantity = secondPhase ? 2 : 1;

                    shootTimer++;
                    if (shootTimer >= shootCooldown)
                    {
                        for (int k = 0; k < nutsQuantity; k++)
                        {
                            Vector2 speed = Vector2.Normalize(player.Center - npc.Center) * new Vector2(10);
                            Vector2 position = npc.position + new Vector2(22f, 27f);
                            Projectile.NewProjectile(position, speed, ModContent.ProjectileType<HostileNutProjectile>(), npc.damage / 2, 2f);
                            shootTimer = 0;
                            npc.netUpdate = true;
                        }
                    }
                }

                #region Tile Collision
                // Thanks for the code, Ben!
                if (npc.velocity.Y == 0)
                {
                    jumpTimer++;
                }
                else
                {
                    jumpTimer = 0;
                }
                if (npc.velocity.Y == 0)
                {
                    jumpTimer++;
                }
                else
                {
                    jumpTimer = 0;
                }

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
                #endregion
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(secondPhase);
            writer.Write(shootTimer);
            writer.Write(jumpTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            secondPhase = reader.ReadBoolean();
            shootTimer = reader.ReadInt32();
            jumpTimer = reader.ReadInt32();
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        private void DespawnHandler()
        {
            npc.TargetClosest(false);
            player = Main.player[npc.target];
            npc.timeLeft = 300;
        }

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

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}