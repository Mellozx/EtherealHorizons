using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EtherealHorizons.Items.Armor.WildWarrior
{
	[AutoloadEquip(EquipType.Body)]
	public class WildWarriorGarb : ModItem
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
			item.rare = ItemRarityID.Blue;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) 
		{
            player.meleeCrit += 4;
            player.rangedCrit += 4;
            player.magicCrit += 4;
            player.thrownCrit += 4;
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 6);
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