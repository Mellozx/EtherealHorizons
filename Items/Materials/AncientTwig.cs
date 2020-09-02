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
            item.width = 26;
            item.height = 28;
            item.maxStack = 999;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;
        }

    
        
    }
}