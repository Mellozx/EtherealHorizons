using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class AncientTwig : ModItem
    {
<<<<<<< HEAD
        public override string Texture => "EtherealHorizons/PLACEHOLDER";

=======
>>>>>>> c22045657b96d74129264b856931c21e5edbbf96
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Twig");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 10;
            item.height = 10;
            item.maxStack = 999;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 5);
        }
    }
}