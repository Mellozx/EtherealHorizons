using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class AdventurersSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Sword");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.damage = 7;
            item.knockBack = 1f;
            item.useTime = 22;
            item.useAnimation = 22;
            item.width = 28;
            item.height = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.White;
        }
    }
}