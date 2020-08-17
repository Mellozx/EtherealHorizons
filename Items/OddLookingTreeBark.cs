using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items
{
	public class OddLookingTreeBark : ModItem
	{
		public override string Texture => "EtherealHorizons/PLACEHOLDER";
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Odd Looking Tree Bark");
			Tooltip.SetDefault("What is this? Well, you'll find it out but not on this demo haha");
		}
		
		public override void SetDefaults()
		{
			item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
		}		
	}
}
