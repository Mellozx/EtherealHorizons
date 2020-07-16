using EtherealHorizons.NPCs.Bosses.AwakeCheeks;
using System;
using Terraria.ModLoader;

namespace EtherealHorizons
{
    public class EtherealHorizons : Mod
    {
        public static EtherealHorizons instance;

        public EtherealHorizons()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            instance = this;
        }

        public override void Unload()
        {
            instance = null;
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBoss",
                    0.9f,
                    ModContent.NPCType<AwakeCheeks>(),
                    (Func<bool>)(() => EtherealWorld.downedAwakeCheeks));
                // Spawn Items
                // Collection
                // Loot
                // Spawn Info (Optional)
                // Despawn Message (Optional)
            }
        }
    }
}