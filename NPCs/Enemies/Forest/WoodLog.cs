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
			npc.lavaImmune = false;
            npc.lifeMax = 20;
            npc.damage = 4;
            npc.defense = 0;
            npc.width = 30;
            npc.height = 10;
            npc.aiStyle = -1; 
			npc.knockBackResist = 0.5f;
            aiType = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void FindFrame(int frameHeight)
        {
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
                
            }

            else if (State == Hide)
            {

            }
        }
    }
}