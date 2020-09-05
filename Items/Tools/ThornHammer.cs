using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace EtherealHorizons.Items.Tools
{
    public class ThornHammer : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 42;
            item.damage = 5;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.hammer = 40;
            item.knockBack = 6;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.autoReuse = false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 300);
        }
    }
}
