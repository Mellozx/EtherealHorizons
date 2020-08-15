using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Forest
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
            npc.lavaImmune = false;
            npc.width = 20;
            npc.height = 20;
            npc.aiStyle = NPCID.Bird;
            aiType = NPCID.Bird;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.2f;
        }
    }
}