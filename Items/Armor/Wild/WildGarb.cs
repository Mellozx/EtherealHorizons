using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Body)]
	public class WildGarb : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Ancient spirits are said to protect the wearer of this armor"
			+ "\nIncreased crit chance by 4");
		}

		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = 2;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) 
		{
			player.magicCrit += 4;
			player.meleeCrit += 4;
			player.rangedCrit += 4;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void DrawHands(ref bool drawHands, ref bool drawArms) 
		{
			drawHands = true;
		}
	}
}