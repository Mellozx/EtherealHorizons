using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Armor.Olden
{
    [AutoloadEquip(EquipType.Head)]
    public class OldenHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Olden Headgear");
            Tooltip.SetDefault("Increased Summoner Damage"
                + "\nAdditional 1 Max Minion");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(silver: 10); // 10 silver
            item.rare = ItemRarityID.Blue;
            item.defense = 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<OldenMantle>() && legs.type == ModContent.ItemType<OldenLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {

            player.minionDamage += 0.1f; // Minions Deal More Damage
            player.maxMinions += 1; // 1 More Max Minion 

        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
