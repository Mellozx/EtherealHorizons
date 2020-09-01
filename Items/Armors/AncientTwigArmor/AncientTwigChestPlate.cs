using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armors.AncientTwigArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class AncientTwigChestPlate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ancient Twig Chestplate");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000; //10 silver
			item.rare = ItemRarityID.Green;
			item.defense = 6;
		}

       // i didnt add any special effects to the chestplate since i was unsure you could add anything below




		    public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AncientTwig",25);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}