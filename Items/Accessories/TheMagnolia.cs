using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Accessories
{
	public class TheMagnolia : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Magnolia");
            Tooltip.SetDefault("Increases your life regen and movement speed"
            + "\nIncreases life regen and move speed even more when at low health");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 1);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<EtherealPlayer>().theMagnolia = true;
            // According to source, most armor sets and accessories use moveSpeed instead of properties such as maxRunSpeed, and accRunSpeed. But we use it anyways because only moveSpeed increased a single mph
            player.moveSpeed += 0.05f;
            player.maxRunSpeed += 0.05f;
            if (player.statLife <= player.statLifeMax2 / 3)
            {
                player.moveSpeed += 0.1f;
                player.maxRunSpeed += 0.1f;
            }
        }
    }
}