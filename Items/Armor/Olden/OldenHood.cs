using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Head)]
	public class OldenHood : ModItem
	{
		public override void SetStaticDefaults()
                {
			DisplayName.SetDefault("Olden Hood");
			Tooltip.SetDefault("Increased Magic Damage");
		}

		public override void SetDefaults() 
                {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(silver: 40); // 10 silver
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
                {
			return body.type == ModContent.ItemType<OldenMantle>() && legs.type == ModContent.ItemType<OldenLeggings>();
		}

		public override void UpdateArmorSet(Player player)
                {
			player.magicDamage -= 0.1f; // higher magic damage 
			player.statManaMax2 += 1; // more mana kek, could be removed
			
			
		}

	        public override void AddRecipes() 
                {
                    var recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 3);
	            recipe.AddTile(TileID.WorkBenches);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
		}
	}
}
