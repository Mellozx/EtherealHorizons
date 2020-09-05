using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using static Terraria.ModLoader.ModContent;


namespace EtherealHorizons.Items.Armor.SquireArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class SquireArmorHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squire Helmet");
			Tooltip.SetDefault("3% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 8;
			item.height = 20;
			item.defense = 1;
			item.value = 2000;

		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<SquireArmorChestplate>() && legs.type == ItemType<SquireArmorBoots>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.moveSpeed += 0.3f;
			
		}
	}
}
