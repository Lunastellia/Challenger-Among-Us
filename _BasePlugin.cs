using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Linq;
using System.Net;
using Reactor;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using UnityEngine;
using System.IO;
using Reactor.Extensions;
using UnhollowerBaseLib;
using System.Collections;
using ChallengerMod.Utils.Option;
using ChallengerMod.RPC;
using Hazel.Udp;
using System.Text.RegularExpressions;
using Hazel;
using InnerNet;
using System.Collections.Generic;
using BepInEx.Logging;
using System.Reflection;
using UnhollowerRuntimeLib;
using ChallengerMod.UI;
using ChallengerMod.RainbowPlugin;
using ChallengerMod.Item;

namespace ChallengerMod
{
    [BepInPlugin(Id, "Challenger_Core", VersionString)]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInProcess("Among Us.exe")]

    public class HarmonyMain : BasePlugin
    {
        /** - This part of the code is not open source **/


        public static System.Version Version = System.Version.Parse(VersionString);
        
        public const string Id = "Config.ChallengerMod";
        public static HarmonyMain Instance { get { return PluginSingleton<HarmonyMain>.Instance; } }
        // static List<CooldownButton> impostorbuttons = new List<CooldownButton>();
        public List<WorldItem> AllItems { get; set; }
        public Harmony Harmony { get; } = new Harmony(Id);

        public static ConfigEntry<bool> StreamerMode { get; set; }

        public static ConfigFile OPSettings { get; private set; }

        public static ManualLogSource Logger { get; private set; }
        public static ConfigEntry<string> Ip_Challenger { get; set; }
        public static ConfigEntry<ushort> Port_Challenger { get; set; }
        public static ConfigEntry<string> ShowPopUpVersion { get; set; }

        public static IRegionInfo[] defaultRegions;
        public static void UpdateRegions()
        {
            ServerManager serverManager = DestroyableSingleton<ServerManager>.Instance;
            IRegionInfo[] regions = defaultRegions;

            var CustomRegion_Challenger = new DnsRegionInfo(Ip_Challenger.Value, "EU Challenger", StringNames.NoTranslation, Ip_Challenger.Value, Port_Challenger.Value, false);
            regions = regions.Concat(new IRegionInfo[] {CustomRegion_Challenger.Cast<IRegionInfo>()}).ToArray();
            ServerManager.DefaultRegions = regions;
            serverManager.AvailableRegions = regions;
        }


        /** - This part of the code is not open source **/


        public static IRegionInfo RegisterServer(string name, string ip, ushort port)
        {
            if (Uri.CheckHostName(ip).ToString() == "Dns")
            {
                try
                {
                    foreach (IPAddress address in Dns.GetHostAddresses(ip))
                        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ip = address.ToString();
                            break;
                        }
                }
                catch { }
            }

            return new DnsRegionInfo(name, name, StringNames.NoTranslation, new[]
            {
                new ServerInfo($"{name}-Master-1", ip, port)
            }).Cast<IRegionInfo>();
        }







        /** - This part of the code is not open source **/

       





















        public override void Load()
        {



        StreamerMode = Config.Bind("Custom", "Enable Streamer Mode", false);

            /** - This part of the code is not open source **/




            PalettePatch.Load();
            ClassInjector.RegisterTypeInIl2Cpp<RainbowBehaviour>();

            // Unpatches the modded handshake, because Impostor is STILL not fully updated yet
            Harmony.Unpatch(typeof(UdpConnection).GetMethod("HandleSend"), HarmonyPatchType.Prefix,
                ReactorPlugin.Id);


            CustomOptionHolder.Load();
            /** - This part of the code is not open source **/
           
            Ip_Challenger = Config.Bind("EU Challenger", "51.91.140.152", "51.91.140.152");
            Port_Challenger = Config.Bind("EU Challenger", "22023", (ushort)22023);
            defaultRegions = ServerManager.DefaultRegions;
            UpdateRegions();
            Harmony.PatchAll();
        }








       





        [HarmonyPatch(typeof(Constants), nameof(Constants.ShouldFlipSkeld))]
        class ConstantsShouldFlipSkeldPatch
        {
            public static bool Prefix(ref bool __result)
            {
                if (PlayerControl.GameOptions == null) return true;
                __result = PlayerControl.GameOptions.MapId == 3;
                return false;
            }
        }
        


        
        [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Start))]
        [HarmonyPriority(Priority.First)]
        public static class GameOptionsMenuPatch
        {
            public static void Postfix(GameOptionsMenu __instance)
            {
                __instance.Children
                    .Single(o => o.Title == StringNames.GameCommonTasks).Cast<NumberOption>().ValidRange = new FloatRange(0, 5);

                __instance.Children
                   .Single(o => o.Title == StringNames.GameLongTasks).Cast<NumberOption>().ValidRange = new FloatRange(0, 5);
                
                __instance.Children
                   .Single(o => o.Title == StringNames.GameShortTasks).Cast<NumberOption>().ValidRange = new FloatRange(0, 5);
               
               /* __instance.Children
                   .Single(o => o.Title == StringNames.GameNumImpostors).Cast<NumberOption>().ValidRange = new FloatRange(1, 4);
               */
                __instance.Children
                   .Single(o => o.Title == StringNames.GameRecommendedSettings).Destroy();


            }
        }
        
    }
   /* [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Update))]
    public static class Update
    {
        public static void Postfix(ref GameOptionsMenu __instance)
        {
            __instance.GetComponentInParent<Scroller>().ContentYBounds.max = (__instance.Children.Length - 6.5f) / 2;
        }
    }*/
    [HarmonyPatch(typeof(StatsManager), nameof(StatsManager.AmBanned), MethodType.Getter)]
    public static class AmBannedPatch
    {
        public static void Postfix(out bool __result)
        {
            __result = false;
        }
    }
}
