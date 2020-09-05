using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace EtherealHorizons.Items.Tools
{
    public class ThornPickaxe : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 40;
            item.damage = 5;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 24;
            item.useAnimation = 24;
            item.pick = 38;
            item.knockBack = 6;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 540, 80);
            item.autoReuse = false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 300);
        }
    }
}
