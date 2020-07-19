using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Accessories
{
    public class GluttonAmulet : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glutton Amulet");
            Tooltip.SetDefault("The glutton of the Forest's Amulet is in your hands" + "\nReduces damage taken by 7%" + "\n30% increased healing potions effect");
        }

        public override void SetDefaults()
        {
            item.expert = true;
            item.accessory = true;
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 15, 0);
            item.rare = ItemRarityID.Expert;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<EtherealPlayer>().gluttonAmulet = true;
            player.endurance += 0.7f;
        }
    }
}