using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class AncientTwig : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Twig");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.width = 24;
            item.height = 26;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(copper: 80);
        }
    }
}