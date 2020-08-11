using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Forest
{
    public class SmallTreeEnt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Ent");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lavaImmune = false;

            npc.buffImmune[BuffID.Confused] = true;

            npc.width = 38;
            npc.height = 38;

            npc.lifeMax = 80;
            npc.damage = 8;
            npc.defense = 2;
            npc.aiStyle = 3;
            aiType = NPCID.GoblinScout;
            npc.friendly = false;

            npc.knockBackResist = 1f;

            npc.value = Item.sellPrice(copper: 40);

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (npc.frameCounter++ > 4)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 9)
            {
                npc.frame.Y = 0;
                return;
            }
        }
  }
}