using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Critters.Forest
{
	public class Fox : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fox");
        }

        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.lifeMax = 20;
            npc.defense = 0;
            npc.aiStyle = 7;
            npc.width = 20;
            npc.height = 20;
            aiType = NPCID.Squirrel;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FoxGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FoxGore2"));
            }
        }
    }
}