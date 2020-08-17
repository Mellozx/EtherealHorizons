using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Critters.Forest
{
	public class Beaver : ModNPC
	{
		public override string Texture => EtherealUtilities.PlaceholderTexture;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beaver");
		}
		
		public override void SetDefaults()
		{
			npc.friendly = true;
			npc.lavaImmune = false;
			npc.width = 20;
			npc.height = 20;
			npc.lifeMax = 20;
			npc.damage = 0;
			npc.defense = 0;
			npc.aiStyle = 7;
            aiType = NPCID.Squirrel;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.3f;
        }
	}
}