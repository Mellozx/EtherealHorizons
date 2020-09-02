using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace EtherealHorizons.NPCs.Bosses.Chronos
{
    public class Chronos : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chronos");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)npc.lifeMax * 0.6f * bossLifeScale;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0) 
            {
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;

            if (Main.netMode == NetmodeID.Server)
            {
                // EtherealWorld.downedChronos = true;
                NetMessage.SendData(MessageID.WorldData);
            }
        }

        public override void NPCLoot()
        {
        }

        public override void AI()
        {
            Target();
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        public override bool DrawHealthBar (byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f
            return null;
        }
    }
}
