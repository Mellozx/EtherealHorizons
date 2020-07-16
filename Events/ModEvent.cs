using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace EtherealHorizons.Events
{
    public abstract class ModEvent
    {
        public static ModEvent GetEvent<T>() where T : ModEvent => ModEventLoader.GetEvent<T>();
        public static ModEvent GetEvent(int eventType) => ModEventLoader.GetEvent(eventType);
        public static ModEvent GetEvent(string eventName) => ModEventLoader.GetEvent(eventName);

        public static bool IsEventActive<T>() where T : ModEvent => ModEventLoader.GetEvent<T>().IsActive;

        public static void StartEvent<T>() where T : ModEvent => ModEventLoader.GetEvent<T>().Start();

        public static void EndEvent<T>() where T : ModEvent => ModEventLoader.GetEvent<T>().End();
 
        public ModTranslation EventDisplayName { get; internal set; } // TODO: find for wat this might be used perhaps
        public Mod mod { get; internal set; }
        public int EventType { get; internal set; }
        internal string EventName { get; set; } // name for it to be found when using ModEventLoader.GetEvent(string)
        // public bool NetUpdate;

        public bool IsActive { get; internal set; }

        public virtual bool Autoload(ref string eventname) => true;
        public virtual void SetStaticDefaults() { }
        // public virtual void SetDefaults() { } // TODO: find for wat dis could be used or how or when perhaps
        /// <summary>
        /// Called when the event starts
        /// </summary>
        public virtual void OnStart() { }
        /// <summary>
        /// Called during <see cref="Mod.MidUpdateTimeWorld"/> when the event is active
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// Called when the event ends
        /// </summary>
        public virtual void OnEnd() { }
        public virtual void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) { }
        public virtual void EditSpawnRange(Player player, ref int spawnRangeX, ref int spawnRangeY, ref int safeRangeX, ref int safeRangeY) { }
        public virtual void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) { }
        /// <summary>
        /// Called when an NPC dies during the event
        /// </summary>
        /// <param name="npc">The npc that died</param>
        public virtual void OnKillNPC(NPC npc) { }

        internal void Start()
        {
            if (IsActive) return;
            IsActive = true;
            OnStart();
        }
        internal void End()
        {
            if (!IsActive) return;
            IsActive = false;
            OnEnd();
        }
    }
}
