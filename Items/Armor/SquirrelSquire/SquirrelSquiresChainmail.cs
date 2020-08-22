using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.SquirrelSquire
{
    public class SquirrelSquiresChainmail : ModItem
    {
        public override string Texture => EtherealHorizons.PlaceholderTexture;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squirrel Squire's Chainmail");
        }

		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 22;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.White;
			item.defense = 3;
		}
    }
}