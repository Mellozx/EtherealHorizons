using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Enums;
using Microsoft.Xna.Framework;
using EtherealHorizons.NPCs.Enemies.Forest;

namespace EtherealHorizons.Events
{
	public class ForestFrenzyEvent
    {
        public static int[] forestInvaders =
        {
            ModContent.NPCType<SmallTreeEnt>(),
            ModContent.NPCType<WoodLog>(),
            ModContent.NPCType<StalkingMushroom>()
        };
    }
}