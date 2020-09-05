using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace EtherealHorizons.Items.Tools
{
    public class ThornAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.melee = true;
            item.useTurn = true;
            item.width = 20;
            item.height = 20;
            item.damage = 5;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.axe = 8;
            item.knockBack = 5f;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.autoReuse = false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }
    }
}
