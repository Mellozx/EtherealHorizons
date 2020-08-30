using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.Olden
{
	[AutoloadEquip(EquipType.Head)]
	public class OldenHeadgear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Olden Headgear");
			Tooltip.SetDefault("Increases magic damage by 12% and max mana by 40");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 22;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<OldenMantle>() && legs.type == ModContent.ItemType<OldenGreaves>();
		}
		
		public override void UpdateEquip(Player player) 
		{
			player.magicDamage += 0.14f;
			player.statManaMax2 += 40;
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