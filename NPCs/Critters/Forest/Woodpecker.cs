using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Critters.Forest
{
	public class Woodpecker : ModNPC
    {
		public override string Texture => "EtherealHorizons/PLACEHOLDER";
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Woodpecker");
        }

        public override void SetDefaults()
        {
            npc.friendly = true;    
            npc.width = 20;
            npc.height = 20;
            npc.lifeMax = 10;
            npc.aiStyle = 24;
            npc.defense = 0;
            aiType = NPCID.Bird;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodpeckerGore1"));
            }
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.3f;
        }
    }
}