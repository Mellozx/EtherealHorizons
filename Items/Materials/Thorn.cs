using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace EtherealHorizons.Items.Materials
{
    public class Thorn : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 5);
        }
    }
}
