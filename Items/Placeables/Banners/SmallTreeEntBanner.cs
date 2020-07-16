using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Tiles.Banners;

namespace EtherealHorizons.Items.Placeables.Banners
{
	public class SmallTreeEntBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Tree Ent Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Small Tree Ent");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useTurn = true;
            item.consumable = true;

            item.width = 10;
            item.height = 24;
                
            item.maxStack = 99;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Blue;

            item.value = Item.sellPrice(silver: 10);

            item.createTile = ModContent.TileType<SmallTreeEntBannerTile>();

            item.placeStyle = 0;
        }
    }
}