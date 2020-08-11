using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

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
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
            item.scale = 1.1f;
		}
	}
}