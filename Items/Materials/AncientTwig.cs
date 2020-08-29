using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class AncientTwig : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Twig");
		}
		
		public override void SetDefaults()
		{
			item.material = true;
			item.width = 16;
			item.height = 16;
			item.rare = ItemRarityID.Blue; // Post KS
			item.value = Item.sellPrice(silver: 20); // Platinum bar is 18
		}
	}
}