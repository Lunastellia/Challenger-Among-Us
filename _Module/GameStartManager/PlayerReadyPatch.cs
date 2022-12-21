
using HarmonyLib;
using System;
using Hazel;
using UnityEngine;
using System.Linq;
using static ChallengerMod.Roles;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using Reactor;
using Reactor.Extensions;
using System.Reflection;
using UnhollowerBaseLib;
using static ChallengerMod.Unity;
using static ChallengerMod.Set.Data;
using ChallengerMod.RPC;

namespace ChallengerMod.PlayerReady
{


    [HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
    public class LobbyPatch
    {
        public static void Prefix()
        {

            if (Challenger.IsrankedGame)
            {
                CreateReadyButtons();
            }
            
        }


        public static void CreateReadyButtons()
        {
            
                var CHLog = new ManualLogSource("ExtraButtons");
                BepInEx.Logging.Logger.Sources.Add(CHLog);
                try
                {

                    CHLog.Log(LogLevel.Info, "Starting creation of buttons");
                    var ReadyButton = UnityEngine.Object.Instantiate(HudManager.Instance.UseButton, HudManager.Instance.UseButton.transform.parent);

                    ReadyButton.graphic.sprite = R_Button_EN;

                    UnityEngine.Object.Destroy(ReadyButton.GetComponentInChildren<TextTranslatorTMP>());
                    ReadyButton.name = "ReadyButton";
                    ReadyButton.OverrideText(BTT_Ready);
                    ReadyButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.HunterColor);

                    ReadyButton.OverrideColor(color: Palette.EnabledColor);
                    ReadyButton.transform.localPosition = new Vector2(0f, -1.65f);

                    ReadyButton.graphic.SetCooldownNormalizedUvs();
                    var passiveButton = ReadyButton.GetComponent<PassiveButton>();
                    passiveButton.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                    passiveButton.OnClick.AddListener((Action)(() =>
                    {
                        var PlayerName = PlayerControl.LocalPlayer.name;


                        if (!Challenger.ReadyPlayers.Contains(PlayerName))
                        {
                            SoundManager.Instance.PlaySound(Used, false, 100f);
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareReady, Hazel.SendOption.Reliable, -1);
                            writer.Write(PlayerName);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.shareReady(PlayerName);
                        }
                        else
                        {
                            
                        }


                    }));


                }
                catch (Exception e)
                {
                throw;
                }
        }


    }

    [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.OnDestroy))]
    public class OnGameStart
    {
        public static void Prefix(IntroCutscene __instance)
        {

            if (Challenger.IsrankedGame)
            {
                var currentName = PlayerControl.LocalPlayer.name;
                GameObject ReadyButton;
                var CHLog = new ManualLogSource("ReadyButton");
                BepInEx.Logging.Logger.Sources.Add(CHLog);

                ReadyButton = GameObject.Find("ReadyButton");
                UnityEngine.Object.Destroy(ReadyButton);

                PlayerControl.LocalPlayer.CheckName($"{currentName}");
            }
           
        }
    }
}