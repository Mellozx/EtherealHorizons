
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace EtherealHorizons.NPCs
{
    public class BigTreeEnt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BigTreeEnt");
            Main.npcFrameCount[npc.type] = 26;
        }

        public override void SetDefaults()
        {

            npc.noTileCollide = false;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.lifeMax = 200;
            npc.damage = 36;
            npc.defense = 16;
            npc.width = 90;
            npc.height = 90;
            npc.knockBackResist = 0f;
            npc.value = Item.sellPrice(copper: 1);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = -1;
        }

        public override void FindFrame(int frameHeight)
        {
            int FrameMax = npc.ai[0] == 0f ? 18 : 26;

            npc.spriteDirection = npc.direction;
            if (npc.frameCounter++ > 4) //frames per second
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;

            }

            if (npc.frame.Y >= frameHeight * FrameMax)
            {
                npc.frame.Y = 0;
                return;
            }


        }

        int Timer;
        public override void AI()
        {
            // Npc.ai[] uses 
            // Npc.ai[0] for states 
            //Npc.ai[1] used for timers

            Timer++;
            if (Timer > 30)
            {
                Main.PlaySound(SoundID.DD2_SkeletonHurt);
                Timer = 0;
            }

            Player player = Main.player[npc.target]; // declare player

            if (npc.ai[0] == 0f)
            {
                npc.TargetClosest(true);

                if (player.position.X + 4 > npc.position.X)// checks if the player is left or right 
                {
                    npc.velocity.X = 1.7f; // npc movement speed right 

                }
                else if (player.position.X - -4 < npc.position.X)
                {
                    npc.velocity.X = -1.7f; // npc movement speed left 
                }
                else
                {
                    npc.velocity = Vector2.Zero;

                }

                npc.ai[1]++;

                if (player.WithinRange(npc.Center, 16f * 6f) && npc.HasValidTarget && npc.ai[1] >= 300)// checks if the player is 6 tiles away from the enemy 
                {
                    npc.ai[1] = 0f; // reset timer
                    npc.ai[0] = 1f; // Used for States
                    npc.netUpdate = true; //syncs the npc 


                }
            }
            else if (npc.ai[0] == 1f)
            {
                npc.TargetClosest(false);
                npc.velocity = Vector2.Zero;
                if (npc.frame.Y >= 25) //checks the current amount of frames 
                {
                    Main.NewText(string.Join(", ", npc.ai));
                    if (player.velocity.Y == 0f)
                    {
                        player.Hurt(null, npc.damage / 2, npc.direction);

                    }
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                }
            }

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.3f;
        }
    }
}
