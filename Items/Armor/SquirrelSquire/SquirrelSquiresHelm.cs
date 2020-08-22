using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.SquirrelSquire
{
    public class SquirrelSquiresHelm : ModItem
    {
        public override string Texture => EtherealHorizons.PlaceholderTexture;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squirrel Squire's Helm");
        }

		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 22;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.White;
			item.defense = 1;
		}
    }
}