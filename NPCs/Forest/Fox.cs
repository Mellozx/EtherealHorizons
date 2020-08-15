using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Forest
{
	public class Fox : ModNPC
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fox");
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.width = 20;
            npc.height = 20;
            npc.aiStyle = NPCID.Bunny;
            aiType = NPCID.Bunny;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.2f;
        }
    }
}