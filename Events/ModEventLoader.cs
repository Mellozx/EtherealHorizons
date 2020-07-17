using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace EtherealHorizons.Events
{
    public static class ModEventLoader
    {
        private static IList<ModEvent> ModEvents = new List<ModEvent>();
        public const int NoneEventID = 0;
        private static int LastEventID = 1;

        public static ModEvent GetEvent(int eventType)
        {
            for(int i = 0; i < ModEvents.Count; i++)
            {
                ModEvent modevent = ModEvents[i];
                if (modevent.EventType == eventType)
                    return modevent;
            }
            return null;
        }

        public static ModEvent GetEvent(string eventName)
        {
            for(int i = 0; i < ModEvents.Count; i++)
            {
                ModEvent modEvent = ModEvents[i];
                if (modEvent.EventName == eventName)
                    return modEvent;
            }
            return null;
        }

        public static ModEvent GetEvent<T>() where T : ModEvent => ModContent.GetInstance<T>();

        internal static void OnKillNPC(NPC npc)
        {
            foreach (var modevent in ModEvents)
                if (modevent.IsActive)
                    modevent.OnKillNPC(npc);
        }
        internal static void EditSpawnPool(IDictionary<int, float> pool, in NPCSpawnInfo spawnInfo)
        {
            for (int i = 0; i < ModEvents.Count; i++)
            {
                ModEvent modevent = ModEvents[i];
                if (modevent.IsActive)
                    modevent.EditSpawnPool(pool, spawnInfo);
            }
        }
        internal static void EditSpawnRange(Player player, ref int spawnRangeX, ref int spawnRangeY, ref int safeRangeX, ref int safeRangeY)
        {
            for (int i = 0; i < ModEvents.Count; i++)
            {
                ModEvent modevent = ModEvents[i];
                if (modevent.IsActive)
                    modevent.EditSpawnRange(player, ref spawnRangeX, ref spawnRangeY, ref safeRangeX, ref safeRangeY);
            }
        }
        internal static void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            for (int i = 0; i < ModEvents.Count; i++)
            {
                ModEvent modevent = ModEvents[i];
                if (modevent.IsActive)
                    modevent.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
            }
        }
        internal static void UpdateEvents()
        {
            for (int i = 0; i < ModEvents.Count; i++)
            {
                ModEvent modevent = ModEvents[i];
                if (modevent.IsActive)
                {
                    modevent.Update();
                }
            }
        }

        internal static void LoadEvents(Mod mod)
        {
            Type[] types = mod.Code.GetTypesSafe();
            var GetOrCreateTranslation = mod.GetType().GetMethod("GetOrCreateTranslation", Helpers.FLAGS_INSTANCE).CreateDelegate<Func<Mod, string, bool, ModTranslation>>();
            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (type.IsAbstract || !type.IsSubclassOf(typeof(ModEvent)))
                    continue;

                ConstructorInfo defaultconstructor = type.GetConstructor(Type.EmptyTypes);

                if (defaultconstructor is null) 
                    continue;

                ModEvent modEvent = (ModEvent)defaultconstructor.Invoke(null);
                string modeventname = type.Name;

                if (!modEvent.Autoload(ref modeventname)) continue;

                modEvent.EventDisplayName = GetOrCreateTranslation(mod, $"Mods.{mod.Name}.EventName.{modeventname}", false);
                modEvent.SetStaticDefaults();

                modEvent.EventName = modeventname;
                modEvent.mod = mod;
                modEvent.EventType = LastEventID++;

                ModEvents.Add(modEvent);
                ContentInstance.Register(modEvent);
            }
        }

        internal static void Load()
        {
            ModEvents = new List<ModEvent>();
            LastEventID = 1;
        }

        internal static void Unload()
        {
            ModEvents = null;
            LastEventID = 1;
        }

    }
}
        //private static IList<ModEvent> modEvents = new List<ModEvent>();
        //internal static int LastAddedType = 1;

        //internal static void Load()
        //{
        //    modEvents = new List<ModEvent>();
        //    LastAddedType = 1;
        //}

        //internal static void Unload()
        //{
        //    modEvents = null;
        //    LastAddedType = 1;
        //}

        //public static ModEvent GetEvent(int id) => modEvents.FirstOrDefault(i => i.EventType == id);
        //public static ModEvent GetEvent<T>() where T : ModEvent => ModContent.GetInstance<T>();

        //internal static void UpdateEvents()
        //{
        //    foreach(var ev in modEvents)
        //    {
        //        if (ev.IsActive)
        //        {
        //            ev.Update();
        //        }
        //    }
        //}

        //internal static void AddModEventsFor(Assembly assembly)
        //{
        //    var types = assembly.GetTypesSafe();
        //    Type modeventtype = typeof(ModEvent);
        //    for(int i = 0, c = types.Length; i < c; i++)
        //    {
        //        Type type = types[i];
        //        if (type.IsAbstract || !type.IsSubclassOf(modeventtype)) 
        //            continue;
        //        ConstructorInfo defaultconstructor = type.GetConstructor(Helpers.FLAGS_INSTANCE, null, Type.EmptyTypes, null);
        //        if (defaultconstructor is null)
        //            continue;


        //        ModEvent modevent = (ModEvent)defaultconstructor.Invoke(null);
        //        string eventname = type.Name;

        //        if (!modevent.Autoload(ref eventname)) continue;

        //        modevent.EventType = LastAddedType++;
        //        modEvents.Add(modevent);
        //        ContentInstance.Register(modevent);
        //    }
        //}