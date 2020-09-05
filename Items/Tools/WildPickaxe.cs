using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Tools
{
    public class WildPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Pickaxe");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 18;
            item.useAnimation = 18;
            item.pick = 54;
            item.knockBack = 2f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver:0); // ?
        }
    }
}
