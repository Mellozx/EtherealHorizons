using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
    public class Nut : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 30);
        }
    }
}