using EtherealHorizons.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EtherealHorizons
{
	public class EtherealPlayer : ModPlayer
    {
        // Armor Sets
        public bool wildWarriorHelmet;

        // Accessories
        public bool gluttonAmulet;
        public bool bearsClothing;

        public override void ResetEffects()
        {
            gluttonAmulet = false;
            bearsClothing = false;
            wildWarriorHelmet = false;
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            if (gluttonAmulet)
            {
                healValue = (int)(healValue * 1.30f);
            }
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (wildWarriorHelmet)
            {
                if (item.ranged)
                {
                    if (Main.rand.NextBool(4))
                    {
                        
                    }
                }
            }
            return true;
        }
    }
}