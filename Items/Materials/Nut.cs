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
            item.material = true;

            item.width = 8;
            item.height = 8;

            item.maxStack = 999;

            item.rare = ItemRarityID.White;

            item.value = Item.sellPrice(copper: 15);
        }
    }
}