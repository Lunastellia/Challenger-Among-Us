using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
using ChallengerMod.Utility;



namespace ChallengerMod.Hats
{
    class CustomVisors
    {

        private static bool _Gun = false;
        private static bool _Knife = false;
        private static bool _Katana = false;
        private static bool _Vampire_Tooth = false;
        private static bool _Spiral = false;
        private static bool _Bloody = false;
        private static bool _Scythe = false;
        private static bool _Chain = false;
        private static bool _Coffee = false;

        private static bool _Cred = false;
        private static bool _Cpurple = false;
        private static bool _Cpink = false;
        private static bool _Cblue = false;
        private static bool _Cgreen = false;
        private static bool _Cleef = false;
        private static bool _Cyellow = false;

        private static bool _H1 = false;
        private static bool _H2 = false;
        private static bool _H3 = false;
        private static bool _H4 = false;
        private static bool _H5 = false;

        private static bool _CV1 = false;




        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetVisorById))]
        public static class AddCustomVisors
        {

            public static void Postfix(HatManager __instance)
            {
                var allVisors = __instance.allVisors;


                //ACHIEVEMENT



                if (!_Cred)
                {
                    VisorID = 193;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cred, "[Reward] Visor Red", "Lunastellia", "AC-V4", false));
                    _Cred = true;
                }
                if (!_Cpink)
                {
                    VisorID = 194;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cpink, "[Reward] Visor Pink", "Lunastellia", "AC-V5", false));
                    _Cpink = true;
                }
                if (!_Cpurple)
                {
                    VisorID = 195;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cpurple, "[Reward] Visor Purple", "Lunastellia", "AC-V7", false));
                    _Cpurple = true;
                }
                if (!_Cblue)
                {
                    VisorID = 196;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cblue, "[Reward] Visor Blue", "Lunastellia", "AC-V4", false));
                    _Cblue = true;
                }
                if (!_Cgreen)
                {
                    VisorID = 197;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cgreen, "[Reward] Visor Green", "Lunastellia", "AC-V5", false));
                    _Cgreen = true;
                }
                if (!_Cleef)
                {
                    VisorID = 198;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cleef, "[Reward] Visor Leef", "Lunastellia", "AC-V7", false));
                    _Cleef = true;
                }
                if (!_Cyellow)
                {
                    VisorID = 199;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cyellow, "[Reward] Visor Yellow", "Lunastellia", "AC-V10", false));
                    _Cyellow = true;
                }


                if (!_Gun)
                {
                    VisorID = 201;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Gun, "[Reward] Gun", "Lunastellia", "AC-V1", false));
                    _Gun = true;
                }
                if (!_Knife)
                {
                    VisorID = 202;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Knife, "[Reward] Knife", "Lunastellia", "AC-V2", false));
                    _Knife = true;
                }
                if (!_Katana)
                {
                    VisorID = 203;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Katana, "[Reward] Katana", "Lunastellia", "AC-V3", false));
                    _Katana = true;
                }
                if (!_Vampire_Tooth)
                {
                    VisorID = 206;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_VampireTooth, "[Reward] VampireTooth", "Lunastellia", "AC-V6", false));
                    _Vampire_Tooth = true;
                }
                if (!_Spiral)
                {
                    VisorID = 208;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Spiral_1, "[Reward] Strange", "Lunastellia", "AC-V8", false));
                    _Spiral = true;
                }
                if (!_Chain)
                {
                    VisorID = 209;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Fish, "[Reward] Fish", "Asman", "AC-V9", false));
                    _Chain = true;
                }
                
                if (!_Coffee)
                {
                    VisorID = 210;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Coffee, "[Reward] Coffee", "Lunastellia", "AC-V11", false));
                    _Coffee = true;
                }

                //SHOP
                if (!_Bloody)
                {
                    VisorID = 501;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Bloody, "[DLC] Blood", "Lunastellia", "SH-EAT", false));
                    _Bloody = true;
                }
                if (!_Scythe)
                {
                    VisorID = 502;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Scythe, "[DLC] Scythe", "Lunastellia", "SH-EAT", false));
                    _Scythe = true;
                }

                //PRIME
                if (!_H1)
                {
                    VisorID = 701;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_H1, "[PRIME] L.L", "Asman", "PRIME", false));
                    _H1 = true;
                }
                if (!_H2)
                {
                    VisorID = 702;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_H2, "[PRIME] S.T", "Asman", "PRIME", false));
                    _H2 = true;
                }
                if (!_H3)
                {
                    VisorID = 703;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB1, "[PRIME] Magic Wand 1", "Lunastellia", "PRIME", false));
                    _H3 = true;
                }
                if (!_H4)
                {
                    VisorID = 704;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB2, "[PRIME] Magic Wand 2", "Lunastellia", "PRIME", false));
                    _H4 = true;
                }
                if (!_H5)
                {
                    VisorID = 705;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB3, "[PRIME] Magic Wand 3", "Lunastellia", "PRIME", false));
                    _H5 = true;
                }
                if (!_CV1)
                {
                    VisorID = 706;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_C3D, "[PRIME] 3D", "Lunastellia", "PRIME", false));
                    _CV1 = true;
                }

            }
            


            public static int VisorID = 0;
            /// <summary>
            /// Creates hat based on specified values
            /// </summary>
            /// <param name="sprite"></param>
            /// <param name="author"></param>
            /// <returns>VisorData</returns>
            private static VisorData CreateVisor(Sprite sprite, string spritename, string author, string PID, bool isFree = false)
            {

                VisorData newVisor = ScriptableObject.CreateInstance<VisorData>();
                newVisor.viewData.viewData = ScriptableObject.CreateInstance<VisorViewData>();
                newVisor.name = $"{spritename} \n(by {author})";
                newVisor.viewData.viewData.IdleFrame = sprite;
                newVisor.ProductId = "visor_" + sprite.name.Replace(' ', '_');
                newVisor.BundleId = PID;
                newVisor.displayOrder = 1000 + VisorID;
                newVisor.ChipOffset = new Vector2(0f, 0.2f);
                newVisor.freeRedeemableCosmetic = false;
                newVisor.Free = isFree;

                return newVisor;
            }
        }
    }
}