using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Materials
{

	public class Thorn : ModItem 
	{
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 22;
            item.maxStack = 999;
            item.rare = ItemRarityID.White;
            item.value = (Item.sellPrice(0, 0, 0, 25));
        }
    }	
}
