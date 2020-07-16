using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons
{
    public static class Helpers
    {
        public const BindingFlags FLAGS_ANY = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
        public const BindingFlags FLAGS_INSTANCE = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        public const BindingFlags FLAGS_STATIC = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        public const string PLACEHOLDER = nameof(EtherealHorizons) + "/PLACEHOLDER";

        public static Type[] GetTypesSafe(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types;
            }
        }

        public static void NewTextSync(string text, Color color = default, bool force = false, int excludedplayer = -1)
        {
            Main.NewText(text, color, force);
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), color, excludedplayer);
            }
        }

        public static void WriteFlagsByte(this BinaryWriter writer, bool flag1 = false, bool flag2 = false, bool flag3 = false, bool flag4 = false, bool flag5 = false, bool flag6 = false, bool flag7 = false, bool flag8 = false) => writer.Write(new BitsByte(flag1, flag2, flag3, flag4, flag5, flag6, flag7, flag8));
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2, ref bool flag3) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2, ref flag3);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2, ref bool flag3, ref bool flag4) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2, ref flag3, ref flag4);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2, ref bool flag3, ref bool flag4, ref bool flag5) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2, ref flag3, ref flag4, ref flag5);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2, ref bool flag3, ref bool flag4, ref bool flag5, ref bool flag6) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2, ref flag3, ref flag4, ref flag5, ref flag6);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2, ref bool flag3, ref bool flag4, ref bool flag5, ref bool flag6, ref bool flag7) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2, ref flag3, ref flag4, ref flag5, ref flag6, ref flag7);
        public static void ReadFlagsByte(this BinaryReader reader, ref bool flag1, ref bool flag2, ref bool flag3, ref bool flag4, ref bool flag5, ref bool flag6, ref bool flag7, ref bool flag8) => ((BitsByte)reader.ReadByte()).Retrieve(ref flag1, ref flag2, ref flag3, ref flag4, ref flag5, ref flag6, ref flag7, ref flag8);

        public static int NewProjectile<T>(Vector2 position, Vector2 velocity, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f) where T : ModProjectile => Projectile.NewProjectile(position, velocity, ModContent.ProjectileType<T>(), damage, knockback, owner, ai0, ai1);
        public static Projectile NewProjectileDirect<T>(Vector2 position, Vector2 velocity, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f) where T : ModProjectile => Projectile.NewProjectileDirect(position, velocity, ModContent.ProjectileType<T>(), damage, knockback, owner, ai0, ai1);
        public static Projectile NewProjectileDirect<T>(out T modProjectile, Vector2 position, Vector2 velocity, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f) where T : ModProjectile
        {
            Projectile p = Projectile.NewProjectileDirect(position, velocity, ModContent.ProjectileType<T>(), damage, knockback, owner, ai0, ai1);
            modProjectile = p.modProjectile as T;
            return p;
        }

        public static Vector2 NextVector2(this UnifiedRandom rand, float min = 0f, float max = 0f, bool fromCenter = true) => new Vector2
        {
            X = rand.NextFloat(fromCenter ? -min : min),
            Y = rand.NextFloat(fromCenter ? max * 2f : max)
        };

        public static Vector2 NextVector2(this UnifiedRandom rand, float minX = 0f, float minY = 0f, float maxX = 1f, float maxY = 1f) => new Vector2
        {
            X = rand.NextFloat(minX, maxX),
            Y = rand.NextFloat(minY, maxY)
        };

        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo method) where TDelegate : Delegate => (TDelegate)method.CreateDelegate(typeof(TDelegate));
    }
}
