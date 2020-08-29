using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.DuneRaider
{
	public class DuneRaidersHood : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Raider's Hood");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 22;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.White;
			item.defense = 1;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SandBlock, 20);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ModContent.ItemType<DustiliteChunk>(), 4);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}