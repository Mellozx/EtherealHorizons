using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.NPCs.Enemies.Forest
{
    public class WoodLog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wood Log");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.width = 48;
            npc.height = 33;
            npc.damage = 10;
            npc.lifeMax = 50;
            npc.defense = 2;
            npc.knockBackResist = 0.70f;
            npc.value = Item.sellPrice(copper: 20);
            npc.aiStyle = 3;
            aiType = NPCID.GoblinScout;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            banner = npc.type;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(2, 5));
            if (EtherealWorld.downedAwakeCheeks)
            {
                if (Main.rand.NextBool(2))
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<AncientTwig>());
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodLogGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodLogGore2"));
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (npc.frameCounter++ > 4)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
                return;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.2f;
        }
    }
}
