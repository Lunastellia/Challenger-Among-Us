using HarmonyLib;
using System;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Hazel;
using ChallengerMod.RoleInfos;
using static ChallengerMod.Set.Data;


namespace ChallengerMod.Intropatch
{
    [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.OnDestroy))]
    [HarmonyPatch]
    class IntroPatch {
        public static void setupIntroTeamIcons(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
            // Intro solo teams
            if (PlayerControl.LocalPlayer == Cupid.Role 
                || PlayerControl.LocalPlayer == Cultist.Role 
                || PlayerControl.LocalPlayer == Outlaw.Role
                || PlayerControl.LocalPlayer == Jester.Role
                || PlayerControl.LocalPlayer == Eater.Role 
                || PlayerControl.LocalPlayer == Arsonist.Role
                || PlayerControl.LocalPlayer == Cursed.Role
                || PlayerControl.LocalPlayer == Survivor.Role
                ) 
            {
                var soloTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
                soloTeam.Add(PlayerControl.LocalPlayer);
                yourTeam = soloTeam;
            }

            // Add the Fake (for the Impostors)
            if (Fake.Role != null && PlayerControl.LocalPlayer.Data.Role.IsImpostor) {
                List<PlayerControl> players = PlayerControl.AllPlayerControls.ToArray().ToList().OrderBy(x => Guid.NewGuid()).ToList();
                var fakeImpostorTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>(); // The local player always has to be the first one in the list (to be displayed in the center)
                fakeImpostorTeam.Add(PlayerControl.LocalPlayer);
                foreach (PlayerControl p in players) {
                    if (PlayerControl.LocalPlayer != p && (p == Fake.Role || p.Data.Role.IsImpostor))
                        fakeImpostorTeam.Add(p);
                }
                yourTeam = fakeImpostorTeam;
            }
            // Add the Spy to the Impostor team (for the Impostors)
            




        }

        public static void setupIntroTeam(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
            List<RoleInfo> infos = RoleInfo.getRoleInfoForPlayer(PlayerControl.LocalPlayer);
            RoleInfo roleInfo = infos.FirstOrDefault();
            if (roleInfo == null) return;
            if (roleInfo.isSpecialRole) 
            {
                if (PlayerControl.LocalPlayer == Arsonist.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Arsonist.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Arsonist.name;
                    __instance.TeamTitle.color = SpecialColor;
                }
                if (PlayerControl.LocalPlayer == Jester.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Jester.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Jester.name;
                    __instance.TeamTitle.color = SpecialColor;
                }
                if (PlayerControl.LocalPlayer == Eater.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Eater.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Eater.name;
                    __instance.TeamTitle.color = SpecialColor;
                }
                if (PlayerControl.LocalPlayer == Cupid.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Cupid.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Cupid.name;
                    __instance.TeamTitle.color = SpecialColor;
                }
                if (PlayerControl.LocalPlayer == Cultist.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Cultist.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Cultist.name;
                    __instance.TeamTitle.color = SpecialColor;
                }
                if (PlayerControl.LocalPlayer == Outlaw.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Outlaw.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Outlaw.name;
                    __instance.TeamTitle.color = SpecialColor;
                }
                if (PlayerControl.LocalPlayer == Cursed.Role)
                {
                    var SpecialColor = RoleInfos.RoleInfo._Cursed.color;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = RoleInfos.RoleInfo._Cursed.name;
                    __instance.TeamTitle.color = SpecialColor;
                }

                if (PlayerControl.LocalPlayer == Survivor.Role)
                {
                    var SpecialColor = ChallengerMod.ColorTable.DuoColor;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = SizeTT + R_CrewmateColor + Role_Crewmate + CC + C_WhiteColor + " / " + CC + R_ImpostorColor + Role_Impostor + CC + CZ ;
                }
                if (PlayerControl.LocalPlayer == Mercenary.Role)
                {
                    var SpecialColor = ChallengerMod.ColorTable.DuoColor;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = SizeTT + R_CrewmateColor + Role_Crewmate + CC + C_WhiteColor + " / " + CC + R_ImpostorColor + Role_Impostor + CC + CZ;
                }
                if (PlayerControl.LocalPlayer == CopyCat.Role)
                {
                    var SpecialColor = ChallengerMod.ColorTable.DuoColor;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = SizeTT + R_CrewmateColor + Role_Crewmate + CC + C_WhiteColor + " / " + CC + R_ImpostorColor + Role_Impostor + CC + CZ;
                }
                if (PlayerControl.LocalPlayer == Revenger.Role)
                {
                    var SpecialColor = ChallengerMod.ColorTable.DuoColor;
                    __instance.BackgroundBar.material.color = SpecialColor;
                    __instance.TeamTitle.text = SizeTT + R_CrewmateColor + Role_Crewmate + CC + C_WhiteColor + " / " + CC + R_ImpostorColor + Role_Impostor + CC + CZ;
                }




            }
            else
            {
                if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    var ImpoColor = ChallengerMod.ColorTable.ImpostorColor;
                    __instance.BackgroundBar.material.color = ImpoColor;
                    __instance.TeamTitle.text = R_ImpostorColor + Role_Impostor + CC;
                    
                }
                else
                {
                    var CrewColor = ChallengerMod.ColorTable.CrewmateColor;
                    __instance.BackgroundBar.material.color = CrewColor;
                    __instance.TeamTitle.text = R_CrewmateColor + Role_Crewmate + CC;
                }

            }
        }

        public static IEnumerator<WaitForSeconds> EndShowRole(IntroCutscene __instance) {
            yield return new WaitForSeconds(5f);
            __instance.YouAreText.gameObject.SetActive(false);
            __instance.RoleText.gameObject.SetActive(false);
            __instance.RoleBlurbText.gameObject.SetActive(false);
            __instance.ourCrewmate.gameObject.SetActive(false);
        }
        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.CreatePlayer))]
        class CreatePlayerPatch
        {
            public static void Postfix(IntroCutscene __instance, bool impostorPositioning, ref PoolablePlayer __result)
            {
                if (impostorPositioning) __result.SetNameColor(Palette.ImpostorRed);
            }
        }
        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.ShowRole))]
        class SetUpRoleTextPatch {
            static public void SetRoleTexts(IntroCutscene __instance) {
                // Don't override the intro of the vanilla roles
                List<RoleInfo> infos = RoleInfo.getRoleInfoForPlayer(PlayerControl.LocalPlayer);
                RoleInfo roleInfo = infos.FirstOrDefault();
                __instance.RoleBlurbText.text = "";
                if (roleInfo != null) {

                    if (Teammate1.Role != null && PlayerControl.LocalPlayer == Teammate1.Role)
                    {
                        __instance.RoleText.text = Role_Teammate;
                        __instance.RoleText.color = roleInfo.color;
                        __instance.RoleBlurbText.text = "<size=2>" + roleInfo.introDescription + "</size>";
                        __instance.RoleBlurbText.color = roleInfo.color;
                    }
                    else if (Teammate2.Role != null && PlayerControl.LocalPlayer == Teammate2.Role)
                    {
                        __instance.RoleText.text = Role_Teammate;
                        __instance.RoleText.color = roleInfo.color;
                        __instance.RoleBlurbText.text = "<size=2>" + roleInfo.introDescription + "</size>";
                        __instance.RoleBlurbText.color = roleInfo.color;
                    }
                    else
                    {
                        __instance.RoleText.text = roleInfo.name;
                        __instance.RoleText.color = roleInfo.color;
                        __instance.RoleBlurbText.text = "<size=2>" + roleInfo.introDescription + "</size>";
                        __instance.RoleBlurbText.color = roleInfo.color;
                    }
                    


                    
                    //Common Set
                }
                
            }
            public static bool Prefix(IntroCutscene __instance)
            {
                
                HudManager.Instance.StartCoroutine(Effects.Lerp(1f, new Action<float>((p) => {
                    SetRoleTexts(__instance);
                })));
                return true;
            }

        }

        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.BeginCrewmate))]
        class BeginCrewmatePatch {




            public static void Prefix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> teamToDisplay) {
                setupIntroTeamIcons(__instance, ref teamToDisplay);
            }

            public static void Postfix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> teamToDisplay) {
                setupIntroTeam(__instance, ref teamToDisplay);
                
            }
        }

        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.BeginImpostor))]
        class BeginImpostorPatch {
            public static void Prefix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
                setupIntroTeamIcons(__instance, ref yourTeam);
            }

            public static void Postfix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
                setupIntroTeam(__instance, ref yourTeam);

                
            }
        }
    }
}

