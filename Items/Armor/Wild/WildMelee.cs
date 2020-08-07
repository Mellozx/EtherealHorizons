using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Head)]
	public class WildMelee : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Wild Warrior Horned Greathelm");
			Tooltip.SetDefault("Increases melee damage by 9%");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 22;
			item.value = Item.sellPrice(silver: 30);
			item.rare = 1;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<WildGarb>() && legs.type == ItemType<WildBoots>();
		}
		
		public override void UpdateEquip(Player player) 
		{
            player.meleeDamage += 0.09f;
		}

		//set bonus
		public override void UpdateArmorSet(Player player) 
		{
            player.setBonus = "When under half health, nature spirits will protect you";
            var modPlayer = player.GetModPlayer<EtherealPlayer>();
            modPlayer.natureSpirit = true;
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}