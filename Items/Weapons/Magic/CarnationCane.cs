using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Magic;

namespace EtherealHorizons.Items.Weapons.Magic
{
    public class CarnationCane : ModItem
    {
        public override string Texture => EtherealHorizons.Placeholder;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carnation Cane");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.noMelee = true;
            item.magic = true;
            item.autoReuse = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 35;
            item.useAnimation = 35;
            item.damage = 10;
            item.knockBack = 1f;
            item.shootSpeed = 6f;
            item.shoot = ModContent.ProjectileType<PetalProjectile>();
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1; // Placeholder Sound
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(silver: 40);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            const int projNum = 4;
            const float rotation = (MathHelper.TwoPi / 360f) * 30; //2Pi / 360 == Pi/180 == 1 degree in radians //MathHelper.ToRadians(30);
            float randSpeed = Main.rand.NextFloat(0.5f, 0.2f);
            Vector2 speed = new Vector2(speedX, speedY);
            position += Vector2.Normalize(speed) * 30f;
            for (int i = 0; i < projNum; i++)
            {
                Vector2 perturbedSpeed = speed.RotatedBy(MathHelper.Lerp(-rotation, rotation, 1f / projNum * i)) * randSpeed;
                Projectile.NewProjectile(position, perturbedSpeed, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
