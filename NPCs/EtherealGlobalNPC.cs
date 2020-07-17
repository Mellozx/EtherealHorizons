using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.NPCs
{
    public class EtherealGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Squirrel)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Nut>(), Main.rand.Next(1, 3));
            }
        }
    }
}