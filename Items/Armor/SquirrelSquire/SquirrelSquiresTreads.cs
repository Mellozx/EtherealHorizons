using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.SquirrelSquire
{
    public class SquirrelSquiresTreads : ModItem
    {
		public override string Texture => EtherealHorizons.PlaceholderTexture;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squirrel Squire's Treads");
        }

		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 22;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.White;
			item.defense = 1;
		}
    }
}