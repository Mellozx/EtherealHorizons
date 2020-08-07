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
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 22;
			item.value = 0;
			item.rare = 2;
			item.defense = 1;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;  //player make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<WildGarb>() && legs.type == ItemType<WildBoots>();
		}
		
		public override void UpdateEquip(Player player) 
		{
		}

		//set bonus
		public override void UpdateArmorSet(Player player) 
		{
		}

		/*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EquipMaterial>(), 30);
			recipe.AddTile(TileType<ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}