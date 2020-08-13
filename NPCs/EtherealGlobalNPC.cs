using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs
{
	public class EtherealGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Squirrel || npc.type == NPCID.SquirrelGold || npc.type == NPCID.SquirrelRed)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Nut>(), Main.rand.Next(2, 4));
            }
            if (npc.type == 69 || npc.type == 508 || npc.type == 509)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<AntlionChitin>(), Main.rand.Next(1, 3));
            }
	        if (npc.type == mod.NPCType("StalkingMushroom"))
            {
                Item.NewItem(npc.getRect(), ItemID.Mushroom, Main.rand.Next(1, 3));
                if(Main.rand.Next(100) < 5) // a 5 in 100 chance
                    {
                    Item.NewItem(npc.getRect(), mod.ItemType("Mushbat"), Main.rand.Next(5, 8));
                    }
            }
            if (npc.type == mod.NPCType("SmallTreeEnt"))
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<AncientTwig>(), Main.rand.Next(1, 3));
            }
        }
    }
}
