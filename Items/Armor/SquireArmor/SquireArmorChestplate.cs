using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.SquireArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class SquireArmorChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squire Chestplate");
            Tooltip.SetDefault("3% increased damage.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.defense = 3;
            item.value = 25000;
        }


        public override void UpdateArmorSet(Player player)
        {
            player.allDamage += 0.3f;
        }
    }
}
