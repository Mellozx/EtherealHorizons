using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons
{
	public class EtherealPlayer : ModPlayer
    {
        public bool gluttonAmulet;
        public float ScreenRandom;
        public float ScreenRandomDecrease;
        Vector2 ScreenAdd;

        public static bool ZoneForest(Player player)
        {
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert && !player.ZoneGlowshroom && !player.ZoneMeteor && player.ZoneOverworldHeight;
        }

        public override void ResetEffects()
        {
            gluttonAmulet = false;
        }

        // Shake effect
        public void StartScreenShake(float ScreenPosRandomizer, float ScreenPosRandomizerDecrease = 1)
        {
            ScreenRandom = ScreenPosRandomizer; // 'Intensity' of the shakes
            ScreenRandomDecrease = Math.Abs(ScreenPosRandomizerDecrease); // 'Speed the shake ends'
        }

        public override void ModifyScreenPosition()
        {
            if (ScreenRandom > 0)
            {
                if (!(Main.gamePaused || Main.gameInactive))
                {
                    ScreenRandom -= ScreenRandomDecrease;
                    ScreenAdd.X = Main.rand.NextFloat(ScreenRandom);
                    ScreenAdd.Y = Main.rand.NextFloat(ScreenRandom);
                }
                Main.screenPosition += ScreenAdd;
            }
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