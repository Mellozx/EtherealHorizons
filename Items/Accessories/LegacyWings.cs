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
            Tooltip.SetDefault("The wings of a legendary beast" + "\nAllows flight and slow fall");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 80);
            item.rare = ItemRarityID.Blue;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 18;
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
