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
            DisplayName.SetDefault("Wild Warrior Chestplate");
			Tooltip.SetDefault("Increases critical strike chance by 4%");
		}

		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 22;
			item.value = Item.sellPrice(silver: 50);
			item.rare = 1;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player) 
		{
            player.meleeCrit += 4;
            player.rangedCrit += 4;
            player.magicCrit += 4;
            player.thrownCrit += 4;
            
            //don't feel like adding mod support for modded classes right now
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
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