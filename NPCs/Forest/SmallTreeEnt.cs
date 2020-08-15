using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Placeables.Banners;

namespace EtherealHorizons.NPCs.Forest
{
    public class SmallTreeEnt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Ent");
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
            npc.aiStyle = 3;
            aiType = NPCID.Crawdad;
            npc.knockBackResist = 1f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<SmallTreeEntBanner>();
            npc.value = Item.sellPrice(copper: 40);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
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
            if (EtherealWorld.downedAwakeCheeks)
            {
                return SpawnCondition.OverworldDay.Chance * 0.2f;
            }
            else
            {
                return 0f;
            }
        }
    }
}