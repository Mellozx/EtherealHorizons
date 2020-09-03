using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
    public class Nut : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.White;
        }
    }
}
