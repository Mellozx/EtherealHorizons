using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Tools.Wild
{
	public class WildPickaxe : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wild Pickaxe");
        }

        public override void SetDefaults()
        {
            item.useTurn = true;
            item.melee = true;
            item.autoReuse = true;
            item.width = 20;
            item.height = 20;
            item.damage = 7;
            item.useTime = 20;
            item.useAnimation = 25; // Giving it some more vanilla ish aspect
            item.knockBack = 2f;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
        }
    }
}