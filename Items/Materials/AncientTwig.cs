using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
    public class AncientTwig : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Twig");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;

            item.value = 1000;
            item.rare = ItemRarityID.Blue;
        }

    
        
    }
}