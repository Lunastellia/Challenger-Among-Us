using HarmonyLib;
using System;
using System.Linq;
using System.Collections.Generic;
using static ChallengerMod.HudUpdateManager;
using static ChallengerMod.Utils.Helpers;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.GameHistory;

namespace ChallengerMod
{

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.LocalPlayer.CmdReportDeadBody))]
    class BodyReportPatch
    {

        static void Postfix(PlayerControl __instance, [HarmonyArgument(0)] GameData.PlayerInfo target)
        {
            bool isReport = (Lawkeeper.Role != null && Lawkeeper.Role == PlayerControl.LocalPlayer && __instance.PlayerId == Lawkeeper.Role.PlayerId);
            bool isCopyReport = (CopyCat.Role != null && CopyCat.copyRole == 18 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && __instance.PlayerId == CopyCat.Role.PlayerId);
            bool Ability = (Lawkeeper.Role != null && Lawkeeper.Role != PlayerControl.LocalPlayer && __instance.PlayerId != Lawkeeper.Role.PlayerId && Lawkeeper.AbilityEnable && !Lawkeeper.Role.Data.IsDead);
            bool AbilityCopy = (CopyCat.Role != null && CopyCat.copyRole == 18 && CopyCat.CopyStart && CopyCat.Role != PlayerControl.LocalPlayer && __instance.PlayerId != CopyCat.Role.PlayerId && CopyCat.AbilityEnable);


            if (isReport || isCopyReport || Ability)
            {
                DeadPlayer deadPlayer = deadPlayers?.Where(x => x.player?.PlayerId == target?.PlayerId)?.FirstOrDefault();

                if (deadPlayer != null && deadPlayer.killerIfExisting != null)
                {
                    float timeSinceDeath = ((float)(DateTime.UtcNow - deadPlayer.timeOfDeath).TotalMilliseconds);
                    string msg = "";
                    string TypeofDeath = TXT_Deathreason0;

                    if (isReport || isCopyReport || Ability)
                    {

                        /** - This part of the code is not open source **/






                        if (timeSinceDeath > TimeRList.getFloat() * 1000)
                        {
                            if (LKTimer.getBool() == true)
                            {
                                if (LKInfo.getBool() == true)
                                {
                                    msg = "" + $"({Math.Round(timeSinceDeath / 1000)}s) - (" + TypeofDeath + ")";
                                }
                                else
                                {
                                    msg = "" + $"({Math.Round(timeSinceDeath / 1000)}s)";
                                }
                                    
                            }
                            else
                            {
                                if (LKInfo.getBool() == true)
                                {
                                    msg = $"(" + TypeofDeath + ")";
                                }
                                else
                                {
                                    msg = $"...";
                                }

                                    
                            }

                        }
                        else if (timeSinceDeath < TimeRName.getFloat() * 1000)
                        {
                            if (LKTimer.getBool() == true)
                            {
                                if (LKInfo.getBool() == true)
                                {
                                    msg = "" + $"({Math.Round(timeSinceDeath / 1000)}s)" + " - (" + TypeofDeath + ") - " + TXT_LawKiller + $"{deadPlayer.killerIfExisting.Data.PlayerName}" + " !";
                                }
                                else
                                {
                                    msg = "" + $"({Math.Round(timeSinceDeath / 1000)}s)" + TXT_LawKiller + $"{deadPlayer.killerIfExisting.Data.PlayerName}" + " !";
                                }
                            }
                            else
                            {
                                if (LKInfo.getBool() == true)
                                {
                                    msg = "" + "(" + TypeofDeath + ") - " + TXT_LawKiller + $"{deadPlayer.killerIfExisting.Data.PlayerName}" + " !";
                                }
                                else
                                {
                                    msg = "" + TXT_LawKiller + $"{deadPlayer.killerIfExisting.Data.PlayerName}" + " !";
                                }
                            }
                        }
                        else
                        {
                            if (LKTimer.getBool() == true)
                            {
                                var IDS = new Dictionary<byte, string>()
                                {
                                   { 0, STR_List1},
                                   { 1, STR_List2},
                                   { 2, STR_List1},
                                   { 3, STR_List2},
                                   { 4, STR_List1},
                                   { 5, STR_List2},
                                   { 6, STR_List1},
                                   { 7, STR_List2},
                                   { 8, STR_List1},
                                   { 9, STR_List2},
                                   { 10, STR_List1},
                                   { 11, STR_List2},
                                   { 12, STR_List1},
                                   { 13, STR_List2},
                                   { 14, STR_List1},
                                   { 15, STR_List2},
                                };

                                var ListofPlayer = "" + IDS[(byte)deadPlayer.killerIfExisting.Data.PlayerId];
                               
                                if (LKInfo.getBool() == true)
                                {
                                    msg = "" + "(" + TypeofDeath + ") - " + $"({Math.Round(timeSinceDeath / 1000)}s)" + TXT_LawSuspect + $"{ListofPlayer}" + " !";

                                    
                                }
                                else
                                {
                                    msg = "" + $"({Math.Round(timeSinceDeath / 1000)}s)" + TXT_LawSuspect + $"{ListofPlayer}" + " !";

                                }
                            }
                            else
                            {
                                  var IDS = new Dictionary<byte, string>()
                                  {
                                     {0, STR_List1},
                                     {1, STR_List2},
                                     {2, STR_List1},
                                     {3, STR_List2},
                                     {4, STR_List1},
                                     {5, STR_List2},
                                     {6, STR_List1},
                                     {7, STR_List2},
                                     {8, STR_List1},
                                     {9, STR_List2},
                                     {10, STR_List1},
                                     {11, STR_List2},
                                     {12, STR_List1},
                                     {13, STR_List2},
                                     {14, STR_List1},
                                     {15, STR_List2},
                                  };
                                var ListofPlayer = "" + IDS[(byte)deadPlayer.killerIfExisting.Data.PlayerId];

                                if (LKInfo.getBool() == true)
                                {
                                    msg = "" + "(" + TypeofDeath + ") - " + TXT_LawSuspect + $"{ListofPlayer}" + " !";
                                }
                                else
                                {
                                    msg = "" + TXT_LawSuspect + $"{ListofPlayer}" + " !";
                                }

                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(msg))
                    {

                        if (AmongUsClient.Instance.AmClient && DestroyableSingleton<HudManager>.Instance)
                        {
                            
                         DestroyableSingleton<HudManager>.Instance.Chat.AddChat(PlayerControl.LocalPlayer, msg);
                         
                        }
                        if (msg.IndexOf("who", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            DestroyableSingleton<Assets.CoreScripts.Telemetry>.Instance.SendWho();
                        }
                    }


                }
            }
            
        }
    }
}















