using System;
using Terraria;
using Terraria.ModLoader;
using EtherealHorizons.NPCs.Bosses.AwakeCheeks;
using EtherealHorizons.Events;

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
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        public override void Load()
        {
            instance = this;
            ModEventLoader.Load();
            ModEventLoader.LoadEvents(this);
        }

        public override void MidUpdateTimeWorld()
        {
            ModEventLoader.UpdateEvents();
        }

        public override void Unload()
        {
            instance = null;
            ModEventLoader.Unload();
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