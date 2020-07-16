using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.TreasureBags
{
	public class AwakeCheeksBag : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks Bag");
            Tooltip.SetDefault("${CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.expert = true;
            item.consumable = true;
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.Expert;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();

            player.QuickSpawnItem(ModContent.ItemType<Nut>(), Main.rand.Next(25, 29));
        }
    }   
}