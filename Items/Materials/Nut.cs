using EtherealHorizons.Projectiles.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Materials
{
    public class Nut : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nut");
        }

        public override void SetDefaults()
        {
            item.damage = 2;
            item.ranged = true; 
            item.consumable = true;
            item.ammo = item.type;
            item.shoot = ModContent.ProjectileType<FriendlyNutProj>();
            item.shootSpeed = 6f;
            item.maxStack = 999;
            item.width = 22;
            item.height = 24;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(copper: 30);
        }
    }
}