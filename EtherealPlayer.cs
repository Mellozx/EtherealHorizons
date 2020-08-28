using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons
{
	public class EtherealPlayer : ModPlayer
    {
        // Accessories
        public bool gluttonAmulet;
        public bool evergreenAegis;
        public bool theMagnolia;
        // Armor sets
        public bool oldenSet;
        public bool wildWarriorSet;

        public static bool ZoneForest(Player player)
        {
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert && !player.ZoneGlowshroom && !player.ZoneMeteor && player.ZoneOverworldHeight;
        }

        public override void ResetEffects()
        {
            // Accessories
            gluttonAmulet = false;
            evergreenAegis = false;
            theMagnolia = false;
            // Armor sets
            oldenSet = false;
            wildWarriorSet = false;
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            if (gluttonAmulet)
            {
                healValue = (int)(healValue * 1.20f);
            }
        }

        public override void UpdateLifeRegen()
        {
            if (theMagnolia)
            {
                // 1 HP per second
                player.lifeRegen += 2;
            }
        }
    } 
}