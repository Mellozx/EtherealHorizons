using EtherealHorizons.Events;
using EtherealHorizons.Items.Materials;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs
{
    public class EtherealGlobalNPC : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            ModEventLoader.EditSpawnPool(pool, in spawnInfo);
        }

        public override void EditSpawnRange(Player player, ref int spawnRangeX, ref int spawnRangeY, ref int safeRangeX, ref int safeRangeY)
        {
            ModEventLoader.EditSpawnRange(player, ref spawnRangeX, ref spawnRangeY, ref safeRangeX, ref safeRangeY);
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            ModEventLoader.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
        }

        public override bool PreNPCLoot(NPC npc)
        {
            ModEventLoader.OnKillNPC(npc); // maybe this should go in another hook
            return base.PreNPCLoot(npc);
        }

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Squirrel)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Nut>(), Main.rand.Next(1, 3));
            }
        }
    }
}