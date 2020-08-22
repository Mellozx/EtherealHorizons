using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.BossSummons
{
	public class SquirrelIdol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squirrel Idol");
            Tooltip.SetDefault("Use at a Ancient Shrine to summon Awake Cheeks");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(silver: 50);
        }
    }
}