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
            item.width = 18;
            item.height = 22;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;

            item.value = 1000;
            item.rare = ItemRarityID.Blue;
        }

    
        
    }
}