using BepInEx;
using R2API.Utils;

namespace PlayerStatsAPI
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.ML.PlayerStatsAPI", "Console Overhaul: Too Much Information", "1.0")]
    [R2APISubmoduleDependency(nameof(CommandHelper))]

    //if you're making a mod which uses this mod, make sure you use: "[BepInDependency("com.ML.PlayerStatsAPI")]"
    public class TMI : BaseUnityPlugin
    {

        public void Awake()
        {
            CommandHelper.AddToConsoleWhenReady();
        }

        /// <summary>
        /// Object refference of the API to provide access to the non-static methods (e.g. GetVariableFromString()).
        /// </summary>
        public static PlayerStats PlayerStatsAPIAccessPoint = new PlayerStats();

    }

}
