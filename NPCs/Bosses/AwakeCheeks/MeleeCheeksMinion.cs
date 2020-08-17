using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
	public class MeleeCheeksMinion : ModNPC
	{
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior Squirrel");
        }

        public override void SetDefaults()
        {
            npc.friendly = false;
            npc.lifeMax = 50;
            npc.damage = 10;
            npc.defense = 2;
            npc.width = 20;
            npc.height = 20;
            npc.aiStyle = 3;
            aiType = NPCID.Crawdad; 
        }
    }
}