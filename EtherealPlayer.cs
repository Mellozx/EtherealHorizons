using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons
{
	public class EtherealPlayer : ModPlayer
    {
        public bool gluttonAmulet;

        public override void ResetEffects()
        {
            gluttonAmulet = false;
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            if (gluttonAmulet)
            {
                healValue = (int)(healValue * 1.30f);
            }
        }
    }
}