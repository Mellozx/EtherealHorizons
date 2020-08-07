using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace EtherealHorizons.Items.Armor.Wild
{
	[AutoloadEquip(EquipType.Head)]
	public class WildRanged : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Wild Warrior Helmet");
			Tooltip.SetDefault("Increases ranged damage by 8%");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 22;
			item.value = Item.sellPrice(silver: 30);
			item.rare = 1;
			item.defense = 4;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;  //player make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<WildGarb>() && legs.type == ItemType<WildBoots>();
		}
		
		public override void UpdateEquip(Player player) 
		{
            player.rangedDamage += 0.08f;
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