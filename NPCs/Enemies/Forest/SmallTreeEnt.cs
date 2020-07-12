using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;

namespace EtherealHorizons.NPCs.Enemies.Forest
{
	public class SmallTreeEnt : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Ent");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 38;

            npc.lifeMax = 70;

            npc.noGravity = false;
            npc.noTileCollide = false;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.frameCounter++ > 4)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
            }

            if (npc.frame.Y >= frameHeight * 9)
            {
                npc.frame.Y = 0;
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(3, 5));
        }


        public override void AI()
        {
            Target();

            // npc.ai[0] for attacks
            // npc.ai[1] n/A
            // npc.ai[2] for timers
            // npc.ai[3] n/A

            if (npc.ai[0] == 0f)
            {
                if (++npc.ai[2] >= 300f) 
                {
                    npc.ai[0] = 1f; 
                    npc.ai[2] = 0f;
                }
            }

            if (npc.ai[0] == 1f || npc.ai[0] == 1.1f)
            {
                if(npc.ai[0] == 1f)
                {
                    // Placeholder projectile
                    int projectiles = Main.rand.Next(2, 4); // 2 - 3 (4 is excluded)    
                    for (int i = 0; i < projectiles; i++)
                    {

                    }

                    npc.ai[0] = 1.1f; // Flag the projectile was shot
                }

                if (++npc.ai[2] >= 30)
                {
                    npc.ai[0] = 0f;
                    npc.ai[2] = 0f;
                }
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }
    }
}