using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
    public class WildlifeFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wildlife Fragment");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.sellPrice(silver: 30);
            item.rare = ItemRarityID.Blue;
        }
    }
}
