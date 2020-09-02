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

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.lifeMax = 10000;
            npc.damage = 36;
            npc.defense = 16;
            npc.width = 50;
            npc.height = 50;
            npc.knockBackResist = 0f;
            npc.value = Item.sellPrice(gold: 10);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.Boss2;
            musicPriority = MusicPriority.BossMedium;
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
                // Gore shit
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
            // Loot shit
        }

        public override void AI()
        {
            Target();
            
            // First Phase / State
            if (npc.ai[0] == 0f)
            {
                if (npc.ai[1] == 0f) 
                {
                    // Yes
                }

                else if (npc.ai[1] == 1f) // Magic Clocks Spawn
                {
                    
                }
            }
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
