using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.NPCs.Enemies.Forest
{
	public class WoodLog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wood Log");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lifeMax = 20;
            npc.damage = 4;
            npc.defense = 0;
            npc.width = 30;
            npc.height = 10;
            npc.aiStyle = 3; // Fighter
            aiType = -1; // Unique for this NPC (?)
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void FindFrame(int frameHeight)
        {
            if (State <= Fight)
            {
                npc.spriteDirection = npc.direction;
                if (++npc.frameCounter > 4)
                {
                    npc.frameCounter = 0;
                    npc.frame.Y += frameHeight;
                }
                if (npc.frameCounter >= frameHeight * Main.npcFrameCount[npc.type])
                {
                    npc.frame.Y = 0;
                    return;
                }
            }
            else
            {
                npc.frame.Y = 0;
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(2, 5));

            if (NPC.downedSlimeKing) // Must change to Cheeks once it is done
            {
                if (Main.rand.NextBool(2))
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<AncientTwig>());
                }
            }
        }

        public float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        public float AttackTimer
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        public const float Fight = 0f;
        public const float Hide = 1f;

        public override void AI()
        {
            if (State == Fight)
            {
                AttackTimer++; // No need to sync this because it is npc.ai and it is auto synced :yaby:
                if (AttackTimer >= 480f)
                {
                    State = Hide;
                    AttackTimer = 0f;
                    npc.netUpdate = true;
                }
            }

            else if (State == Hide)
            {
                npc.TargetClosest(false);
                npc.velocity = Vector2.Zero;

                AttackTimer++;
                if (AttackTimer >= 240f)
                {
                    State = Fight;
                    AttackTimer = 0f;
                    npc.netUpdate = true;
                } 
            }
        }
    }
}