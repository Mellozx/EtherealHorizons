using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons
{
    public class EtherealHorizons : Mod
    {
        public static EtherealHorizons instance;
		public static string PlaceholderTexture = "EtherealHorizons/PLACEHOLDER";
		
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
		}

        public override void Unload()
        {
            instance = null;
        }
    }
}