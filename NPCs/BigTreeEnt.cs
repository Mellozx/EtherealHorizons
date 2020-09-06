using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace EtherealHorizons.NPCs
{
    public class BigTreeEnt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Tree Ent");
            Main.npcFrameCount[npc.type] = 26;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.lifeMax = 200;
            npc.damage = 20;
            npc.defense = 4;
            npc.width = 90;
            npc.height = 90;
            npc.knockBackResist = 0f;
			npc.aiStyle = -	1;
			aiType = -1;
            npc.value = Item.sellPrice(silver: 1);
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
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
                return;
            }
        }

        public override void AI()
        {
            Player player = Main.player[npc.target]; 

        }
		
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.1f;
        }
    }
}
