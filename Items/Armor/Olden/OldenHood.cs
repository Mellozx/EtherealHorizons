using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Head)]
	public class OldenHood : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Olden Hood");
			Tooltip.SetDefault("Increases max minions by 1 and minion damage by 10%");
		}

		public override void SetDefaults() 
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<OldenMantle>();
		}
		
		public override void UpdateEquip(Player player) 
		{
			player.minionDamage += 0.06f;
			player.maxMinions += 1;
		}

		public override void UpdateArmorSet(Player player) 
		{
			player.GetModPlayer<EtherealPlayer>().oldenSet = true;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}