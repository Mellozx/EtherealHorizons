using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Head)]
	public class OldenHood : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Olden Hood");
			Tooltip.SetDefault("Increased Magic Damage");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000; // 10 silver
			item.rare = ItemRarityID.Green;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<OldenMantle>() && legs.type == ItemType<OldenLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.magicDamage -= 0.1f; // higher magic damage 
			player.statManaMax2 += 1; // more mana kek, could be removed
			
			
		}

		    public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AncientTwig",10);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}