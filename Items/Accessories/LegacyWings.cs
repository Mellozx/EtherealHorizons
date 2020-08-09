using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace EtherealHorizons.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class LegacyWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The wings of a legendary beast"
				+ "\nAllows flight and slow fall");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 70;
            item.height = 30;
            item.value = item.value = Item.buyPrice(0, 3, 25, 0);
            item.rare = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 25;
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.2f;
		}
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 5f;
			acceleration *= 2.5f;
		}
    }
}
