using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
    public class AwakeCheeks : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks");
        }

        public override void SetDefaults()
        {
            npc.buffImmune[BuffID.Confused] = true;
            npc.boss = true;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lavaImmune = true;
            npc.knockBackResist = 0f;
            npc.width = 40;
            npc.height = 40;
            npc.lifeMax = 2400;
            npc.damage = 20;
            npc.defense = 6;
            npc.aiStyle = -1;
            aiType = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            Mod musicMod = ModLoader.GetMod("EtherealHorizonsMusic");
            if (musicMod != null)
            {
                music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/AwakeCheeks");
            }
            else
            {
                music = MusicID.Boss1;
            }
            musicPriority = MusicPriority.BossMedium;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;

            EtherealWorld.downedAwakeCheeks = true;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }

        public override void NPCLoot()
        {
            switch (Main.rand.Next(1, 3))
            {
                case 1:
                    //Item.NewItem(npc.getRect(), ModContent.ItemType<CheekCrusher>());
                    break;
                case 2:
                    //Item.NewItem(npc.getRect(), ModContent.ItemType<Vonut>());
                    break;
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {

            }
        }
    }
}
