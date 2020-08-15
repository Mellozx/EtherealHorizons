using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EtherealHorizons.Projectiles.Hostile;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
    public class AwakeCheeks : ModNPC
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";

        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks");
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lavaImmune = true;

            npc.width = 46;
            npc.height = 46;
            npc.lifeMax = 2200;
            npc.damage = 20;
            npc.defense = 4;
            npc.knockBackResist = 0f;

            music = MusicID.Boss2;
            musicPriority = MusicPriority.BossMedium;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {

            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            EtherealWorld.downedAwakeCheeks = true;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }
    }
}