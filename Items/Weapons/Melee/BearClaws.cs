using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class BearClaws : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bear Claws");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;

            item.width = 20;
            item.height = 20;

            item.useTime = 9;
            item.useAnimation = 9;
            item.damage = 11;

            item.knockBack = 3f;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 30);
        }
    }
}