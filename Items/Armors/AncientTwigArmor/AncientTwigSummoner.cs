using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace EtherealHorizons.Items.Armors.AncientTwigArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientTwigSummoner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Twig Summoner");
            Tooltip.SetDefault("Increased Summoner Damage"
                + "\nAdditional 1 Max Minion");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000; // 10 silver
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<AncientTwigChestPlate>() && legs.type == ItemType<AncientTwigLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.minionDamage -= 0.1f; // Minions Deal More Damage
            player.maxMinions += 1; // 1 More Max Minion 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AncientTwig", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}