using EtherealHorizons.Items.Materials;
using IL.Terraria.GameContent.UI;
using MonoMod.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Armor.WildWarrior
{
    // [AutoloadEquip(EquipType.Head)]
	public class WildWarriorHelmet : ModItem
    {
        public override string Texture => "EtherealHorizons/PLACEHOLDER";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Warrior Helmet");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.defense = 2;
            item.rare = ItemRarityID.Green;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WildWarriorChestplate>() && legs.type == ModContent.ItemType<WildWarriorGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants you a 25% chance to shoot a nut when a ranged weapon is used";

            player.GetModPlayer<EtherealPlayer>().wildWarriorHelmet = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe(); 
        }
    }
}