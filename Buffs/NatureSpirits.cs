using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Buffs
{
    public class NatureSpirits : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Nature Spirits");
			Description.SetDefault("They will protect you, even without some sort of offense");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.statDefense += 4;
            player.lifeRegen += 1;
		}
	}
}
