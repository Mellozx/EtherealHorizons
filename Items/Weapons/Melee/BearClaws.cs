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
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(silver: 30);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.scale = 1.1f;
		}
	}
}