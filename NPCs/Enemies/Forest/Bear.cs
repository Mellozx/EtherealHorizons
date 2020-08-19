using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles.Hostile;
using System;
using System.IO;

namespace EtherealHorizons.NPCs.Enemies.Forest
{
    public class Bear : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bear");
        }

        public override void SetDefaults()
        {
            npc.lavaImmune = false;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.width = 150;
            npc.height = 80;
            npc.lifeMax = 100;
            npc.defense = 5;
            npc.damage = 20;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            if (State == HeadBashAttack)
            {
                State = Idle;
                npc.netUpdate = true;
            }
        }

        public float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        public float AttackTimer
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        public const float Idle = 0f;
        public const float ClawAttack = 1f;
        public const float HeadBashAttack = 2f;

        private int jumpTimer;
        private int clawTimer;

        public override void AI()
        {
            Target();

            #region Behaviour
            if (State == Idle)
            {
                npc.TargetClosest(true);

                // Checking if the NPC has a valid target
                if (npc.HasValidTarget)
                {      
                    npc.velocity.X = MathHelper.SmoothStep(npc.velocity.X, 10f * Math.Sign(player.Center.X - npc.Center.X), 0.1f);

                    AttackTimer++;
                    if (AttackTimer >= 300) // 5 seconds cooldown to perform each attack
                    {
                        // Checking if the distance of the player between the NPC is less than 6 tiles (64 pixels)
                        if (npc.WithinRange(player.Center, 8f * 16f))
                        {
                            State = ClawAttack;
                            npc.netUpdate = true;
                        }
                        else
                        {
                            State = HeadBashAttack;
                            npc.netUpdate = true;
                        }
                        AttackTimer = 0;
                        npc.netUpdate = true;
                    }
                }
            }
            else if (State == ClawAttack)
            {
                Main.NewText("Claw Attack is working!");
                // If the NPC's velocity is bigger than 0
                if (npc.velocity.X > 0f)
                {
                    npc.velocity.X = 0f;
                }

                // Else, if the NPC's velocity is equals to 0
                if (npc.velocity.X == 0f)
                {
                    // Increment a timer
                    clawTimer++;
                    if (clawTimer >= 60)
                    {
                        // Creating a projectile on the player's position
                        Projectile.NewProjectile((int)player.position.X, (int)player.position.Y, 0f, 0f, ModContent.ProjectileType<BearClawProjectile>(), npc.damage, 0f);
                        State = Idle; // Setting State back to Idle, because we already performed the Claw Attack once.
                        clawTimer = 0;
                        npc.netUpdate = true;
                    }
                }
            }
            else if (State == HeadBashAttack)
            {
                npc.damage = 40;

                npc.velocity.X = MathHelper.SmoothStep(npc.velocity.X, 25f * Math.Sign(player.Center.X - npc.Center.X), 0.1f);            
            }

            #endregion

            #region Tile Collision
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
            #endregion
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(jumpTimer);
            writer.Write(clawTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            jumpTimer = reader.ReadInt32();
            clawTimer = reader.ReadInt32();
        }

        private void Target()
        {
            player = Main.player[npc.target];
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
    }
}