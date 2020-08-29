using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
	public class Nut : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nut");
		}
		
		public override void SetDefaults()
		{
			item.material = true;
			item.maxStack = 999;
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.White;
		}
	}
}