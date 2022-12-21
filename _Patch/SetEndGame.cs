using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Text;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.HarmonyMain;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.CustomButton.HudManagerStartPatch;
using ChallengerMod.RPC;
using Hazel;

namespace ChallengerMod.SetEndGame
{
    enum CustomGameOverReason
    {
        CustomWin = 10,

    }

    enum WinCondition
    {
        Default,
        CustomWin,
    }

    static class AdditionalTempData
    {
        public static WinCondition winCondition = WinCondition.Default;
        public static List<WinCondition> additionalWinConditions = new List<WinCondition>();

        public static void clear()
        {
            additionalWinConditions.Clear();
            winCondition = WinCondition.Default;
        }

        
    }


    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class OnGameEndPatch
    {
        private static GameOverReason gameOverReason;

        public static void Prefix(AmongUsClient __instance, [HarmonyArgument(0)] ref EndGameResult endGameResult)
        {
            gameOverReason = endGameResult.GameOverReason;
            if ((int)endGameResult.GameOverReason >= 10) endGameResult.GameOverReason = GameOverReason.ImpostorByKill;

        }

        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ref EndGameResult endGameResult)
        {
            AdditionalTempData.clear();

            List<PlayerControl> notWinners = new List<PlayerControl>();
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                notWinners.Add(player);
            }

            

            List<WinningPlayerData> winnersToRemove = new List<WinningPlayerData>();
            foreach (WinningPlayerData winner in TempData.winners)
            {
                if (notWinners.Any(x => x.Data.PlayerName == winner.PlayerName)) winnersToRemove.Add(winner);
            }
            foreach (var winner in winnersToRemove) TempData.winners.Remove(winner);

            bool CustomWin = gameOverReason == (GameOverReason)CustomGameOverReason.CustomWin;


            if (CustomWin)
            {
                AdditionalTempData.winCondition = WinCondition.CustomWin;
            }


        }
    }

    [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.SetEverythingUp))]
    public class EndGameManagerSetUpPatch
    {
        public static void Postfix(EndGameManager __instance)
        {
            
            __instance.BackgroundBar.material.color = ChallengerMod.ColorTable.blackColor;
            __instance.WinText.text = "";
            GameObject bonusText = UnityEngine.Object.Instantiate(__instance.WinText.gameObject);
            bonusText.transform.position = new Vector3(__instance.WinText.transform.position.x, __instance.WinText.transform.position.y - 0f, __instance.WinText.transform.position.z);
            bonusText.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            TMPro.TMP_Text textRenderer = bonusText.GetComponent<TMPro.TMP_Text>();
            textRenderer.text = "";
            

            if (AdditionalTempData.winCondition == WinCondition.CustomWin)
            {

                /* */

                List<string> WinList = new List<string>();

                /** - This part of the code is not open source **/

                textRenderer.text += "\n";



                /** - This part of the code is not open source **/

                var EndgameManager = GameObject.Find("EndGameManager");
                if (EndgameManager != null)
                {
                    /** - This part of the code is not open source **/
                }


                textRenderer.color = ChallengerMod.ColorTable.WhiteColor;

                 /** - This part of the code is not open source **/
            }

            

            
            AdditionalTempData.clear();
        }
    }

    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.CheckEndCriteria))]
    class CheckEndCriteriaPatch
    {
        public static bool Prefix(ShipStatus __instance)
        {
            if (!GameData.Instance) return false;
            if (DestroyableSingleton<TutorialManager>.InstanceExists) // InstanceExists | Don't check Custom Criteria when in Tutorial
                return true;
            var statistics = new PlayerStatistics(__instance);
            if (CheckAndEndGameForOutlawWin(__instance, statistics)) return false;
            if (CheckAndEndGameForArsonistWin(__instance, statistics)) return false;
            if (CheckAndEndGameForCulteWin(__instance, statistics)) return false;
            if (CheckAndEndGameForJesterWin(__instance, statistics)) return false;
            if (CheckAndEndGameForEaterWin(__instance, statistics)) return false;
            if (CheckAndEndGameForCursedWin(__instance, statistics)) return false;
            if (CheckAndEndGameForSabotageWin(__instance, statistics)) return false;
            if (CheckAndEndGameForTaskWin(__instance, statistics)) return false;
            if (CheckAndEndGameForImpostorWin(__instance, statistics)) return false;
            if (CheckAndEndGameForCrewmateWin(__instance, statistics)) return false;
            if (CheckPlayerAlive(__instance, statistics)) return false;
            return false;
        }
        private static bool CheckPlayerAlive(ShipStatus __instance, PlayerStatistics statistics)
        {

            if (Outlaw_Alive == 0)
            {
                /** - This part of the code is not open source **/
            }
            return false;


        }
        private static bool CheckAndEndGameForOutlawWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
            return false;


        }
        private static bool CheckAndEndGameForCulteWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
            return false;
        }


        private static bool CheckAndEndGameForJesterWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
            return false;


        }
        private static bool CheckAndEndGameForEaterWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
            return false;
        }
        private static bool CheckAndEndGameForCursedWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
            return false;


        }
        private static bool CheckAndEndGameForArsonistWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
            return false;
        }








    

        private static bool CheckAndEndGameForSabotageWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            if (__instance.Systems == null) return false;
            var systemType = __instance.Systems.ContainsKey(SystemTypes.LifeSupp) ? __instance.Systems[SystemTypes.LifeSupp] : null;
            if (systemType != null)
            {
                LifeSuppSystemType lifeSuppSystemType = systemType.TryCast<LifeSuppSystemType>();
                if (lifeSuppSystemType != null && lifeSuppSystemType.Countdown < 0f)
                {
                    EndGameForSabotage(__instance, statistics);
                    lifeSuppSystemType.Countdown = 10000f;
                    return true;
                }
            }
            var systemType2 = __instance.Systems.ContainsKey(SystemTypes.Reactor) ? __instance.Systems[SystemTypes.Reactor] : null;
            if (systemType2 == null)
            {
                systemType2 = __instance.Systems.ContainsKey(SystemTypes.Laboratory) ? __instance.Systems[SystemTypes.Laboratory] : null;
            }
            if (systemType2 != null)
            {
                ICriticalSabotage criticalSystem = systemType2.TryCast<ICriticalSabotage>();
                if (criticalSystem != null && criticalSystem.Countdown < 0f)
                {
                    EndGameForSabotage(__instance, statistics);
                    criticalSystem.ClearSabotage();
                    return true;
                }
            }
            return false;
        }



        private static bool CheckAndEndGameForTaskWin(ShipStatus __instance, PlayerStatistics statistics)
        {
            /** - This part of the code is not open source **/
        }
            return false;
        }





        private static bool CheckAndEndGameForImpostorWin(ShipStatus __instance, PlayerStatistics statistics)
        {


            
            /** - This part of the code is not open source **/


        
        return false;



        }
        private static void CheckLove(ShipStatus __instance, PlayerStatistics statistics)
        {

        /** - This part of the code is not open source **/




    }
    private static void CheckEnd(ShipStatus __instance, PlayerStatistics statistics)
        {



            ChallengerMod.Challenger.EndDelay -= Time.fixedDeltaTime;


            if ((ChallengerMod.Challenger.EndDelay <= 0f))
            {
                ShipStatus.RpcEndGame((GameOverReason)CustomGameOverReason.CustomWin, false);
                __instance.enabled = false;
            }
            else { return; }






        }




        private static bool CheckAndEndGameForCrewmateWin(ShipStatus __instance, PlayerStatistics statistics)
        {

            if (statistics.TeamImpostorsAlive == 0 && statistics.TeamOutlawAlive == 0 && !Jester.Exiled)
            {
            /** - This part of the code is not open source **/



        }
        return false;
            //}
        }

        private static void EndGameForSabotage(ShipStatus __instance, PlayerStatistics statistics)
        {



        /** - This part of the code is not open source **/

        CheckEnd(__instance, statistics);
        }
    }


    internal class PlayerStatistics
    {
        public int TeamImpostorsAlive { get; set; }
        public int MercenaryImpostor { get; set; }
        public int CopyCatImpostor { get; set; }
        public int RevengerImpostor { get; set; }
        public int TeamOutlawAlive { get; set; }
        public int TeamLoveAlive { get; set; }
        public int TotalAlive { get; set; }
        public int TeamCulteAlive { get; set; }
        public bool JesterLoved { get; set; }
        public bool CursedLoved { get; set; }

        public bool OutlawLoved { get; set; }
        public bool EaterLoved { get; set; }
        public bool ArsonistLoved { get; set; }
        public bool CulteLoved { get; set; }


        public PlayerStatistics(ShipStatus __instance)
        {
            GetPlayerCounts();
        }


        /*private bool IsMercenaryImpostor(GameData.PlayerInfo p)
        {
            return (Mercenary.Role != null && Mercenary.isImpostor == true && Mercenary.Role.PlayerId == p.PlayerId);
        }
        private bool IsCopyCatImpostor(GameData.PlayerInfo p)
        {
            return (CopyCat.Role != null && CopyCat.isImpostor == true && CopyCat.Role.PlayerId == p.PlayerId);
        }
        private bool IsRevengerImpostor(GameData.PlayerInfo p)
        {
            return (Revenger.Role != null && Revenger.isImpostor == true && Revenger.Role.PlayerId == p.PlayerId);
        }*/

        private bool IsLover(GameData.PlayerInfo p)
        {
            return (Cupid.Lover1 != null && Cupid.Lover1.PlayerId == p.PlayerId) || (Cupid.Lover2 != null && Cupid.Lover2.PlayerId == p.PlayerId);
        }
        private bool IsCulte(GameData.PlayerInfo p)
        {
            return (Cultist.Role != null && Cultist.Role.PlayerId == p.PlayerId);
        }
        private bool IsCulte1(GameData.PlayerInfo p)
        {
            return (Cultist.Culte1 != null && Cultist.Culte1.PlayerId == p.PlayerId);
        }
        private bool IsCulte2(GameData.PlayerInfo p)
        {
            return (Cultist.Culte2 != null && Cultist.Culte2.PlayerId == p.PlayerId);
        }
        private bool IsCulte3(GameData.PlayerInfo p)
        {
            return (Cultist.Culte3 != null && Cultist.Culte3.PlayerId == p.PlayerId);
        }
        private bool IsOutlaw(GameData.PlayerInfo p)
        {
            return (Outlaw.Role != null && Outlaw.Role.PlayerId == p.PlayerId);
        }


        private void GetPlayerCounts()
        {
            int numCulteAlive = 0;
            int numCulte1Alive = 0;
            int numCulte2Alive = 0;
            int numCulte3Alive = 0;
            int numLoveAlive = 0;
            int numImpostorsAlive = 0;
            int numOutlawAlive = 0;
            int numTotalAlive = 0;
            bool Jesterlove = false;
            bool Cursedlove = false;
            bool Eaterlove = false;
            bool Arsonistlove = false;
            bool CulteLove = false;
            bool Outlawlove = false;


            for (int i = 0; i < GameData.Instance.PlayerCount; i++)
            {
                GameData.PlayerInfo playerInfo = GameData.Instance.AllPlayers[i];
                if (!playerInfo.Disconnected)
                {
                    if (!playerInfo.IsDead)
                    {

                        numTotalAlive++;
                        bool lover = IsLover(playerInfo);
                        if (lover) numLoveAlive++;
                        bool outlaw = IsOutlaw(playerInfo);
                        if (outlaw) numOutlawAlive++;
                        bool culte = IsCulte(playerInfo);
                        if (culte) numCulteAlive++;
                        bool culte1 = IsCulte1(playerInfo);
                        if (culte1) numCulte1Alive++;
                        bool culte2 = IsCulte2(playerInfo);
                        if (culte2) numCulte2Alive++;
                        bool culte3 = IsCulte3(playerInfo);
                        if (culte3) numCulte3Alive++;

                       /* bool mercenaryImpostor = IsMercenaryImpostor(playerInfo);
                        if (mercenaryImpostor) numImpostorsAlive++;
                        bool copycatImpostor = IsCopyCatImpostor(playerInfo);
                        if (mercenaryImpostor) numImpostorsAlive++;
                        bool revengerImpostor = IsRevengerImpostor(playerInfo);
                        if (mercenaryImpostor) numImpostorsAlive++;*/

                        if (playerInfo.Role.IsImpostor)
                        {
                            numImpostorsAlive++;
                        }

                        if (Jester.Role != null && Jester.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Jesterlove = true;

                        }
                        if (Cursed.Role != null && Cursed.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Cursedlove = true;

                        }
                        if (Outlaw.Role != null && Outlaw.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Outlawlove = true;

                        }
                        if (Eater.Role != null && Eater.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Eaterlove = true;

                        }
                        if (Arsonist.Role != null && Arsonist.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Arsonistlove = true;

                        }
                        if ((Cultist.Role != null && Cultist.Role.PlayerId == playerInfo.PlayerId)
                            || (Cultist.Culte1 != null && Cultist.Culte1.PlayerId == playerInfo.PlayerId)
                            || (Cultist.Culte2 != null && Cultist.Culte2.PlayerId == playerInfo.PlayerId)
                            || (Cultist.Culte3 != null && Cultist.Culte3.PlayerId == playerInfo.PlayerId)
                            )
                        {
                            if (lover) CulteLove = true;

                        }

                    }
                }

                TeamCulteAlive = numCulte1Alive + numCulte2Alive + numCulte3Alive;
                TeamLoveAlive = numLoveAlive;
                TeamImpostorsAlive = numImpostorsAlive;
                TeamOutlawAlive = numOutlawAlive;
                TotalAlive = numTotalAlive;
                JesterLoved = Jesterlove;
                CursedLoved = Cursedlove;
                OutlawLoved = Outlawlove;
                EaterLoved = Eaterlove;
                ArsonistLoved = Arsonistlove;
                CulteLoved = CulteLove;
                ChallengerMod.Set.Data.LoadImpostor = numImpostorsAlive;
            }
        }
    }
}