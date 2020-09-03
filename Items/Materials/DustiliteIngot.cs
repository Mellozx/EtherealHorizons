using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
    public class DustiliteIngot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dustilite Ingot");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.value = Item.sellPrice(silver: 30);
            item.rare = ItemRarityID.Blue;
        }
    }
}
