using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons.NPCs.Desert
{
    public class Serpent : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
        }
        private Player player;
        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 26;
            npc.damage = 12;
            npc.defense = 4;
            npc.lifeMax = 50;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 50f;
            npc.knockBackResist = 0.80f;
            npc.aiStyle = -1;
            banner = npc.type;
            bannerItem = mod.ItemType("SerpentBanner");
        }
        private int jumpTimer;
        private float speed = 1.25f;

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(jumpTimer);
        }


        public override void ReceiveExtraAI(BinaryReader reader)
        {
            jumpTimer = reader.ReadInt32();
        }
        public override void AI()
        {
            Target();
            npc.TargetClosest(true);

            MoveTowardsPlayerX(speed, 4f);

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
                npc.velocity.Y = Main.rand.Next(-7, -5);
                npc.netUpdate = true;
            }

            if (npc.velocity.Y >= 0f)
            {
                Collision.StepUp(ref npc.position, ref npc.velocity, npc.width, npc.height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false, 1);
            }
            if (Main.rand.NextBool(300))
            {
                float Ppeed = 4f;
                Vector2 pector8 = new Vector2(npc.position.X + (npc.width / 2) - 12, npc.position.Y + (npc.height / 2) - 4);
                if (npc.direction == -1)
                {
                    pector8 = new Vector2(npc.position.X + (npc.width / 2) + 12, npc.position.Y + (npc.height / 2) - 4);
                }
                int pamage = 8;
                int pype = mod.ProjectileType("SerpentSpit");
                Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 17);
                float potation = (float)Math.Atan2(pector8.Y - (player.position.Y + (player.height * 0.5f)), pector8.X - (player.position.X + (player.width * 0.5f)));
                int pew = Projectile.NewProjectile(pector8.X, pector8.Y, (float)((Math.Cos(potation) * Ppeed) * -1), (float)((Math.Sin(potation) * Ppeed) * -1), pype, pamage, 0f, 0);
            }
        }
        public override bool CheckDead()
        {
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Serpent1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Serpent2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Serpent3"), 1f);
            }
            return true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneDesert)
            {
                return 0.25f;
            }
            else
            {
                return 0f;
            }
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
        private void Target()
        {
            player = Main.player[npc.target];
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.velocity.Y != 0)
            {
                npc.frame.Y = 2 * frameHeight;
            }
            else
            {
                if (npc.frameCounter < 10)
                {
                    npc.frame.Y = 0 * frameHeight;
                }
                else if (npc.frameCounter < 20)
                {
                    npc.frame.Y = 1 * frameHeight;
                }
                else if (npc.frameCounter < 30)
                {
                    npc.frame.Y = 2 * frameHeight;
                }
                else if (npc.frameCounter < 40)
                {
                    npc.frame.Y = 3 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextBool(100))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 887, Main.rand.Next(1, 2));
            }
        }
    }
}
