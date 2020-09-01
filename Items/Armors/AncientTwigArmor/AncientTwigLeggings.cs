using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace EtherealHorizons.Items.Armors.AncientTwigArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class AncientTwigLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Twig Leggings");
			Tooltip.SetDefault("");

		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000; // 10 silver
			item.rare = ItemRarityID.Green;
			item.defense = 5;
		}

		/* public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.02f;
		}
		*/
		//im unsure whether to add this or not so its up to you

		    public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AncientTwig",15);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}