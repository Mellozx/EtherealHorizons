using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Items.Accessories
{
	public class GluttonAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glutton Amulet");
             Tooltip.SetDefault("The glutton of the forest's amulet is in your hands."
            + "\nIncreased healing from potions by 30% and increased damage reduction by 8%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(0, 1, 15, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            var modPlayer = player.GetModPlayer<EtherealPlayer>();
            modPlayer.gluttonAmulet = true;
            player.endurance += 0.08f;
        }
    }
}