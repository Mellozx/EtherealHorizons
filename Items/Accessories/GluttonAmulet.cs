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
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            var modPlayer = player.GetModPlayer<EtherealPlayer>();
            modPlayer.gluttonAmulet = true;
        }
    }
}