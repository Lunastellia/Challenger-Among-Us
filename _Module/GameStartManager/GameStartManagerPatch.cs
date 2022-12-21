
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using Hazel;
using System;
using ChallengerMod.Utils;
using ChallengerMod.RPC;
using static ChallengerMod.Utils.Helpers;
using static ChallengerMod.Set.Data;

using UnhollowerBaseLib;
using System.Linq;

namespace ChallengerMod.Versioncheck
{
    public class GameStartManagerPatch
    {
        public static Dictionary<int, PlayerVersion> playerVersions = new Dictionary<int, PlayerVersion>();
        private static bool versionSent = false;

        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
        public class AmongUsClientOnPlayerJoinedPatch
        {
            public static void Postfix()
            {
                if (PlayerControl.LocalPlayer != null)
                {
                    Helpers.shareGameVersion();

                    if (Challenger.IsrankedGame)
                    {
                        Challenger.ReadyPlayers = new List<string>();
                    }
         
                }
            }
        }

        

        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerLeft))]
        public class AmongUsClientOnPlayerLeftPatch
        {
            public static void Postfix()
            {
                if (PlayerControl.LocalPlayer != null && Challenger.IsrankedGame)
                {
                    Challenger.ReadyPlayers = new List<string>();
                }
            }
        }

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
        public class GameStartManagerStartPatch
        {
            public static void Postfix(GameStartManager __instance)
            {
                // Trigger version refresh
                versionSent = false;

                /** - This part of the code is not open source **/

                
            }
        }

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
        public class GameStartManagerUpdatePatch
        {
            private static bool update = false;

            public static void Prefix(GameStartManager __instance)
            {
                if (!GameData.Instance) return; // No instance
                update = GameData.Instance.PlayerCount != __instance.LastPlayerCount;
            }

            public static void Postfix(GameStartManager __instance)
            {
                // Send version as soon as CachedPlayer.LocalPlayer.PlayerControl exists
                if (PlayerControl.LocalPlayer != null && !versionSent)
                {
                    versionSent = true;
                    Helpers.shareGameVersion();
                }

                // Check version handshake infos

                bool versionMismatch = false;
                bool notplayable = false;
                string message = "";
                foreach (InnerNet.ClientData client in AmongUsClient.Instance.allClients.ToArray())
                {
                    if (__instance.StartButton.isVisible && client.Character.Data.PlayerId == 0)
                    {
                        /** - This part of the code is not open source **/
                    }
                    if (client.Character == null) continue;
                    var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                    if (dummyComponent != null && dummyComponent.enabled)
                        continue;


                    else if (!playerVersions.ContainsKey(client.Id))
                    {
                        versionMismatch = true;
                        /** - This part of the code is not open source **/
                    }
                    else
                    {
                        PlayerVersion PV = playerVersions[client.Id];
                        int diff = ChallengerMod.HarmonyMain.Version.CompareTo(PV.version);
                        if (diff > 0)
                        {
                            /** - This part of the code is not open source **/
                        }
                        else if (diff < 0)
                        {
                            /** - This part of the code is not open source **/
                        }
                        else if (!PV.GuidMatches())
                        { // version presumably matches, check if Guid matches
                            /** - This part of the code is not open source **/
                        }
                    }
                }

                // Display message to the host
                if (AmongUsClient.Instance.AmHost)
                {
                    if (versionMismatch || notplayable)
                    {
                        ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        __instance.StartButton.color = __instance.startLabelText.color = Palette.DisabledClear;
                        __instance.GameStartText.text = message;
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 2;
                    }
                    else
                    {
                        ChallengerMod.HarmonyMain.CanStartTheGame = true;
                        __instance.StartButton.color = __instance.startLabelText.color = ((__instance.LastPlayerCount >= __instance.MinPlayers) ? Palette.EnabledColor : Palette.DisabledClear);
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition;
                    }
                    

                      /*  if (versionMismatch || notplayable)
                        {
                            __instance.GameStartText.text = message;
                            __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 2f;
                        }
                        else
                        {
                            __instance.GameStartText.text = message;
                            __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 3f;
                        }*/



                    






                }

                // Client update with handshake infos
                else
                {
                    if (!playerVersions.ContainsKey(AmongUsClient.Instance.HostId) || ChallengerMod.HarmonyMain.Version.CompareTo(playerVersions[AmongUsClient.Instance.HostId].version) != 0)
                    {
                        __instance.GameStartText.text = $"";
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 2;
                    }
                    else if (versionMismatch)
                    {
                        __instance.GameStartText.text = $"" + message;
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 2;
                    }
                    else
                    {
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition;
                        if (__instance.startState != GameStartManager.StartingStates.Countdown)
                        {
                            __instance.GameStartText.text = String.Empty;
                        }
                    }
                }



            }
        }

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.BeginGame))]
        public class GameStartManagerBeginGame
        {
            public static bool Prefix(GameStartManager __instance)
            {
                // Block game start if not everyone has the same mod version
                bool continueStart = true;

                if (AmongUsClient.Instance.AmHost)
                {
                    foreach (InnerNet.ClientData client in AmongUsClient.Instance.allClients)
                    {
                        if (client.Character == null) continue;
                        var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                        if (dummyComponent != null && dummyComponent.enabled)
                            continue;

                        if (!playerVersions.ContainsKey(client.Id))
                        {
                            continueStart = false;
                            break;
                        }

                        PlayerVersion PV = playerVersions[client.Id];
                        int diff = ChallengerMod.HarmonyMain.Version.CompareTo(PV.version);
                        if (diff != 0 || !PV.GuidMatches())
                        {
                            continueStart = false;
                            break;
                        }
                    }


                }
                return continueStart;
            }
        }
    

        public class PlayerVersion
        {
            public readonly Version version;
            public readonly Guid guid;

            public PlayerVersion(Version version, Guid guid)
            {
                this.version = version;
                this.guid = guid;
            }

            public bool GuidMatches()
            {
                return Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.Equals(this.guid);
            }
        }
    }
}