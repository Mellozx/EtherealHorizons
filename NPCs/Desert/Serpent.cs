using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using EtherealHorizons.Items.Placeables.Banners;

namespace EtherealHorizons.NPCs.Desert
{
    public class Serpent : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Serpent");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 26;
            npc.damage = 10;
            npc.defense = 1;
            npc.lifeMax = 30;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.sellPrice(copper: 20);
            npc.knockBackResist = 0.80f;
            npc.aiStyle = 3;
            aiType = NPCID.GoblinScout;
            banner = npc.type;
            bannerItem = ModContent.ItemType<SerpentBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDayDesert.Chance * 0.2f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SerpentGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SerpentGore2"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SerpentGore3"));
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
    }
}
