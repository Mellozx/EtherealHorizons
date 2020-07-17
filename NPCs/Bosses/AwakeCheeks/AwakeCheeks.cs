using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Items.TreasureBags;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
    // [AutoloadBossHead]
    public class AwakeCheeks : ModNPC
    {
        private Player player;

        public override string Texture => Helpers.PLACEHOLDER;

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

            npc.lifeMax = 1400;
            npc.defense = 3;
            npc.damage = 18;

            npc.width = 20;
            npc.height = 20;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;

            npc.value = Item.sellPrice(gold: 5);

            music = MusicID.Boss1;
            musicPriority = MusicPriority.BossMedium;

            bossBag = ModContent.ItemType<AwakeCheeksBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }

        private int shootTimer;

        public override void AI()
        {
            // npc.ai[0] State/Attack
            // npc.ai[1] n/a
            // npc.ai[2] Timers
            // npc.ai[3] n/a

            Target();

            // Idle - It keeps moving towards the player while throwing nuts. Would stay stopped while throwing nuts. Throws a nut each 5 seconds.
            if (npc.ai[0] == 0f)
            {
                npc.dontTakeDamage = false;

                shootTimer++;
                if (shootTimer >= 300)
                {
                    Projectile.NewProjectile(npc.position, default, ProjectileID.WoodenArrowHostile, 0, 0f, Main.myPlayer);
                    npc.netUpdate = true;
                    shootTimer = 0;
                }

                if (npc.position.X - 8 > player.position.X)
                {
                    npc.velocity.X = -2f;
                }
                else if (npc.position.X + 8 < player.position.X)
                {
                    npc.velocity.X = 2f;
                }
                else
                {
                    npc.velocity.X = 0f;
                }

                // Making it faster if Awake Cheeks is too far (End of the screen) from the player
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

                // Going to the first attack
                npc.ai[2]++;
                if (npc.ai[2] >= 300)
                {
                    npc.ai[0] = 2f;
                }
            }

            // Attack 1 - A powerful stomp that shakes everything and damages you if you're touching the ground. A dust effect appears from Cheeks going to the player.
            else if (npc.ai[0] == 1f)
            {
            }

            // Attack 2 - Awake Cheeks would open its mouth and shoot a spread of nuts coming from it.
            else if (npc.ai[0] == 2f)
            {
                npc.velocity = new Vector2(0f, 0f);

                shootTimer++;
                if (shootTimer == 120)
                {
                    int shoots = Main.rand.Next(11, 14);
                    for (int i = 0; i < shoots; i++)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0f, 0f), ProjectileID.WoodenArrowHostile, 12, 2f, Main.myPlayer);
                    }
                }

                if (shootTimer >= 180)
                {
                    npc.ai[0] = 0f;
                }
            }

            // Attack 3 - It would give a jump and fly with its tail, while falling it would glide, causing to shoot nuts.
            else if (npc.ai[0] == 3f)
            {

            }

            // Making so that it enters second phase
            if (npc.life <= npc.lifeMax / 2)
            {
                npc.ai[0] = 4f;
            }

            // "Second Phase"
            else if (npc.ai[0] == 4f)
            {
                npc.TargetClosest(true);
                npc.dontTakeDamage = true;
                npc.velocity = new Vector2(0f, 0f);

                if (player.WithinRange(npc.Center, 16f * 8f))
                {
                    npc.ai[0] = 0f;
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(shootTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            shootTimer = reader.ReadInt32();
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                // Gore || Dusts || Gore && Dusts
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

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }

            else
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Nut>(), Main.rand.Next(25, 29));
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}