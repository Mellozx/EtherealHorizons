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
			item.damage = 10;
			item.melee = true;
			item.width = 32;
			item.height = 28;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2f;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}