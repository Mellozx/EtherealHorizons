using EtherealHorizons.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class DustiliteShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dustilite Shard");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.width = 14;
            item.height = 18;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 3);
            item.useAnimation = 20;
			item.useTime = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<DustiliteOreTile>();
        }
    }
}