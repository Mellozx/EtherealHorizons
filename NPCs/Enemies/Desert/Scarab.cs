using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.NPCs.Enemies.Desert
{
    public class Scarab : ModNPC
    {
        public override string Texture => EtherealUtilities.PlaceholderTexture;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scarab");
        }

        public override void SetDefaults()
        {
            npc.lavaImmune = false;
            npc.aiStyle = 3;
            npc.width = 20;
            npc.height = 20;
            npc.lifeMax = 50;
            npc.defense = 2;
            npc.aiStyle = 7;
            aiType = NPCID.Squirrel;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        /* public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/Enemies/Desert/Scarab_Glowmask");
            spriteBatch.Draw(texture, npc.position, Color.White);
        } */
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDayDesert.Chance * 0.3f;
        }
    }
}