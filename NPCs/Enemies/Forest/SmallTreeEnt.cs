using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using System.IO;

namespace EtherealHorizons.NPCs.Enemies.Forest
{
	public class SmallTreeEnt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Tree Ent");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.lavaImmune = false;
            npc.friendly = false;

            npc.buffImmune[BuffID.Confused] = true;

            npc.width = 38;
            npc.height = 38;

            npc.lifeMax = 80;
            npc.damage = 8;
            npc.defense = 2;
            npc.aiStyle = -1;

            npc.knockBackResist = 1f;

            npc.value = Item.sellPrice(copper: 40);

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;

            // banner = ModContent.NPCType<SmallTreeEnt>();
            // bannerItem = ModContent.ItemType<SmallTreeEntBanner>();
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (npc.frameCounter++ > 4)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 9)
            {
                npc.frame.Y = 0;
                return;
            }
        }

        public override void AI()
        {
            // TODO - Actual AI
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SmallTreeEntGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SmallTreeEntGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SmallTreeEntGore3"), 1f);

                for (int k = 0; k < 10; k++)
                {
                    Dust.NewDust(npc.position, 0, 0, DustID.Grass);
                }
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(3, 5));

            if (Main.rand.NextBool(4))
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<AncientTwig>(), Main.rand.Next(1, 3));
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.3f;
        }
    }
}