using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Forest
{
    public class WoodLog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wood Log");
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.width = 48;
            npc.height = 33;
            npc.damage = 10;
            npc.lifeMax = 50;
            npc.defense = 2;
            npc.knockBackResist = 2f;
            npc.value = Item.sellPrice(copper: 20);
            npc.aiStyle = 3;
            aiType = NPCID.Crawdad;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            banner = npc.type;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(2, 5));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.2f;
        }
    }
}
