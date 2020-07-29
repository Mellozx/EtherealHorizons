using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Head)]
	public class WildRanged : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Ancient spirits are said to protect the wearer of this armor"
			+ "\nIncreased ranged damage by 8%");
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 20;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = 2;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<WildGarb>() && legs.type == ItemType<WildBoots>();
		}
		
		public override void UpdateEquip(Player player) 
		{
			player.rangedDamage += 0.05f;
		}

		//set bonus
		public override void UpdateArmorSet(Player player) 
		{
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}