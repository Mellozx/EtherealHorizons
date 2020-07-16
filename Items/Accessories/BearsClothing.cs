using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Accessories
{
	public class BearsClothing : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bear's Clothing");
            Tooltip.SetDefault("Reduces damage taken by 3%" + "\n4% increased melee damage");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 40);
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<EtherealPlayer>().bearsClothing = true;
            player.endurance += 0.3f;
            player.meleeDamage += 0.4f;
        }
    }
}
