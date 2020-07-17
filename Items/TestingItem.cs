using EtherealHorizons.Tiles.Flowers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items
{
	public class TestingItem : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            // Use this for any testing purpose!
            DisplayName.SetDefault("Coders Tool");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(platinum: 69);
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<OrchidTile>();
        }
    }
}