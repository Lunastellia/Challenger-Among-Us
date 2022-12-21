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
    class CustomHats
    {
        public static Material MagicShader;

        //0 Personnal
        private static bool _Stellia = false;
        private static bool _Mini = false;
        private static bool _Pom2 = false;
        private static bool _Noeud = false;
        private static bool _Val = false;



        //200 - Achievement
        private static bool _Demon = false;
        private static bool _Angel = false;
        private static bool _DinoKawaii = false;
        private static bool _Angry = false;
        private static bool _Vampire = false;
        private static bool _Pom = false;
        private static bool _Strange = false;
        private static bool _Crazy = false;
        private static bool _Alien = false;
        private static bool _Barghest = false;
        private static bool _Bomber = false;
        private static bool _Dragon = false;

        private static bool _Ears = false;
        private static bool _Licorne = false;


        private static bool _Brain = false;
        private static bool _Horror = false;
        private static bool _Reaper = false;
        private static bool _WhiteMask = false;

        private static bool _HP1 = false;
        private static bool _HP2 = false;
        private static bool _HP3 = false;
        private static bool _HP4 = false;
        private static bool _HP5 = false;
        private static bool _HP6 = false;
        private static bool _HP7 = false;
        private static bool _HP8 = false;

        private static bool _HP9 = false;
        private static bool _HP10 = false;
        private static bool _HP11 = false;
        private static bool _HP12 = false;
        private static bool _HP13 = false;

        private static bool _WH1 = false;
        private static bool _WH2 = false;
        private static bool _WH3 = false;
        private static bool _WH4 = false;
        private static bool _WH5 = false;
        private static bool _WH6 = false;
        private static bool _WH7 = false;
        private static bool _WH8 = false;
        private static bool _WH9 = false;
        private static bool _WH10 = false;
        private static bool _WH11 = false;
        private static bool _WH12 = false;
        private static bool _WH13 = false;
        private static bool _WH14 = false;

        private static bool _C1 = false;
        private static bool _C2 = false;
        private static bool _C3 = false;
        private static bool _C4 = false;
        private static bool _C5 = false;


        private static bool _Bee = false;
        private static bool _Cat = false;
        private static bool _Fluffy = false;
        private static bool _CatEars = false;
        private static bool _LilyPin = false;
        private static bool _ShootingStar = false;
        private static bool _WitchHat = false;
        private static bool _Toast = false;
        private static bool _Cake = false;




        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetHatById))]
        public static class AddCustomHats
        {



            public static void Postfix(HatManager __instance) {


                var allHats = __instance.allHats;

                //CREATOR
                if (!_Stellia)
                {
                    HatID = 100;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC00, "Lunastellia - [For Stellia]", "Lunastellia", "CC-00", null, null, null, false, false, false, false));
                    _Stellia = true;
                }
                if (!_Pom2)
                {
                    HatID = 101;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Pom2, "Pom Biboune - [For Emy]", "LilyPichou / Lunastellia", "CC-02", null, null, null, false, false, false, false));
                    _Pom2 = true;
                }
                if (!_Mini)
                {
                    HatID = 102;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC02, "Mini - [For Emy]", "Asman", "CC-02", null, null, null, false, false, false, false));
                    _Mini = true;
                }
                if (!_Noeud)
                {
                    HatID = 103;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC03, "Noeud - [For Asman]", "Asman", "CC-03", null, null, null, false, true, false, false));
                    _Noeud = true;
                }
                if (!_Val)
                {
                    HatID = 104;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC04, "Avion - [For Val]", "Val", "CC-04", null, null, null, false, false, false, false));
                    _Val = true;
                }

                //ACHIEVEMENT
                if (!_Demon) 
                {
                    HatID = 201;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Demon, "[Reward] Demon", "Lunastellia", "AC-H1", null, null, null, false, false, false, false));
                    _Demon = true;
                }
                
                if (!_Angel)
                {
                    HatID = 202;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Angel, "[Reward] Angel", "Asman", "AC-H2", null, null, null, false, false, false, false));
                    _Angel = true;
                }
                if (!_Vampire)
                {
                    HatID = 203;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Vampire, "[Reward] Vampire", "Lunastellia", "AC-H3", null, null, null, false, false, false, false));
                    _Vampire = true;
                }
                if (!_DinoKawaii)
                {
                    HatID = 204;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Kawaii, "[Reward] Kawaii", "Asman", "AC-H4", null, null, null, false, true, false, true));
                    _DinoKawaii = true;
                }
                if (!_Angry)
                {
                    HatID = 205;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Angry, "[Reward] Angry", "Lunastellia", "AC-H5", null, null, null, false, true, false, false));
                    _Angry = true;
                }
                
                if (!_Pom)
                {
                    HatID = 206;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Pom, "[Reward] Pom", "LyliPichou", "AC-H6", null, null, null, false, false, false, false));
                    _Pom = true;
                }
                if (!_Strange)
                {
                    HatID = 207;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Strange, "[Reward] Stranger", "Lunastellia", "AC-H7", null, null, null, false, true, false, true));
                    _Strange = true;
                }
                if (!_Crazy)
                {
                    HatID = 208;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Clown, "[Reward] Clown", "Asman", "AC-H8", null, null, null, false, false, false, false));
                    _Crazy = true;
                }
                if (!_Licorne)
                {
                    HatID = 209;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Licorne, "[Reward] Unicorn", "Lunastellia", "AC-H9", null, null, null, false, false, false, false));
                    _Licorne = true;
                }
                if (!_Ears)
                {
                    HatID = 210;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Ears, "[Reward] Ears", "Lunastellia", "AC-H10", null, null, null, false, false, false, false));
                    _Ears = true;
                }

                if (!_Alien)
                {
                    HatID = 211;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Alien, "[Reward] Alien", "Asman/Lunastellia", "AC-H11", null, null, null, false, true, false, true));
                    _Alien = true;
                }
                if (!_Barghest)
                {
                    HatID = 212;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Mask, "[Reward] Mask", "Asman", "AC-H12", null, null, null, false, false, false, false));
                    _Barghest = true;
                }
                if (!_Bomber)
                {
                    HatID = 213;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Bomber, "[Reward] Bomber", "Lunastellia", "AC-H13", null, null, null, false, false, false, false));
                    _Bomber = true;
                }
                if (!_Dragon)
                {
                    HatID = 214;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Dragon, "[Reward] Dragon", "Asman", "AC-H14", null, null, null, false, false, false, false));
                    _Dragon = true;
                }

                //LILYPICHOU
                if (!_Bee)
                {
                    HatID = 401;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Bee, "[EGG] Bee", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _Bee = true;
                }
                if (!_Cat)
                {
                    HatID = 402;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Cat, "[EGG] Cat", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _Cat = true;
                }
                if (!_Fluffy)
                {
                    HatID = 403;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Fluffy, "[EGG] Fluffy", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _Fluffy = true;
                }
                if (!_CatEars)
                {
                    HatID = 404;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CatEars, "[EGG] Cat Ears", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _CatEars = true;
                }
                if (!_LilyPin)
                {
                    HatID = 405;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_LilyPin, "[EGG] Lily Pin", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _LilyPin = true;
                }
                if (!_ShootingStar)
                {
                    HatID = 406;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_ShootingStar, "[EGG] Shooting Star", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _ShootingStar = true;
                }
                if (!_WitchHat)
                {
                    HatID = 407;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WitchHat, "[EGG] Witch Hat", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _WitchHat = true;
                }
                if (!_Toast)
                {
                    HatID = 408;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Toast, "[EGG] Toast", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _Toast = true;
                }
                if (!_Cake)
                {
                    HatID = 409;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Cake, "[EGG] Cake", "LyliPichou", "SH-LILY", null, null, null, false, false, false, false));
                    _Cake = true;
                }

                //SHOP - Eater
                if (!_Brain)
                {
                    HatID = 501;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Brain, "[DLC] Brain", "Lunastellia", "SH-EAT", null, null, null, false, false, false, false));
                    _Brain = true;
                }
                if (!_Horror)
                {
                    HatID = 502;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Horror, "[DLC] Horror", "Lunastellia", "SH-EAT", null, null, null, false, true, false, false));
                    _Horror = true;
                }
                if (!_Reaper)
                {
                    HatID = 503;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Reaper, "[DLC] Reaper", "Lunastellia", "SH-EAT", null, null, null, false, false, false, false));
                    _Reaper = true;
                }
                if (!_WhiteMask)
                {
                    HatID = 504;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WhiteMask, "[DLC] Hollow", "Lunastellia", "SH-EAT", null, null, ChallengerMod.Unity._Hat_WhiteMask_L, false, false, false, false));
                    _WhiteMask = true;
                }

                

                //PRIME
                if (!_HP1)
                {
                    HatID = 701;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar1, "[PRIME] - H.P", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP1 = true;
                }
                if (!_HP2)
                {
                    HatID = 702;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar2, "[PRIME] - R.W", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP2 = true;
                }
                if (!_HP3)
                {
                    HatID = 703;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar3, "[PRIME] - H.G", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP3 = true;
                }
                if (!_HP4)
                {
                    HatID = 704;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar4, "[PRIME] - D.M", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP4 = true;
                }
                if (!_HP5)
                {
                    HatID = 705;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar5, "[PRIME] - L.L", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP5 = true;
                }
                if (!_HP6)
                {
                    HatID = 706;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar6, "[PRIME] - S.T", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP6 = true;
                }
                if (!_HP7)
                {
                    HatID = 707;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar7, "[PRIME] - Q.Q", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP7 = true;
                }
                if (!_HP8)
                {
                    HatID = 708;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar8, "[PRIME] - A.D", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP8 = true;
                }
                if (!_HP9)
                {
                    HatID = 709;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HH1, "[PRIME] - Magic Hat", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP9 = true;
                }
                if (!_HP10)
                {
                    HatID = 710;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS1, "[PRIME] - Scarf1", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP10 = true;
                }
                if (!_HP11)
                {
                    HatID = 711;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS2, "[PRIME] - Scarf2", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP11 = true;
                }
                if (!_HP12)
                {
                    HatID = 712;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS3, "[PRIME] - Scarf3", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP12 = true;
                }
                if (!_HP13)
                {
                    HatID = 713;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS4, "[PRIME] - Scarf4", "Asman", "PRIME", null, null, null, false, false, false, false));
                    _HP13 = true;
                }


                if (!_WH1)
                {
                    HatID = 714;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHIronMask, "[PRIME] - IronMask", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH1 = true;
                }
                if (!_WH2)
                {
                    HatID = 715;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHSkipperman, "[PRIME] - Skipper-Man", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH2 = true;
                }
                if (!_WH3)
                {
                    HatID = 716;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHCaptain, "[PRIME] - Captain", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH3 = true;
                }
                if (!_WH4)
                {
                    HatID = 717;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHBruce, "[PRIME] - Bruce", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _WH4 = true;
                }
                if (!_WH5)
                {
                    HatID = 718;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHBlacky, "[PRIME] - Blacky", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH5 = true;
                }
                if (!_WH6)
                {
                    HatID = 719;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHThor, "[PRIME] - Thor", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH6 = true;
                }
                if (!_WH7)
                {
                    HatID = 720;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHStranger, "[PRIME] - Strange", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH7 = true;
                }
                if (!_WH8)
                {
                    HatID = 721;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHTiger, "[PRIME] - Panther", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _WH8 = true;
                }
                if (!_WH9)
                {
                    HatID = 722;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHSlash, "[PRIME] - Slash", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH9 = true;
                }
                if (!_WH10)
                {
                    HatID = 723;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHDevour, "[PRIME] - Symbiote", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH10 = true;
                }
                if (!_WH11)
                {
                    HatID = 724;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHMyster, "[PRIME] - Mysterious", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH11 = true;
                }
                if (!_WH12)
                {
                    HatID = 725;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHJoker, "[PRIME] - Joker", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH12 = true;
                }
                if (!_WH13)
                {
                    HatID = 726;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHQuenny, "[PRIME] - Queeny", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _WH13 = true;
                }

                if (!_WH14)
                {
                    HatID = 727;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHCutter, "[PRIME] - Screamer", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _WH14 = true;
                }

                if (!_C1)
                {
                    HatID = 728;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CPopCorn, "[PRIME] - Cine PopCorn", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _C1 = true;
                }
                if (!_C2)
                {
                    HatID = 729;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_COscar, "[PRIME] - Cine Oscar", "Lunastellia", "PRIME", null, null, null, false, false, false, true));
                    _C2 = true;
                }
                if (!_C3)
                {
                    HatID = 730;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CSound, "[PRIME] - Cine Sound", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _C3 = true;
                }
                if (!_C4)
                {
                    HatID = 731;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CLight, "[PRIME] - Cine Light", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _C4 = true;
                }
                if (!_C5)
                {
                    HatID = 732;
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CCamera, "[PRIME] - Cine Camera", "Lunastellia", "PRIME", null, null, null, false, true, false, true));
                    _C5 = true;
                }





            }

            

            public static int HatID = 0;
            /// <summary>
            /// Creates hat based on specified values
            /// </summary>
            /// <param name="sprite"></param>
            /// <param name="author"></param>
            /// <param name="climb"></param>
            /// <param name="floor"></param>
            /// <param name="leftimage"></param>
            /// <param name="bounce"></param>
            /// <param name="altshader"></param>
            /// <returns>HatData</returns>
            private static HatData CreateHat(Sprite sprite, string spritename, string author, string PID, Sprite climb = null, Sprite floor = null, Sprite leftimage = null, bool bounce = false, bool altshader = false, bool isFree = false, bool Enable = false) {
				//Borrowed from Other Roles to get hats alt shaders to work
                if (MagicShader == null) {
                    Material hatShader = new Material("PlayerMaterial");
                    hatShader.shader = Shader.Find("Unlit/PlayerShader");
                    MagicShader = hatShader;
                }

                HatData newHat = ScriptableObject.CreateInstance<HatData>();
                newHat.hatViewData.viewData = ScriptableObject.CreateInstance<HatViewData>();
                newHat.name = $"{spritename} \n(by {author})";
                newHat.hatViewData.viewData.MainImage = sprite;
                newHat.ProductId = "hat_" + sprite.name.Replace(' ', '_');
                newHat.BundleId = PID;
                newHat.displayOrder = 1000 + HatID;
                newHat.InFront = true;
                newHat.NoBounce = bounce;
                newHat.hatViewData.viewData.FloorImage = floor;
                newHat.hatViewData.viewData.ClimbImage = climb;
                newHat.hatViewData.viewData.LeftMainImage = leftimage;
                newHat.ChipOffset = new Vector2(-0.1f, 0.4f);
                newHat.freeRedeemableCosmetic = false;
                newHat.Free = isFree;
                newHat.BlocksVisors = Enable;

                if (altshader == true) { newHat.hatViewData.viewData.AltShader = MagicShader; }

                return newHat;
            }
        }
    }
}
