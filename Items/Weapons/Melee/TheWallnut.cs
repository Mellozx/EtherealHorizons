using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class TheWallnut : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Wallnut");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
			item.useAnimation = 40;
			item.useTime = 40;
			item.damage = 8;
            item.knockBack = 4f;
            item.shootSpeed = 10f;
			item.UseSound = SoundID.Item1;
			item.rare = ItemRarityID.White;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(copper: 30);
        }
    }
}