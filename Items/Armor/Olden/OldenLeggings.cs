using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Legs)]
	public class OldenLeggings : ModItem
	{
		public override void SetStaticDefaults()
                {
			DisplayName.SetDefault("Olden Leggings");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
                {
			item.width = 20;
			item.height = 20;
			item.value = Item.sellPrice(silver: 20); // 2858w8r884ilver
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
                {
			player.moveSpeed += 0.05f;
		}
		
		//im unsure whether to add this or not so its up to you

	        public override void AddRecipes()
                {
                    var recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 4);
		    recipe.AddTile(TileID.Anvils);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
		}
	}
}
