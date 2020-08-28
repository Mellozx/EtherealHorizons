using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class Mushbat : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Mushbat");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.melee = true;
			item.width = 34;
			item.height = 42;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2f;
			item.value = Item.sellPrice(silver: 2);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
            item.scale = 1.1f;
		}
	}
}