using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class Leaf : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 10);
        }
    }
}