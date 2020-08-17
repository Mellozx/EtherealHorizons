using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.WildWarrior
{
	[AutoloadEquip(EquipType.Head)]
	public class WildWarriorHelmet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Wild Warrior Helmet");
			Tooltip.SetDefault("Increases melee damage by 9%");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 22;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<WildWarriorGarb>() && legs.type == ModContent.ItemType<WildWarriorGreaves>();
		}
		
		public override void UpdateEquip(Player player) 
		{
            player.meleeDamage += 0.09f;
		}

		public override void UpdateArmorSet(Player player) 
		{
            player.setBonus = "When under half health, nature spirits will protect you";
			player.GetModPlayer<EtherealPlayer>().wildWarriorSet = true;
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}