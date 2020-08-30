using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Legs)]
	public class OldenGreaves : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Olden Greaves");
		}

		public override void SetDefaults() 
		{
			item.width = 22;
			item.height = 16;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Blue;
			item.defense = 5;
		}
	}
}