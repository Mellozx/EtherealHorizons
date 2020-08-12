using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Projectiles.Melee
{
    public class DustiliteShardProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dustilite Shard");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 14;
            projectile.aiStyle = 2;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 3;
        }

        public override void AI()
        { 
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 42, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
        }
    }
}
