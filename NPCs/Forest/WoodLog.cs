using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Forest
{
    public class WoodLog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wood Log");
        }

        public override void SetDefaults()
        {
            npc.width = 48;
            npc.height = 33;
            npc.damage = 10;
            npc.lifeMax = 200;
            npc.aiStyle = -1;
            aiType = -1;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Player target = this.target;
            Vector2 totarget = npc.Center;
            if (target.active && !(target.dead || target.ghost))
            {
                totarget = target.MountedCenter - npc.Center;
            }
            npc.velocity.X = MathHelper.SmoothStep(npc.velocity.X, 2 * Math.Sign(totarget.X), 0.1f);

            if (npc.ai[1] > 0)
                npc.ai[1]--;
            else
            {
                if (npc.collideY && HoelBelowe() || (npc.collideX && npc.position.X == npc.oldPosition.X))
                {
                    npc.velocity.Y = Main.rand.NextFloat(-5, -10);
                    npc.ai[1] = 90;
                    npc.netUpdate = true;
                }
            }

            npc.spriteDirection = npc.direction;
            Collision.StepUp(ref npc.position, ref npc.velocity, npc.width, npc.height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false, 1);
        }
        private bool HoelBelowe()
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
        Player target => Main.player[npc.target];

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(2, 5));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Active? SpawnCondition.OverworldDay.Chance * 0.2f : 0f;
        }
    }
}
