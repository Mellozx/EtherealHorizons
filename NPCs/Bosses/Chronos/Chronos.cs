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

        public override void BossLoot(ref string name, ref int potionType)
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
    }
}
