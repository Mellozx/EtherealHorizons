using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class Thorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn");
		}
		
		public override void SetDefaults()
		{
			item.material = true;
			item.maxStack = 999;
			item.width = 20;
			item.height = 24;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(copper: 23);
		}
	}
}