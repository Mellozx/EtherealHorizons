using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
    public class AwakeCheeks : ModNPC
    {
        private Player player;

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

        public float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        public float AttackTimer
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        public const float Sleep = 0f;
        public const float Idle = 1f;

        private int textTimer;
        private int moveTimer;

        public override void AI()
        {
            Target();

            switch (State)
            {
                #region Sleep State
                case Sleep:
                {
                    int textCount = 0;

                    npc.TargetClosest(false); 
                    npc.dontTakeDamage = true; 

                    textTimer++;
                    if (textTimer >= 180 && textCount < 3)
                    {
                        CombatText.NewText(npc.getRect(), Color.Yellow, "Zzz...", false, false);

                        textTimer = 0; 
                        textCount++;
                        npc.netUpdate = true;
                    }
                    else if (textCount >= 3)
                    {
                        textTimer++;
                        switch (textTimer)
                        {
                            case 180:
                                CombatText.NewText(npc.getRect(), Color.Yellow, "Huh, who are you?");
                                break;
                            case 360:
                                CombatText.NewText(npc.getRect(), Color.Yellow, "Who dares to interrupt my rest?");
                                break;
                            case 540: 
                                CombatText.NewText(npc.getRect(), Color.Yellow, "If you proceed, prove me you're worthy at least!");
                                State = Idle;
                                break;
                        }
                        npc.netUpdate = true;
                    } 
                }
                break;
                #endregion
               
                #region Idle State
                case Idle:
                {
                        // Boss Text
                        npc.TargetClosest(true);
                        npc.dontTakeDamage = false;
                }
                break;
                #endregion
            }
        }


        private void Target()
        {
            player = Main.player[npc.target];
        }

        public override void NPCLoot()
        {
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
    }
}
