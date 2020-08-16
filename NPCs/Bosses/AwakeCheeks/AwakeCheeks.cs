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

        public override void AI()
        {
            Target();

            if (State == Default)
            {
                if (Attack == Idle)
                {
                    npc.velocity.X = 4f * player.direction;

                    int shootCooldown = secondPhase ? 60 : 120;
                    int nutsQuantity = secondPhase ? 2 : 1;

                    shootTimer++;
                    if (shootTimer >= shootCooldown)
                    {
                        for (int k = 0; k < nutsQuantity; k++)
                        {
                            Vector2 speed = Vector2.Normalize(npc.Center - player.Center) * new Vector2(-6f, -4f);
                            Projectile.NewProjectile(npc.position, speed, ModContent.ProjectileType<HostileNutProjectile>(), npc.damage / 2, 2f);
                            shootTimer = 0;
                            npc.netUpdate = true;
                        }
                    }
                }
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        private void DespawnHandler()
        {
            npc.TargetClosest(false);
            player = Main.player[npc.target];
            if(player.active)
            npc.TargetClosest(false);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}