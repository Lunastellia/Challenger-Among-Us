using HarmonyLib;
using Hazel;
using System;
using System.Collections.Generic;
using UnityEngine;
using static ChallengerMod.HarmonyMain;
using System.Linq;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using TMPro;
using RewiredConsts;

//using ChallengerMod.Arrow;

namespace ChallengerMod
{

    public class UseCustomvitals
    {
        public VitalsMinigame VitalsPrefab;
        
        private VitalsMinigame minigame;
        private float currentCharge;
        private float currentCooldown;

        
        public void UseAbility()
        {
            
            
                PlayerControl.LocalPlayer.NetTransform.Halt();
                this.minigame = UnityEngine.Object.Instantiate<VitalsMinigame>(this.VitalsPrefab);
                ((Component)this.minigame).transform.SetParent(((Component)Camera.main).transform, false);
                ((Component)this.minigame).transform.localPosition = new Vector3(0.0f, 0.0f, -50f);
                ((Component)this.minigame.BatteryText).gameObject.SetActive(true);
                this.minigame.Begin((PlayerTask)null);
                

        }

    }


    [HarmonyPatch]
   
    public static class Unity
    { /** - This part of the code is not open source **/

        private static Sprite animatedVentSealedSpritebar;

       

       



        public static Sprite getAnimatedVentSealedSpritebar()
        {
            if (animatedVentSealedSpritebar) return animatedVentSealedSpritebar;
            animatedVentSealedSpritebar = ventmapIco;
            return animatedVentSealedSpritebar;
        }

        private static Sprite staticVentSealedSpritebar;
        public static Sprite getStaticVentSealedSpritebar()
        {
            if (staticVentSealedSpritebar) return staticVentSealedSpritebar;
            staticVentSealedSpritebar = ventmapIco;
            return staticVentSealedSpritebar;
        }

        //all
        private static Sprite animatedVentSealedSprite;
        public static Sprite getAnimatedVentSealedSprite()
        {
            if (animatedVentSealedSprite) return animatedVentSealedSprite;
            animatedVentSealedSprite = BlockVentall;
            return animatedVentSealedSprite;
        }

        private static Sprite staticVentSealedSprite;
        public static Sprite getStaticVentSealedSprite()
        {
            if (staticVentSealedSprite) return staticVentSealedSprite;
            staticVentSealedSprite = BlockVentall;
            return staticVentSealedSprite;
        }

        //user
        private static Sprite animatedVentSealedSpriteuse;
        public static Sprite getAnimatedVentSealedSpriteuse()
        {
            if (animatedVentSealedSpriteuse) return animatedVentSealedSpriteuse;
            animatedVentSealedSpriteuse = BlockVentuse;
            return animatedVentSealedSpriteuse;
        }

        private static Sprite staticVentSealedSpriteuse;
        public static Sprite getStaticVentSealedSpriteuse()
        {
            if (staticVentSealedSpriteuse) return staticVentSealedSpriteuse;
            staticVentSealedSpriteuse = BlockVentuse;
            return staticVentSealedSpriteuse;
        }

    } 

}