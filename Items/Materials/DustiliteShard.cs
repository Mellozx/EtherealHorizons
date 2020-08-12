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
            item.width = 28;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 3);
        }
    }
}