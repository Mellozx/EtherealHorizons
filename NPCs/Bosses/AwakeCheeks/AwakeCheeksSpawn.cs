using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks 
{
	public class AwakeCheeksSpawn : ModNPC
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sleeping Giant Squirrel");
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.width = 20;
            npc.height = 20;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 4;
            npc.lifeMax = 500;
            npc.npcSlots = 0.5f;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 900;
        }

        public override void AI()
        {
            npc.velocity.Y = 6f;
        }

        public override bool CheckDead()
        {
            return base.CheckDead();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<AwakeCheeks>()) && !NPC.AnyNPCs(ModContent.NPCType<AwakeCheeksSpawn>()) && !spawnInfo.playerSafe)
            {
                if (NPC.downedSlimeKing && !EtherealWorld.downedAwakeCheeks)
                {
                    return SpawnCondition.OverworldDay.Chance * 1f;
                }
                return SpawnCondition.OverworldDay.Chance * (Main.hardMode ? 0.10f : 0.5f);
            }
            return 0f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<AwakeCheeks>(), 0, 0f, 0f, 0f, 0f);
            }
        }
    }
}
