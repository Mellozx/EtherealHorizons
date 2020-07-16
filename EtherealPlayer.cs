using Terraria;
using Terraria.ModLoader;

namespace EtherealHorizons
{
	public class EtherealPlayer : ModPlayer
    {
        public bool gluttonAmulet;
        public bool bearsClothing;

        public override void ResetEffects()
        {
            gluttonAmulet = false;
            bearsClothing = false;
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