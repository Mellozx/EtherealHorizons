using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class NatureWarhammer : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Nature's Warhammer");
		}

		public override void SetDefaults() 
		{
			item.damage = 19;
			item.melee = true;
			item.width = 32;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4f;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
		}
	}
}