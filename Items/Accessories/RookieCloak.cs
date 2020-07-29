using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace EtherealHorizons.Items.Accessories
{
    public class RookieCloak : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Some squirrels have been seen using this cloak"
            + "\nIncreased movement speed by 15%, and allows slow fall");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = Item.buyPrice(0, 0, 55, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.15f;
            player.slowFall = true;
        }
    }
}
