using HarmonyLib;
using System.Linq;
using Hazel;
using UnityEngine;
using static ChallengerMod.HarmonyMain;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;

namespace ChallengerMod.Fix
{
    internal class BlockUtilitiesPatches
    {
        public static bool adminBool = true;
        public static bool vitalsBool = true;
        public static bool camsBool = true;

        [HarmonyPatch(typeof(VitalsMinigame), nameof(VitalsMinigame.Update))]
        public static class VitalsMinigameUpdate
        {
            public static bool Prefix(VitalsMinigame __instance)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    

                    if (__instance.enabled)
                    {



                        ChallengerMod.Challenger.SetVitalTimeOn = true;

                        if ((ChallengerMod.Challenger.SetVitalTime <= 0f))
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true;
                        }
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetVitalTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = false;
                }




                if (!__instance.SabText.isActiveAndEnabled &&
                    vitalsBool)
                {
                    __instance.SabText.gameObject.SetActive(true);
                    for (int j = 0; j < __instance.vitals.Length; j++)
                    {
                        __instance.vitals[j].gameObject.SetActive(false);
                    }
                }


                return !vitalsBool;
            }
        }





       


        [HarmonyPatch(typeof(PlanetSurveillanceMinigame), nameof(PlanetSurveillanceMinigame.Update))]
        public static class PlanetSurveillanceMinigameUpdate
        {
            public static bool Prefix(PlanetSurveillanceMinigame __instance)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    if (__instance.enabled)
                    {



                        ChallengerMod.Challenger.SetCamTimeOn = true;

                        if ((ChallengerMod.Challenger.SetCamTime <= 0f))
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                        }
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetCamTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false;
                }


                //Toggle ON/OFF depending on minPlayerCams parameter
                if (!__instance.isStatic && camsBool)
                {
                    __instance.isStatic = true;
                    __instance.ViewPort.sharedMaterial = __instance.StaticMaterial;
                    __instance.SabText.gameObject.SetActive(true);
                }

                return !camsBool;
            }
        }

        [HarmonyPatch(typeof(PlanetSurveillanceMinigame), nameof(PlanetSurveillanceMinigame.NextCamera))]
        public static class PlanetSurveillanceMinigameNextCamera
        {
            public static bool Prefix(PlanetSurveillanceMinigame __instance)
            {





                if (camsBool)
                {


                    __instance.Dots[__instance.currentCamera].sprite = __instance.DotDisabled;

                    __instance.currentCamera = Extensions.Wrap(__instance.currentCamera,
                        __instance.survCameras.Length);
                    __instance.Dots[__instance.currentCamera].sprite = __instance.DotEnabled;
                    SurvCamera survCamera = __instance.survCameras[__instance.currentCamera];
                    __instance.Camera.transform.position = survCamera.transform.position +
                                                           __instance.survCameras[__instance.currentCamera].Offset;
                    __instance.LocationName.text = survCamera.CamName;
                    return false;
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(SurveillanceMinigame), nameof(SurveillanceMinigame.Update))]
        public static class SurveillanceMinigameUpdate
        {
            public static bool Prefix(SurveillanceMinigame __instance)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    if (__instance.enabled)
                    {



                        ChallengerMod.Challenger.SetCamTimeOn = true;

                        if ((ChallengerMod.Challenger.SetCamTime <= 0f))
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                        }
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetCamTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false;
                }



                if (!__instance.isStatic && camsBool)
                {
                    __instance.isStatic = true;
                    for (int j = 0; j < __instance.ViewPorts.Length; j++)
                    {
                        __instance.ViewPorts[j].sharedMaterial = __instance.StaticMaterial;
                        __instance.SabText[j].gameObject.SetActive(true);
                    }
                }

                return !camsBool;
            }
        }



        












    }
}