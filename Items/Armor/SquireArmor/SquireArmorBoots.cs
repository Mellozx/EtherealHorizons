using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armors.SquireArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SquireArmorBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squire Boots");
			Tooltip.SetDefault("5% increased max run speed.");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.defense = 3;
			item.value = 25000;

		}

		public override void UpdateArmorSet(Player player)
		{
			player.maxRunSpeed += 0.5f;
		}
	}
}