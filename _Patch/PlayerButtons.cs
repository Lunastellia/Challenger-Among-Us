using HarmonyLib;
using Hazel;
using System;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using System.Linq;
using ChallengerMod.CustomButton;
using System.Collections.Generic;
using ChallengerMod.Patches;
using ChallengerMod.Utils;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using ChallengerMod.RPC;
using static ChallengerMod.Set.Data;


namespace ChallengerMod.CustomButton
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Start))]
    static class HudManagerStartPatch
    {

        //ALL
        private static CustomButton SetUI;
        private static CustomButton AdminButton;
        private static CustomButton CamButton;
        private static CustomButton VitalButton;
        private static CustomButton BuzzButton;
        private static CustomButton NuclearTimerButton;
        // CREWMATES
        private static CustomButton Sheriff1KillButton;
        private static CustomButton Sheriff2KillButton;
        private static CustomButton Sheriff3KillButton;
        private static CustomButton GuardianAbilityButton;
        private static CustomButton EngineerAbilityButton;
        private static CustomButton TimelordAbilityButton;
        private static CustomButton HunterAbilityButton;
        private static CustomButton MysticAbilityButton;
        private static CustomButton SpiritAbilityButton;
        private static CustomButton MayorAbilityButton;
        private static CustomButton DetectiveAbilityButton;
        private static CustomButton NightwatchAbilityButton;
        private static CustomButton SpyAbilityButton;
        private static CustomButton InformantAbilityButton;
        private static CustomButton MentalistAbilityButton;
        private static CustomButton BuilderAbilityButton;
        private static CustomButton DictatorAbilityButton;
        private static CustomButton SentinelAbilityButton;
        private static CustomButton SentinelVentButton;
        private static CustomButton SentinelBodyButton;

        

        //SPECIALS
        private static CustomButton CupidAbilityButton;
        private static CustomButton CultistAbilityButton;
        private static CustomButton OutlawKillButton;
        private static CustomButton JesterAbilityButton;
        private static CustomButton EaterEatAbilityButton;
        private static CustomButton EaterDraggAbilityButton;
        private static CustomButton EaterBarAbilityButton;
        private static CustomButton ArsonistOilAbilityButton;

        private static CustomButton CursedBarAbilityButton;
        //private static CustomButton CursedUpAbilityButton;
        private static CustomButton CursedAbilityButton;

        //HYBRID
        private static CustomButton MercenaryKillButton;
        private static CustomButton CopyCatScanAbilityButton;
        private static CustomButton CopyCatSheriffButton;
        private static CustomButton CopyCatGuardianButton;
        private static CustomButton CopyCatHunterButton;
        private static CustomButton CopyCatInformantButton;
        private static CustomButton CopyCatKillButton;



        private static CustomButton RevengerAbilityButton;

        //IMPOSTOR
        private static CustomButton AssassinKillButton;
        private static CustomButton AssassinTimelordAbilityButton;
        private static CustomButton VectorInfectAbilityButton;
        private static CustomButton VectorKillButton;

        private static CustomButton MorphlingKillButton;
        private static CustomButton MorphlingScanAbilityButton;
        private static CustomButton MorphlingMorphAbilityButton;
        private static CustomButton ScramblerAbilityButton;
        private static CustomButton ScramblerKillButton;
        private static CustomButton BarghestShadowAbilityButton;
        private static CustomButton BarghestCreateVentAbilityButton;
        private static CustomButton BarghestKillButton;
        private static CustomButton GhostAbilityButton;
        private static CustomButton GhostKillButton;
        private static CustomButton Sorcerer1AbilityButton;
        private static CustomButton Sorcerer2AbilityButton;
        private static CustomButton Sorcerer3AbilityButton;
        private static CustomButton Sorcerer4AbilityButton;
        private static CustomButton SorcererFindAbilityButton;
        private static CustomButton SorcererKillButton;
        private static CustomButton GuesserKillButton;
        private static CustomButton BasiliskKillButton;
        private static CustomButton BasiliskAbilityButton;
        private static CustomButton BasiliskAbility2Button;

        
        private static CustomButton Impostor1KillButton;
        private static CustomButton Impostor2KillButton;
        private static CustomButton Impostor3KillButton;

        public static TMPro.TMP_Text AdminText;
        public static TMPro.TMP_Text VitalText;
        public static TMPro.TMP_Text CamText;
        public static TMPro.TMP_Text BuzzText;
        public static TMPro.TMP_Text NuclearTimerText;
        public static TMPro.TMP_Text VentText;
        public static TMPro.TMP_Text BodyText;
        public static TMPro.TMP_Text OilText;
        public static TMPro.TMP_Text RuneText;
        public static TMPro.TMP_Text PetrifyText;
        public static TMPro.TMP_Text ParalyzeText;


        public static TMPro.TMP_Text loverText;




        public static void UpdateCustomButtonCooldowns()
        {




            ChallengerMod.CustomButton.HudManagerStartPatch.AdminButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.VitalButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CamButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BuzzButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SentinelVentButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SentinelBodyButton.showButtonText = true;



            ChallengerMod.CustomButton.HudManagerStartPatch.Sheriff1KillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Sheriff2KillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Sheriff3KillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.GuardianAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.EngineerAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.TimelordAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.HunterAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.MysticAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SpiritAbilityButton.showButtonText = true;


            ChallengerMod.CustomButton.HudManagerStartPatch.NightwatchAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.DetectiveAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SpyAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.MentalistAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SentinelAbilityButton.showButtonText = true;

            ChallengerMod.CustomButton.HudManagerStartPatch.DictatorAbilityButton.showButtonText = true;


            ChallengerMod.CustomButton.HudManagerStartPatch.JesterAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CupidAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CultistAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.EaterDraggAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.EaterBarAbilityButton.showButtonText = false;




            ChallengerMod.CustomButton.HudManagerStartPatch.CopyCatScanAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CopyCatSheriffButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CopyCatGuardianButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CopyCatHunterButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CopyCatInformantButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CopyCatKillButton.showButtonText = true;



            ChallengerMod.CustomButton.HudManagerStartPatch.RevengerAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.ArsonistOilAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.CursedAbilityButton.showButtonText = true;




            ChallengerMod.CustomButton.HudManagerStartPatch.MercenaryKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.OutlawKillButton.showButtonText = true;

            ChallengerMod.CustomButton.HudManagerStartPatch.VectorInfectAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.VectorKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.MorphlingMorphAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.MorphlingScanAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BarghestCreateVentAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BarghestShadowAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.ScramblerAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.GhostAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SorcererFindAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Sorcerer1AbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Sorcerer2AbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Sorcerer3AbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Sorcerer4AbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BasiliskAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BasiliskAbility2Button.showButtonText = true;


            ChallengerMod.CustomButton.HudManagerStartPatch.AssassinTimelordAbilityButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.AssassinKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Impostor1KillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Impostor2KillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.Impostor3KillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.MorphlingKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.ScramblerKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BarghestKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.GhostKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.SorcererKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.GuesserKillButton.showButtonText = true;
            ChallengerMod.CustomButton.HudManagerStartPatch.BasiliskKillButton.showButtonText = true;





            /** - This part of the code is not open source **/


        }
    }

        public static void setCustomButtonCooldowns()
        {

            SetUI.MaxTimer = 0f;
            AdminButton.MaxTimer = 0f;
            CamButton.MaxTimer = 0f;
            VitalButton.MaxTimer = 0f;
            BuzzButton.MaxTimer = 0f;
            NuclearTimerButton.MaxTimer = 0f;
            SentinelVentButton.MaxTimer = 0f;
            SentinelBodyButton.MaxTimer = 0f;
            EaterBarAbilityButton.MaxTimer = 0f;
            CursedBarAbilityButton.MaxTimer = 0f;
            // CursedUpAbilityButton.MaxTimer = 0f;

            SetUI.StartTimer = 0f;
            AdminButton.StartTimer = 0f;
            CamButton.StartTimer = 0f;
            VitalButton.StartTimer = 0f;
            BuzzButton.StartTimer = 0f;
            NuclearTimerButton.StartTimer = 0f;
            SentinelVentButton.StartTimer = 0f;
            SentinelBodyButton.StartTimer = 0f;
            EaterBarAbilityButton.StartTimer = 0f;
            CursedBarAbilityButton.StartTimer = 0f;
            // CursedUpAbilityButton.StartTimer = 0f;

            SetUI.Timer = 0f;
            AdminButton.Timer = 0f;
            CamButton.Timer = 0f;
            VitalButton.Timer = 0f;
            BuzzButton.Timer = 0f;
            NuclearTimerButton.Timer = 0f;
            SentinelVentButton.Timer = 0f;
            SentinelBodyButton.Timer = 0f;
            EaterBarAbilityButton.Timer = 0f;
            CursedBarAbilityButton.Timer = 0f;
            //  CursedUpAbilityButton.Timer = 0f;

            //CREWMATES
            Sheriff1KillButton.MaxTimer = SheriffKillButtonMaxTimer;
            Sheriff2KillButton.MaxTimer = SheriffKillButtonMaxTimer;
            Sheriff3KillButton.MaxTimer = SheriffKillButtonMaxTimer;
            Sheriff1KillButton.StartTimer = 10f;
            Sheriff2KillButton.StartTimer = 10f;
            Sheriff3KillButton.StartTimer = 10f;
            CopyCatSheriffButton.MaxTimer = SheriffKillButtonMaxTimer;
            CopyCatSheriffButton.StartTimer = 10f;


            GuardianAbilityButton.MaxTimer = GuardianAbilityButtonMaxTimer;
            GuardianAbilityButton.StartTimer = 5f;
            CopyCatGuardianButton.MaxTimer = GuardianAbilityButtonMaxTimer;
            CopyCatGuardianButton.StartTimer = 5f;


            EngineerAbilityButton.MaxTimer = EngineerAbilityButtonMaxTimer;
            EngineerAbilityButton.StartTimer = EngineerAbilityButtonMaxTimer;


            TimelordAbilityButton.MaxTimer = TimelordAbilityButtonMaxTimer;
            TimelordAbilityButton.EffectDuration = TimelordAbilityButtonEffectDuration;
            TimelordAbilityButton.StartTimer = TimelordAbilityButtonMaxTimer;


            HunterAbilityButton.MaxTimer = HunterAbilityButtonMaxTimer;
            HunterAbilityButton.StartTimer = 5f;
            CopyCatHunterButton.MaxTimer = HunterAbilityButtonMaxTimer;
            CopyCatHunterButton.StartTimer = 5f;



            MysticAbilityButton.MaxTimer = MysticAbilityButtonMaxTimer;
            MysticAbilityButton.EffectDuration = MysticAbilityButtonEffectDuration;
            MysticAbilityButton.StartTimer = MysticAbilityButtonMaxTimer;



            SpiritAbilityButton.MaxTimer = SpiritAbilityButtonMaxTimer;
            SpiritAbilityButton.StartTimer = 0f;



            MayorAbilityButton.MaxTimer = MayorAbilityButtonMaxTimer;
            MayorAbilityButton.StartTimer = 15f;


            DetectiveAbilityButton.MaxTimer = DetectiveAbilityButtonMaxTimer;
            DetectiveAbilityButton.EffectDuration = DetectiveAbilityButtonEffectDuration;
            DetectiveAbilityButton.StartTimer = DetectiveAbilityButtonEffectDuration;

            NightwatchAbilityButton.MaxTimer = NightwatchAbilityButtonMaxTimer;
            NightwatchAbilityButton.EffectDuration = NightwatchAbilityButtonEffectDuration;
            NightwatchAbilityButton.StartTimer = NightwatchAbilityButtonMaxTimer;


            SpyAbilityButton.MaxTimer = SpyAbilityButtonMaxTimer;
            SpyAbilityButton.EffectDuration = SpyAbilityButtonEffectDuration;
            SpyAbilityButton.StartTimer = 5f;



            InformantAbilityButton.MaxTimer = InformantAbilityButtonMaxTimer;
            InformantAbilityButton.StartTimer = 5f;
            CopyCatInformantButton.MaxTimer = InformantAbilityButtonMaxTimer;
            CopyCatInformantButton.StartTimer = 5f;



            MentalistAbilityButton.MaxTimer = MentalistAbilityButtonMaxTimer;
            MentalistAbilityButton.EffectDuration = MentalistAbilityButtonEffectDuration;
            MentalistAbilityButton.StartTimer = MentalistAbilityButtonMaxTimer;


            BuilderAbilityButton.MaxTimer = BuilderAbilityButtonMaxTimer;
            BuilderAbilityButton.StartTimer = BuilderAbilityButtonMaxTimer;



            DictatorAbilityButton.MaxTimer = DictatorAbilityButtonMaxTimer;
            DictatorAbilityButton.StartTimer = 5f;



            SentinelAbilityButton.MaxTimer = SentinelAbilityButtonMaxTimer;
            SentinelAbilityButton.EffectDuration = SentinelAbilityButtonEffectDuration;
            SentinelAbilityButton.StartTimer = SentinelAbilityButtonMaxTimer;


            //HYBRID
            MercenaryKillButton.MaxTimer = MercenaryKillButtonMaxTimer;
            MercenaryKillButton.StartTimer = MercenaryKillButtonMaxTimer * 2;

            CopyCatScanAbilityButton.MaxTimer = CopyCatScanAbilityButtonMaxTimer;
            CopyCatScanAbilityButton.StartTimer = 5f;

            RevengerAbilityButton.MaxTimer = RevengerAbilityButtonMaxTimer;
            RevengerAbilityButton.StartTimer = RevengerAbilityButtonMaxTimer;

            //SPECIALS
            CupidAbilityButton.MaxTimer = 1f;
            CupidAbilityButton.StartTimer = 5f;

            CultistAbilityButton.MaxTimer = CultistAbilityButtonMaxTimer;
            CultistAbilityButton.StartTimer = CultistAbilityButtonMaxTimer;

            OutlawKillButton.MaxTimer = OutlawKillButtonMaxTimer;
            OutlawKillButton.StartTimer = 10f;

            JesterAbilityButton.MaxTimer = JesterAbilityButtonMaxTimer;
            JesterAbilityButton.StartTimer = JesterAbilityButtonMaxTimer;

            EaterDraggAbilityButton.MaxTimer = EaterDraggAbilityButtonMaxTimer;
            EaterDraggAbilityButton.MaxTimer = 5f;
            EaterBarAbilityButton.MaxTimer = EaterBarAbilityButtonMaxTimer;
            EaterEatAbilityButton.MaxTimer = EaterEatAbilityButtonMaxTimer;
            EaterEatAbilityButton.StartTimer = EaterEatAbilityButtonMaxTimer;
            EaterEatAbilityButton.EffectDuration = EaterEatAbilityButtonEffectDuration;

            ArsonistOilAbilityButton.MaxTimer = ArsonistOilAbilityButtonMaxTimer;
            ArsonistOilAbilityButton.StartTimer = ArsonistOilAbilityButtonMaxTimer;
            ArsonistOilAbilityButton.EffectDuration = ArsonistOilAbilityButtonEffectDuration;

            CursedAbilityButton.MaxTimer = CursedAbilityButtonMaxTimer;
            CursedAbilityButton.StartTimer = CursedAbilityButtonMaxTimer;
            CursedAbilityButton.EffectDuration = CursedAbilityButtonEffectDuration;


            //IMPOSTOR
            CopyCatKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            Impostor1KillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            Impostor2KillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            Impostor3KillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            AssassinKillButton.MaxTimer = AssassinKillButtonMaxTimer;
            MorphlingKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            ScramblerKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            BarghestKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            GhostKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            SorcererKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            GuesserKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            BasiliskKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
            /* ReaperKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;
             SaboteurKillButton.MaxTimer = ImpostorsKillButtonMaxTimer;*/

            CopyCatKillButton.StartTimer = 10f;
            Impostor1KillButton.StartTimer = 10f;
            Impostor2KillButton.StartTimer = 10f;
            Impostor3KillButton.StartTimer = 10f;
            MorphlingKillButton.StartTimer = 10f;
            ScramblerKillButton.StartTimer = 10f;
            BarghestKillButton.StartTimer = 10f;
            GhostKillButton.StartTimer = 10f;
            SorcererKillButton.StartTimer = 10f;
            GuesserKillButton.StartTimer = 10f;
            BasiliskKillButton.StartTimer = 10f;
            /*  ReaperKillButton.StartTimer = 10f;
             SaboteurKillButton.StartTimer = 10f;*/
            AssassinKillButton.StartTimer = 10f;


            VectorInfectAbilityButton.MaxTimer = VectorInfectAbilityButtonMaxTimer;
            VectorKillButton.MaxTimer = VectorKillButtonMaxTimer;
            VectorKillButton.StartTimer = VectorKillButtonMaxTimer;
            VectorInfectAbilityButton.StartTimer = VectorInfectAbilityButtonMaxTimer;


            MorphlingScanAbilityButton.MaxTimer = MorphlingMorphAbilityButtonMaxTimer;

            MorphlingMorphAbilityButton.MaxTimer = MorphlingMorphAbilityButtonMaxTimer;
            MorphlingMorphAbilityButton.EffectDuration = MorphlingMorphAbilityButtonEffectDuration;


            ScramblerAbilityButton.MaxTimer = ScramblerAbilityButtonMaxTimer;
            ScramblerAbilityButton.EffectDuration = ScramblerAbilityButtonEffectDuration;
            ScramblerAbilityButton.StartTimer = ScramblerAbilityButtonMaxTimer;


            BarghestShadowAbilityButton.MaxTimer = BarghestShadowAbilityButtonMaxTimer;
            BarghestShadowAbilityButton.EffectDuration = BarghestShadowAbilityButtonEffectDuration;
            BarghestCreateVentAbilityButton.MaxTimer = BarghestCreateVentAbilityButtonMaxTimer;
            BarghestShadowAbilityButton.StartTimer = BarghestShadowAbilityButtonMaxTimer;
            BarghestCreateVentAbilityButton.StartTimer = BarghestCreateVentAbilityButtonMaxTimer;


            GhostAbilityButton.MaxTimer = GhostAbilityButtonMaxTimer;
            GhostAbilityButton.EffectDuration = GhostAbilityButtonEffectDuration;
            GhostAbilityButton.StartTimer = GhostAbilityButtonMaxTimer;


            SorcererFindAbilityButton.MaxTimer = SorcererFindAbilityButtonMaxTimer;
            SorcererFindAbilityButton.StartTimer = SorcererFindAbilityButtonMaxTimer;
            Sorcerer1AbilityButton.MaxTimer = 0.5f;
            Sorcerer2AbilityButton.MaxTimer = 0.5f;
            Sorcerer3AbilityButton.MaxTimer = 0.5f;
            Sorcerer4AbilityButton.MaxTimer = 0.5f;
            Sorcerer1AbilityButton.StartTimer = 0.5f;
            Sorcerer2AbilityButton.StartTimer = 0.5f;
            Sorcerer3AbilityButton.StartTimer = 0.5f;
            Sorcerer4AbilityButton.StartTimer = 0.5f;

            BasiliskAbilityButton.MaxTimer = 5f;
            BasiliskAbilityButton.StartTimer = 5f;
            BasiliskAbility2Button.MaxTimer = 5f;
            BasiliskAbility2Button.StartTimer = 5f;




            CustomButton.ResetAllCooldowns();
        }



        public static void Postfix(HudManager __instance)
        {

            //ALLPLAYER BUTTON


            // NuclearTimer
            NuclearTimerButton = new CustomButton(
                () => {

                },
                () => { return PlayerControl.GameOptions.MapId == 2 && BetterMapPL.getSelection() == 2 && !StartNuclear; },
                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                NuclearButtonSprite,
                new Vector3(-4.1f, 4.1f, 0),
                __instance,
                KeyCode.None
            );
            NuclearTimerText = GameObject.Instantiate(NuclearTimerButton.actionButton.cooldownTimerText, NuclearTimerButton.actionButton.cooldownTimerText.transform.parent);
            NuclearTimerText.text = "";
            NuclearTimerText.transform.localScale = Vector3.one * 0.9f;
            NuclearTimerText.color = YellowColor;
            NuclearTimerText.enableWordWrapping = false;

            // SETUI
            SetUI = new CustomButton(
                () => {
                    /** - This part of the code is not open source **/
                    //use

                },
                () => { return PlayerControl.LocalPlayer != null; }, //whohave
                () => { //update


                    return true;
                },
                () => { },
                MapIco,
                new Vector3(-99f, -99f, 0),
                __instance,
                KeyCode.F12
            );







            // ADMIN
            AdminButton = new CustomButton(
                () => {

                },
                () => { return PlayerControl.LocalPlayer != null && ChallengerMod.Challenger.UICustom; },
                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                admin0,
                new Vector3(-7f, -0.1f, 0),
                __instance,
                KeyCode.None
            );
            AdminText = GameObject.Instantiate(AdminButton.actionButton.cooldownTimerText, AdminButton.actionButton.cooldownTimerText.transform.parent);
            AdminText.text = "";
            AdminText.color = RedColor;
            AdminText.enableWordWrapping = false;



            // VITAL
            VitalButton = new CustomButton(
                () => {

                },
                () => { return PlayerControl.LocalPlayer != null && ChallengerMod.Challenger.UICustom; },
                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                Vitale0,
                new Vector3(-6.5f, -0.1f, 0),
                __instance,
                KeyCode.None
            );
            VitalText = GameObject.Instantiate(VitalButton.actionButton.cooldownTimerText, VitalButton.actionButton.cooldownTimerText.transform.parent);
            VitalText.text = "";
            VitalText.color = RedColor;
            VitalText.enableWordWrapping = false;


            // CAM
            CamButton = new CustomButton(
                () => {

                },
                () => { return PlayerControl.LocalPlayer != null && ChallengerMod.Challenger.UICustom; },
                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                cam0,
                new Vector3(-6f, -0.1f, 0),
                __instance,
                KeyCode.None
            );
            CamText = GameObject.Instantiate(CamButton.actionButton.cooldownTimerText, CamButton.actionButton.cooldownTimerText.transform.parent);
            CamText.text = "";
            CamText.color = RedColor;
            CamText.enableWordWrapping = false;

            // BUZZ
            BuzzButton = new CustomButton(
                () => {

                },
                () => { return PlayerControl.LocalPlayer != null && ChallengerMod.Challenger.UICustom; },
                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                buzz0,
                new Vector3(-5.5f, -0.1f, 0),
                __instance,
                KeyCode.None
            );
            BuzzText = GameObject.Instantiate(BuzzButton.actionButton.cooldownTimerText, BuzzButton.actionButton.cooldownTimerText.transform.parent);
            BuzzText.text = "";
            BuzzText.color = RedColor;
            BuzzText.enableWordWrapping = false;

            // SENTINEL
            SentinelVentButton = new CustomButton(
                () => {

                },
                () => {
                    return (Sentinel.Role != null && Sentinel.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 17 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                SenV,
                new Vector3(-0.9f, 1f, 0),
                __instance,
                KeyCode.None
            );
            VentText = GameObject.Instantiate(SentinelVentButton.actionButton.cooldownTimerText, SentinelVentButton.actionButton.cooldownTimerText.transform.parent);
            VentText.text = "";
            VentText.color = RedColor;
            VentText.enableWordWrapping = false;

            // SENTINEL Body
            SentinelBodyButton = new CustomButton(
                () => {

                },
                () => {
                    return (Sentinel.Role != null && Sentinel.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                    || (CopyCat.Role != null && CopyCat.copyRole == 17 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },
                () => {
                    /** - This part of the code is not open source **/
                },
                () => { },
                SenDB,
                new Vector3(-1.9f, 1f, 0),
                __instance,
                KeyCode.None
            );
            BodyText = GameObject.Instantiate(SentinelBodyButton.actionButton.cooldownTimerText, SentinelBodyButton.actionButton.cooldownTimerText.transform.parent);
            BodyText.text = "";
            BodyText.color = RedColor;
            BodyText.enableWordWrapping = false;

            // EATER
            EaterBarAbilityButton = new CustomButton(
                () => {

                },
                () => { return Eater.Role != null && Eater.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {

                    /** - This part of the code is not open source **/
                },
                () => { },
                E0,
                new Vector3(-0.95f, 1.85f, 0),
                __instance,
                KeyCode.None
            );

            // Cursed
            CursedBarAbilityButton = new CustomButton(
                () => {

                },
                () => { return Cursed.Role != null && Cursed.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {

                    /** - This part of the code is not open source **/
                },
                () => { },
                CB0,
                new Vector3(-0.95f, 0.95f, 0),
                __instance,
                KeyCode.None
            );

            


            // Sheriff Kill
            Sheriff1KillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Sheriff1.Role, Sheriff1.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        Sheriff1KillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff1.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff1Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff1kill(targetId);
                            Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff1.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            Sheriff1KillButton.Timer = 0f;
                            Sheriff1.currentTarget = null;
                            return;
                        }
                        else
                        {
                            Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff1.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if (Assassin.Role == Assassin.currentTarget && Assassin.Shielded == true)
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff1Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff1kill(targetId);
                            Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff1.currentTarget = null;
                            return;
                        }
                        else if ((Sheriff1.currentTarget.Data.Role.IsImpostor) ||
                             (Jester.Role == Sheriff1.currentTarget
                             || (Cultist.Role == Sheriff1.currentTarget)
                             || (Cultist.Culte1 == Sheriff1.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte2 == Sheriff1.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte3 == Sheriff1.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Eater.Role == Sheriff1.currentTarget)
                             || (Outlaw.Role == Sheriff1.currentTarget)
                             || (Arsonist.Role == Sheriff1.currentTarget)
                             || (Cursed.Role == Sheriff1.currentTarget)
                             || (Mercenary.Role == Sheriff1.currentTarget && Mercenary.isImpostor == true)
                             || (CopyCat.Role == Sheriff1.currentTarget && CopyCat.isImpostor == true)
                             ))
                        {
                            //KILL
                            targetId = Sheriff1.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff1Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff1kill(targetId);
                            Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff1.currentTarget = null;
                            return;
                        }
                        else
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff1Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff1kill(targetId);
                            Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff1.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Sheriff1.Role != null && Sheriff1.CanKill && Sheriff1.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    Sheriff1KillButton.actionButton.OverrideText(BTT_Role_Kill);
                    Sheriff1KillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SheriffColor);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        Sheriff1KillButton.Sprite = KillSherifIco2;
                    }
                    else
                    {
                        Sheriff1KillButton.Sprite = KillSherifIco;
                    }

                    return Sheriff1.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        Sheriff1KillButton.Timer = 15f;
                    }
                    else
                    {
                        Sheriff1KillButton.Timer = SheriffKillButtonMaxTimer;
                    }
                },
                KillSherifIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );

            // Sheriff Kill
            Sheriff2KillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Sheriff2.Role, Sheriff2.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            Sheriff2KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff2.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff2Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff2kill(targetId);
                            Sheriff2KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff2.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            Sheriff2KillButton.Timer = 0f;
                            Sheriff2.currentTarget = null;
                            return;
                        }
                        else
                        {
                            Sheriff2KillButton.Timer = Sheriff2KillButton.MaxTimer;
                            Sheriff2.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if (Assassin.Role == Assassin.currentTarget && Assassin.Shielded == true)
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff2Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff2kill(targetId);
                            Sheriff2KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff2.currentTarget = null;
                            return;
                        }
                        else if ((Sheriff2.currentTarget.Data.Role.IsImpostor) ||
                             (Jester.Role == Sheriff2.currentTarget
                             || (Cultist.Role == Sheriff2.currentTarget)
                             || (Cultist.Culte1 == Sheriff2.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte2 == Sheriff2.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte3 == Sheriff2.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Eater.Role == Sheriff2.currentTarget)
                             || (Outlaw.Role == Sheriff2.currentTarget)
                             || (Arsonist.Role == Sheriff2.currentTarget)
                             || (Cursed.Role == Sheriff2.currentTarget)
                             || (Mercenary.Role == Sheriff2.currentTarget && Mercenary.isImpostor == true)
                             || (CopyCat.Role == Sheriff2.currentTarget && CopyCat.isImpostor == true)
                             ))
                        {
                            //KILL
                            targetId = Sheriff2.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff2Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff2kill(targetId);
                            Sheriff2KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff2.currentTarget = null;
                            return;
                        }
                        else
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff2Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff2kill(targetId);
                            Sheriff2KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff2.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Sheriff2.Role != null && Sheriff2.CanKill && Sheriff2.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    Sheriff2KillButton.actionButton.OverrideText(BTT_Role_Kill);
                    Sheriff2KillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SheriffColor);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        Sheriff2KillButton.Sprite = KillSherifIco2;
                    }
                    else
                    {
                        Sheriff2KillButton.Sprite = KillSherifIco;
                    }

                    return Sheriff2.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        Sheriff2KillButton.Timer = 15f;
                    }
                    else
                    {
                        Sheriff2KillButton.Timer = SheriffKillButtonMaxTimer;
                    }
                },
                KillSherifIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );

            // Sheriff Kill
            Sheriff3KillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Sheriff3.Role, Sheriff3.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff3.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff3Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff3kill(targetId);
                            Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff3.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            Sheriff3KillButton.Timer = 0f;
                            Sheriff3.currentTarget = null;
                            return;
                        }
                        else
                        {
                            Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff3.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if (Assassin.Role == Assassin.currentTarget && Assassin.Shielded == true)
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff3Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff3kill(targetId);
                            Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff3.currentTarget = null;
                            return;
                        }
                        else if ((Sheriff3.currentTarget.Data.Role.IsImpostor) ||
                             (Jester.Role == Sheriff3.currentTarget
                             || (Cultist.Role == Sheriff3.currentTarget)
                             || (Cultist.Culte1 == Sheriff3.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte2 == Sheriff3.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte3 == Sheriff3.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Eater.Role == Sheriff3.currentTarget)
                             || (Outlaw.Role == Sheriff3.currentTarget)
                             || (Arsonist.Role == Sheriff3.currentTarget)
                             || (Cursed.Role == Sheriff3.currentTarget)
                             || (Mercenary.Role == Sheriff3.currentTarget && Mercenary.isImpostor == true)
                             || (CopyCat.Role == Sheriff3.currentTarget && CopyCat.isImpostor == true)
                             ))
                        {
                            //KILL
                            targetId = Sheriff3.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff3Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff3kill(targetId);
                            Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff3.currentTarget = null;
                            return;
                        }
                        else
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Sheriff3Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sheriff3kill(targetId);
                            Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                            Sheriff3.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Sheriff3.Role != null && Sheriff3.CanKill && Sheriff3.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    Sheriff3KillButton.actionButton.OverrideText(BTT_Role_Kill);
                    Sheriff3KillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SheriffColor);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        Sheriff3KillButton.Sprite = KillSherifIco2;
                    }
                    else
                    {
                        Sheriff3KillButton.Sprite = KillSherifIco;
                    }

                    return Sheriff3.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {
                    if (StartTimer == false)
                    {
                        Sheriff3KillButton.Timer = 15f;
                    }
                    else
                    {
                        Sheriff3KillButton.Timer = SheriffKillButtonMaxTimer;
                    }

                },
                KillSherifIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // CopyCat Sheriff Kill
            CopyCatSheriffButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(CopyCat.Role, CopyCat.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.copyCatKill(targetId);
                            CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            CopyCatSheriffButton.Timer = 0f;
                            CopyCat.currentTarget = null;
                            return;
                        }
                        else
                        {
                            CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if (Assassin.Role == Assassin.currentTarget && Assassin.Shielded == true)
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.copyCatKill(targetId);
                            CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }
                        else if ((CopyCat.currentTarget.Data.Role.IsImpostor) ||
                             (Jester.Role == CopyCat.currentTarget
                             || (Cultist.Role == CopyCat.currentTarget)
                             || (Cultist.Culte1 == CopyCat.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte2 == CopyCat.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Cultist.Culte3 == CopyCat.currentTarget && SherifKillCulteMember.getBool() == true)
                             || (Eater.Role == CopyCat.currentTarget)
                             || (Outlaw.Role == CopyCat.currentTarget)
                             || (Arsonist.Role == CopyCat.currentTarget)
                             || (Cursed.Role == CopyCat.currentTarget)
                             || (Mercenary.Role == CopyCat.currentTarget && Mercenary.isImpostor == true)
                             ))
                        {
                            //KILL
                            targetId = CopyCat.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.copyCatKill(targetId);
                            CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }
                        else
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.copyCatKill(targetId);
                            CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return CopyCat.Role != null && CopyCat.copyRole == 1 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    CopyCatSheriffButton.actionButton.OverrideText(BTT_Role_Kill);
                    CopyCatSheriffButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SheriffColor);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        CopyCatSheriffButton.Sprite = KillSherifIco2;
                    }
                    else
                    {
                        CopyCatSheriffButton.Sprite = KillSherifIco;
                    }

                    return CopyCat.currentTarget && CopyCat.copyRole == 1 && CopyCat.CopyStart && PlayerControl.LocalPlayer.CanMove;
                },
                () => {
                    if (StartTimer == false)
                    {
                        CopyCatSheriffButton.Timer = 15f;
                    }
                    else
                    {
                        CopyCatSheriffButton.Timer = SheriffKillButtonMaxTimer;
                    }

                },
                KillSherifIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // Guardian Shield
            GuardianAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Guardian.Role, Guardian.currentTarget);


                    if (Mystic.Role != null && Mystic.Role == Guardian.currentTarget)
                    {
                        GuardianAbilityButton.Timer = GuardianAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetProtectedMystic, Hazel.SendOption.Reliable, -1);
                        writer.Write(Guardian.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setProtectedMystic(Guardian.currentTarget.PlayerId);
                        GuardianAbilityButton.Sprite = empty;
                        GuardianAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                        SoundManager.Instance.PlaySound(ShieldBuff, false, 100f);
                    }
                    else if (CopyCat.Role != null && CopyCat.copyRole == 6 && CopyCat.CopyStart && CopyCat.Role == Guardian.currentTarget)
                    {
                        GuardianAbilityButton.Timer = GuardianAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetProtectedMystic, Hazel.SendOption.Reliable, -1);
                        writer.Write(Guardian.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setProtectedMystic(Guardian.currentTarget.PlayerId);
                        GuardianAbilityButton.Sprite = empty;
                        GuardianAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                        SoundManager.Instance.PlaySound(ShieldBuff, false, 100f);
                    }
                    else
                    {
                        GuardianAbilityButton.Timer = GuardianAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetProtectedPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Guardian.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setProtectedPlayer(Guardian.currentTarget.PlayerId);
                        GuardianAbilityButton.Sprite = empty;
                        GuardianAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                        SoundManager.Instance.PlaySound(ShieldBuff, false, 100f);
                    }

                },
                () => { return Guardian.Role != null && Guardian.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Guardian.ShieldUsed)
                    {
                        GuardianAbilityButton.Sprite = shieldIco;
                        GuardianAbilityButton.actionButton.OverrideText(BTT_Role_Guardian);
                        GuardianAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.GuardianColor);
                    }
                    else
                    {
                        GuardianAbilityButton.Sprite = empty;
                        GuardianAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Guardian.ShieldUsed && Guardian.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                shieldIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // CopyCat Guardian Shield
            CopyCatGuardianButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(CopyCat.Role, CopyCat.currentTarget);


                    if (Mystic.Role != null && Mystic.Role == CopyCat.currentTarget)
                    {
                        CopyCatGuardianButton.Timer = GuardianAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetProtectedMystic, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setProtectedMystic(CopyCat.currentTarget.PlayerId);
                        CopyCatGuardianButton.Sprite = empty;
                        CopyCatGuardianButton.actionButton.OverrideText(BTT_EMPTY);
                        SoundManager.Instance.PlaySound(ShieldBuff, false, 100f);
                    }
                    else
                    {
                        CopyCatGuardianButton.Timer = GuardianAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetProtectedPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setProtectedPlayer(CopyCat.currentTarget.PlayerId);
                        CopyCatGuardianButton.Sprite = empty;
                        CopyCatGuardianButton.actionButton.OverrideText(BTT_EMPTY);
                        SoundManager.Instance.PlaySound(ShieldBuff, false, 100f);
                    }

                },
                () => { return CopyCat.Role != null && CopyCat.Role == PlayerControl.LocalPlayer && CopyCat.copyRole == 2 && CopyCat.CopyStart && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Guardian.ShieldUsed)
                    {
                        CopyCatGuardianButton.Sprite = shieldIco;
                        CopyCatGuardianButton.actionButton.OverrideText(BTT_Role_Guardian);
                        CopyCatGuardianButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.GuardianColor);
                    }
                    else
                    {
                        CopyCatGuardianButton.Sprite = empty;
                        CopyCatGuardianButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Guardian.ShieldUsed && CopyCat.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                shieldIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Engineer Repair
            EngineerAbilityButton = new CustomButton(
                () => {


                    EngineerAbilityButton.Timer = EngineerAbilityButtonMaxTimer;
                    MessageWriter usedRepairWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.EngineerRepair, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(usedRepairWriter);
                    RPCProcedure.engineerRepair();
                    EngineerAbilityButton.Sprite = empty;
                    EngineerAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                    foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                    {
                        if (task.TaskType == TaskTypes.FixLights)
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.EngineerFixLight, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.engineerFixLight();
                        }
                        else if (task.TaskType == TaskTypes.RestoreOxy)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 0 | 64);
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 1 | 64);
                        }
                        else if (task.TaskType == TaskTypes.ResetReactor)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 16);
                        }
                        else if (task.TaskType == TaskTypes.ResetSeismic)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Laboratory, 16);
                        }
                        else if (task.TaskType == TaskTypes.FixComms)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 0);
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 1);
                        }
                        else if (task.TaskType == TaskTypes.StopCharles)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 0 | 16);
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 1 | 16);
                        }
                    }
                },
                () => {
                    return (Engineer.Role != null && !Engineer.RepairUsed && Engineer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                    || (CopyCat.Role != null && !Engineer.RepairUsed && CopyCat.copyRole == 3 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },
                () => {
                    if (!Engineer.RepairUsed)
                    {
                        EngineerAbilityButton.Sprite = repairIco;
                        EngineerAbilityButton.actionButton.OverrideText(BTT_Role_Engineer);
                        EngineerAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.EngineerColor);
                    }
                    else
                    {
                        EngineerAbilityButton.Sprite = empty;
                        EngineerAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    bool sabotageActive = false;

                    foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                        if (task.TaskType == TaskTypes.FixLights || task.TaskType == TaskTypes.RestoreOxy || task.TaskType == TaskTypes.ResetReactor || task.TaskType == TaskTypes.ResetSeismic || task.TaskType == TaskTypes.FixComms || task.TaskType == TaskTypes.StopCharles)
                            sabotageActive = true;

                    return sabotageActive && !Engineer.RepairUsed && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        EngineerAbilityButton.Timer = EngineerAbilityButtonMaxTimer;
                    }
                    else
                    {
                        EngineerAbilityButton.Timer = EngineerAbilityButtonMaxTimer;
                    }

                },
                repairIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // TimeLord BreakTime
            TimelordAbilityButton = new CustomButton(
                () => {

                    TimelordAbilityButton.EffectDuration = TimelordAbilityButtonEffectDuration;

                    if (Timelord.Role != null && PlayerControl.LocalPlayer == Timelord.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.TimeStop_Start, Hazel.SendOption.Reliable, -1);
                        writer.Write(1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.timeStop_Start(1);
                    }
                    if (CopyCat.Role != null && PlayerControl.LocalPlayer == CopyCat.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.TimeStop_Start, Hazel.SendOption.Reliable, -1);
                        writer.Write(2);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.timeStop_Start(2);
                    }

                },
                () => {
                    return (Timelord.Role != null && Timelord.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                     || (CopyCat.Role != null && CopyCat.copyRole == 4 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },
                () => {
                    TimelordAbilityButton.actionButton.OverrideText(BTT_Role_Timelord);
                    TimelordAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.TimeLordColor);

                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {



                    TimelordAbilityButton.Timer = TimelordAbilityButtonMaxTimer;
                    TimelordAbilityButton.isEffectActive = false;
                    TimelordAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                stopIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                TimelordAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.TimeStop_End, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.timeStop_End();
                    TimelordAbilityButton.Timer = TimelordAbilityButtonMaxTimer;
                }
            );

            // Hunter Track
            HunterAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Hunter.Role, Hunter.currentTarget);

                    HunterAbilityButton.Timer = HunterAbilityButtonMaxTimer;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetTrackedPlayer, Hazel.SendOption.Reliable, -1);
                    writer.Write(Hunter.currentTarget.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.setTrackedPlayer(Hunter.currentTarget.PlayerId);
                    HunterAbilityButton.Sprite = empty;
                    HunterAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                },
                () => { return Hunter.Role != null && !Hunter.TrackUsed && Hunter.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Hunter.TrackUsed)
                    {
                        HunterAbilityButton.Sprite = trackIco;
                        HunterAbilityButton.actionButton.OverrideText(BTT_Role_Hunter);
                        HunterAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.HunterColor);
                    }
                    else
                    {
                        HunterAbilityButton.Sprite = empty;
                        HunterAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Hunter.TrackUsed && Hunter.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                trackIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Copy Hunter Track
            CopyCatHunterButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(CopyCat.Role, CopyCat.currentTarget);

                    CopyCatHunterButton.Timer = HunterAbilityButtonMaxTimer;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyTrackedPlayer, Hazel.SendOption.Reliable, -1);
                    writer.Write(CopyCat.currentTarget.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.setCopyTrackedPlayer(CopyCat.currentTarget.PlayerId);
                    CopyCatHunterButton.Sprite = empty;
                    CopyCatHunterButton.actionButton.OverrideText(BTT_EMPTY);
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                },
                () => { return CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && !Hunter.CopyTrackUsed && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Hunter.CopyTrackUsed)
                    {
                        CopyCatHunterButton.Sprite = trackIco;
                        CopyCatHunterButton.actionButton.OverrideText(BTT_Role_Hunter);
                        CopyCatHunterButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.HunterColor);
                    }
                    else
                    {
                        CopyCatHunterButton.Sprite = empty;
                        CopyCatHunterButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Hunter.CopyTrackUsed && CopyCat.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                trackIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Mystic Shield
            MysticAbilityButton = new CustomButton(
                () => {



                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MysticShieldOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.mysticShieldOn();
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                    MysticAbilityButton.EffectDuration = MysticAbilityButtonEffectDuration;

                },
                () => {
                    return (Mystic.Role != null && Mystic.ShieldButton && Mystic.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                    || (CopyCat.Role != null && Mystic.ShieldButton && CopyCat.copyRole == 6 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },
                () => {
                    MysticAbilityButton.actionButton.OverrideText(BTT_Role_Mystic);
                    MysticAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.MysticColor);


                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    MysticAbilityButton.Timer = MysticAbilityButtonMaxTimer;
                    MysticAbilityButton.isEffectActive = false;
                    MysticAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                mysticIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                MysticAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MysticShieldOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.mysticShieldOff();
                    MysticAbilityButton.Timer = MysticAbilityButtonMaxTimer;
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                }
            );



            // Spirit 
            SpiritAbilityButton = new CustomButton(
                () => {



                    //open
                    DestroyableSingleton<HudManager>.Instance.ShowMap((Action<MapBehaviour>)delegate (MapBehaviour m)
                    {
                        m.ShowSabotageMap();
                        m.ColorControl.baseColor = SpiritColor;
                    });


                },
                () => {
                    return (Spirit.Role != null && Spirit.Role == PlayerControl.LocalPlayer && Spirit.CanCloseDoor && PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                    || (CopyCat.Role != null && CopyCat.copyRole == 7 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled); ;
                },
                () => {

                    SpiritAbilityButton.Sprite = SabdoorIco;
                    SpiritAbilityButton.actionButton.OverrideText(BTT_Role_Spirit);
                    SpiritAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SpiritColor);


                    return Spirit.CanCloseDoor && PlayerControl.LocalPlayer.CanMove;
                },

                () => { },
                SabdoorIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Mayor Buzz 
            MayorAbilityButton = new CustomButton(
                () => {

                    MayorAbilityButton.Timer = MayorAbilityButtonMaxTimer;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MayorBuzz, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.mayorBuzz();
                    MayorAbilityButton.Sprite = empty;
                    MayorAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                },
                () => {
                    return (Mayor.Role != null && Mayor.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 8 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {
                    if (!Mayor.BuzzUsed)
                    {
                        MayorAbilityButton.Sprite = MayorIco;
                        MayorAbilityButton.actionButton.OverrideText(BTT_Role_Mayor);
                        MayorAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.MayorColor);
                    }
                    else
                    {
                        MayorAbilityButton.Sprite = empty;
                        MayorAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Mayor.BuzzUsed && Mayor.Buzz && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                MayorIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );
            // Detective find
            DetectiveAbilityButton = new CustomButton(
                () => {

                    DetectiveAbilityButton.EffectDuration = DetectiveAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DetectiveFindFPOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.detectiveFindFPOn();
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                },
                () => {
                    return (Detective.Role != null && Detective.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                    || (CopyCat.Role != null && CopyCat.copyRole == 9 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },
                () => {
                    DetectiveAbilityButton.actionButton.OverrideText(BTT_Role_Detective);
                    DetectiveAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.DetectiveColor);

                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    DetectiveAbilityButton.Timer = DetectiveAbilityButtonMaxTimer;
                    DetectiveAbilityButton.isEffectActive = false;
                    DetectiveAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                DetectiveIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                DetectiveAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DetectiveFindFPOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.detectiveFindFPOff();
                    DetectiveAbilityButton.Timer = DetectiveAbilityButtonMaxTimer;
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                }
            );
            // Nightwatch Light
            NightwatchAbilityButton = new CustomButton(
                () => {

                    NightwatchAbilityButton.EffectDuration = NightwatchAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.NightwatchLightOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.nightwatchLightOn();
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                },
                () => {
                    return (Nightwatch.Role != null && Nightwatch.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 10 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {
                    NightwatchAbilityButton.actionButton.OverrideText(BTT_Role_Nightwatch);
                    NightwatchAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.NightwatchColor);

                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    NightwatchAbilityButton.Timer = NightwatchAbilityButtonMaxTimer;
                    NightwatchAbilityButton.isEffectActive = false;
                    NightwatchAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                NightwatchIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                NightwatchAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.NightwatchLightOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.nightwatchLightOff();
                    NightwatchAbilityButton.Timer = NightwatchAbilityButtonMaxTimer;
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                }
            );
            //Spy Use
            SpyAbilityButton = new CustomButton(
                () => {

                    SpyAbilityButton.EffectDuration = SpyAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SpyOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.spyOn();
                    SoundManager.Instance.PlaySound(Used, false, 100f);


                },
                () => {
                    return (Spy.Role != null && !Spy.SpyUsed && Spy.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 11 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    if (!Spy.SpyUsed)
                    {
                        SpyAbilityButton.Sprite = SpyIco;
                        SpyAbilityButton.actionButton.OverrideText(BTT_Role_Spy);
                        SpyAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SpyColor);
                    }
                    else
                    {
                        SpyAbilityButton.Sprite = empty;
                        SpyAbilityButton.actionButton.cooldownTimerText.color = new Color(0F, 0F, 0F, 0F);
                        SpyAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }

                    return !Spy.SpyUsed && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    SpyAbilityButton.Timer = SpyAbilityButtonMaxTimer;
                    SpyAbilityButton.isEffectActive = false;
                    SpyAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                SpyIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
               SpyAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SpyOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.spyOff();
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                    SpyAbilityButton.Timer = 0f;
                    SpyAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    SpyAbilityButton.Sprite = empty;

                }
            );
            // Informant see
            InformantAbilityButton = new CustomButton(
                () =>
                {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Informant.Role, Informant.currentTarget);

                    if (Informant.currentTarget.Data.Role.IsImpostor)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 2;
                    }
                    else if (Jester.Role != null && Jester.Role == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 3;
                    }
                    else if (Eater.Role != null && Eater.Role == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 4;
                    }
                    else if (Outlaw.Role != null && Outlaw.Role == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 5;
                    }
                    else if (Arsonist.Role != null && Arsonist.Role == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 6;
                    }
                    else if (Cursed.Role != null && Cursed.Role == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 8;
                    }
                    else if (Cultist.Role != null && Cultist.Role == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;
                    }
                    else if (Cultist.Culte1 != null && Cultist.Culte1 == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;
                    }
                    else if (Cultist.Culte2 != null && Cultist.Culte2 == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;

                    }
                    else if (Cultist.Culte3 != null && Cultist.Culte3 == Informant.currentTarget)
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;
                    }
                    else
                    {
                        InformantAbilityButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Informant.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(Informant.currentTarget.PlayerId);
                        Informant.InformedTeam = 1;
                    }

                },
                () => { return Informant.Role != null && Informant.TaskEND && !Informant.Used && Informant.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Informant.Used)
                    {
                        InformantAbilityButton.Sprite = InforIco;
                        InformantAbilityButton.actionButton.OverrideText(BTT_Role_Informant);
                        InformantAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.InformantColor);
                    }
                    else
                    {
                        InformantAbilityButton.Sprite = empty;
                        InformantAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Informant.Used && Informant.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                InforIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Informant see
            CopyCatInformantButton = new CustomButton(
                () =>
                {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(CopyCat.Role, CopyCat.currentTarget);

                    if (CopyCat.currentTarget.Data.Role.IsImpostor)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 2;
                    }
                    else if (Jester.Role != null && Jester.Role == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 3;
                    }
                    else if (Eater.Role != null && Eater.Role == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 4;
                    }
                    else if (Outlaw.Role != null && Outlaw.Role == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 5;
                    }
                    else if (Arsonist.Role != null && Arsonist.Role == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 6;
                    }
                    else if (Cursed.Role != null && Cursed.Role == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 8;
                    }
                    else if (Cultist.Role != null && Cultist.Role == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;
                    }
                    else if (Cultist.Culte1 != null && Cultist.Culte1 == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;
                    }
                    else if (Cultist.Culte2 != null && Cultist.Culte2 == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;

                    }
                    else if (Cultist.Culte3 != null && Cultist.Culte3 == CopyCat.currentTarget)
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 7;
                    }
                    else
                    {
                        CopyCatInformantButton.Timer = InformantAbilityButtonMaxTimer;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfoPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setInfoPlayer(CopyCat.currentTarget.PlayerId);
                        Informant.InformedTeam = 1;
                    }

                },
                () => { return CopyCat.Role != null && CopyCat.TaskEND && CopyCat.copyRole == 12 && CopyCat.CopyStart && !Informant.Used && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Informant.Used)
                    {
                        InformantAbilityButton.Sprite = InforIco;
                        InformantAbilityButton.actionButton.OverrideText(BTT_Role_Informant);
                        InformantAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.InformantColor);
                    }
                    else
                    {
                        InformantAbilityButton.Sprite = empty;
                        InformantAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Informant.Used && CopyCat.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                InforIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            //Mentalist Use
            MentalistAbilityButton = new CustomButton(
                () => {

                    MentalistAbilityButton.EffectDuration = MentalistAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MentalistColorOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.mentalistColorOn();
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                },
                () => {
                    return (Mentalist.Role != null && !Mentalist.AdminUsed && Mentalist.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 14 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    if (!Mentalist.AdminUsed)
                    {
                        MentalistAbilityButton.Sprite = MentalistIco;
                        MentalistAbilityButton.actionButton.OverrideText(BTT_Role_Mentalist);
                        MentalistAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.MentalistColor);
                    }
                    else
                    {
                        MentalistAbilityButton.Sprite = empty;
                        MentalistAbilityButton.actionButton.cooldownTimerText.color = new Color(0F, 0F, 0F, 0F);
                        MentalistAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }

                    return !Mentalist.AdminUsed && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    MentalistAbilityButton.Timer = MentalistAbilityButtonMaxTimer;
                    MentalistAbilityButton.isEffectActive = false;
                    MentalistAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                MentalistIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
               MentalistAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MentalistColorOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.mentalistColorOff();
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                    MentalistAbilityButton.Timer = 0f;
                    MentalistAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    MentalistAbilityButton.Sprite = empty;

                }
            );
            //Builder vent
            BuilderAbilityButton = new CustomButton(
                () => {

                    if (!Builder.Use3 && !Builder.Use2 && !Builder.Use1 && PlayerControl.LocalPlayer == Builder.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SealVent, Hazel.SendOption.Reliable);
                        writer.WritePacked(Builder.ventTarget.Id);
                        writer.EndMessage();
                        RPCProcedure.sealVent(Builder.ventTarget.Id);
                        Builder.ventTarget = null;
                        Builder.Use1 = true;
                        Builder.round = true;
                        BuilderAbilityButton.Timer = BuilderAbilityButtonMaxTimer;
                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                    else if (!Builder.Use3 && !Builder.Use2 && Builder.Use1 && PlayerControl.LocalPlayer == Builder.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SealVent, Hazel.SendOption.Reliable);
                        writer.WritePacked(Builder.ventTarget.Id);
                        writer.EndMessage();
                        RPCProcedure.sealVent(Builder.ventTarget.Id);
                        Builder.ventTarget = null;
                        Builder.Use2 = true;
                        Builder.round = true;
                        BuilderAbilityButton.Timer = BuilderAbilityButtonMaxTimer;
                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                    else if (!Builder.Use3 && Builder.Use2 && Builder.Use1 && PlayerControl.LocalPlayer == Builder.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SealVent, Hazel.SendOption.Reliable);
                        writer.WritePacked(Builder.ventTarget.Id);
                        writer.EndMessage();
                        RPCProcedure.sealVent(Builder.ventTarget.Id);
                        Builder.ventTarget = null;
                        Builder.Use3 = true;
                        Builder.round = true;
                        BuilderAbilityButton.Timer = BuilderAbilityButtonMaxTimer;
                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                    else if (!Builder.Use3 && !Builder.Use2 && !Builder.Use1 && PlayerControl.LocalPlayer == CopyCat.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SealVent, Hazel.SendOption.Reliable);
                        writer.WritePacked(CopyCat.ventTarget.Id);
                        writer.EndMessage();
                        RPCProcedure.sealVent(CopyCat.ventTarget.Id);
                        CopyCat.ventTarget = null;
                        Builder.Use1 = true;
                        Builder.round = true;
                        BuilderAbilityButton.Timer = BuilderAbilityButtonMaxTimer;
                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                    else if (!Builder.Use3 && !Builder.Use2 && Builder.Use1 && PlayerControl.LocalPlayer == CopyCat.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SealVent, Hazel.SendOption.Reliable);
                        writer.WritePacked(CopyCat.ventTarget.Id);
                        writer.EndMessage();
                        RPCProcedure.sealVent(CopyCat.ventTarget.Id);
                        CopyCat.ventTarget = null;
                        Builder.Use2 = true;
                        Builder.round = true;
                        BuilderAbilityButton.Timer = BuilderAbilityButtonMaxTimer;
                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                    else if (!Builder.Use3 && Builder.Use2 && Builder.Use1 && PlayerControl.LocalPlayer == CopyCat.Role)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SealVent, Hazel.SendOption.Reliable);
                        writer.WritePacked(CopyCat.ventTarget.Id);
                        writer.EndMessage();
                        RPCProcedure.sealVent(CopyCat.ventTarget.Id);
                        CopyCat.ventTarget = null;
                        Builder.Use3 = true;
                        Builder.round = true;
                        BuilderAbilityButton.Timer = BuilderAbilityButtonMaxTimer;
                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }



                },
                () => {
                    return (Builder.Role != null && !Builder.Use3 && Builder.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 15 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {
                    if (!Builder.Use3 && !Builder.Use2 && !Builder.Use1)
                    {
                        BuilderAbilityButton.Sprite = BlockVent3;
                        BuilderAbilityButton.actionButton.OverrideText(BTT_Role_Builder);
                        BuilderAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.HunterColor);
                    }
                    else if (!Builder.Use3 && !Builder.Use2 && Builder.Use1)
                    {
                        BuilderAbilityButton.Sprite = BlockVent2;
                        BuilderAbilityButton.actionButton.OverrideText(BTT_Role_Builder);
                        BuilderAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.HunterColor);
                    }
                    else if (!Builder.Use3 && Builder.Use2 && Builder.Use1)
                    {
                        BuilderAbilityButton.Sprite = BlockVent1;
                        BuilderAbilityButton.actionButton.OverrideText(BTT_Role_Builder);
                        BuilderAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.HunterColor);
                    }
                    else
                    {
                        BuilderAbilityButton.Sprite = empty;
                        BuilderAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Builder.round && (Builder.ventTarget || CopyCat.ventTarget) && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                BlockVent3,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Sentinel Light
            SentinelAbilityButton = new CustomButton(
                () => {

                    SentinelAbilityButton.EffectDuration = SentinelAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SentinelScanOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.sentinelScanOn();
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                },
                () => {
                    return (Sentinel.Role != null && Sentinel.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 17 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {
                    SentinelAbilityButton.actionButton.OverrideText(BTT_Role_Sentinel);
                    SentinelAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SentinelColor);

                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    SentinelAbilityButton.Timer = SentinelAbilityButtonMaxTimer;
                    SentinelAbilityButton.isEffectActive = false;
                    SentinelAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                SenIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                SentinelAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SentinelScanOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.sentinelScanOff();
                    SentinelAbilityButton.Timer = SentinelAbilityButtonMaxTimer;
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                }
            );

            // Dictator 
            DictatorAbilityButton = new CustomButton(
                () => {


                    DictatorAbilityButton.Timer = DictatorAbilityButtonMaxTimer;
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DictatorNoSkipVote, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.dictatorNoSkipVote();
                    Dictator.NoSkipUsed = true;
                    SoundManager.Instance.PlaySound(Used, false, 100f);


                },
                () => {
                    return (Dictator.Role != null && Dictator.NoSkipButton && !Dictator.NoSkipUsed && Dictator.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled)
                || (CopyCat.Role != null && CopyCat.copyRole == 16 && !Dictator.NoSkipUsed && Dictator.NoSkipButton && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {
                    if (!Dictator.NoSkipUsed && Dictator.NoSkipButton)
                    {
                        DictatorAbilityButton.Sprite = DictatorIco;
                        DictatorAbilityButton.actionButton.OverrideText(BTT_Role_Dictator);
                        DictatorAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.DictatorColor);
                    }
                    else
                    {
                        DictatorAbilityButton.Sprite = empty;
                        DictatorAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }


                    return !Dictator.NoSkipUsed && PlayerControl.LocalPlayer.CanMove;
                },
                () => {
                },
                DictatorIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );







            // Jester FakeKill
            JesterAbilityButton = new CustomButton(
                () => {


                    JesterAbilityButton.Timer = JesterAbilityButtonMaxTimer;
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.JesterFakeKill, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.jesterFakeKill();
                    if (Jester.SingleFake)
                    {
                        Jester.FakeUsed = true;
                    }
                },
                () => { return Jester.Role != null && Jester.CanFake && !Jester.FakeUsed && Jester.Role == PlayerControl.LocalPlayer; },
                () => {
                    if (!Jester.FakeUsed && Jester.CanFake)
                    {
                        JesterAbilityButton.Sprite = fakeIco;
                        JesterAbilityButton.actionButton.OverrideText(BTT_Role_Jester);
                        JesterAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.JesterColor);
                    }
                    else
                    {
                        JesterAbilityButton.Sprite = empty;
                        JesterAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }


                    return !Jester.FakeUsed && PlayerControl.LocalPlayer.CanMove;
                },
                () => {
                    JesterAbilityButton.Timer = JesterAbilityButtonMaxTimer;
                },
                fakeIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // Cupid Love
            CupidAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Cupid.Role, Cupid.currentTarget);


                    if (!Cupid.LoveUsed && !Cupid.Fail)
                    {
                        if (!Cupid.Love1Used && !Cupid.Love2Used)
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetLover1, Hazel.SendOption.Reliable, -1);
                            writer.Write(Cupid.currentTarget.PlayerId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.setLover1(Cupid.currentTarget.PlayerId);
                            Cupid.Love1Used = true;
                            SoundManager.Instance.PlaySound(Used, false, 100f);

                            CupidAbilityButton.Timer = CupidAbilityButtonMaxTimer;
                        }
                        else if (Cupid.Love1Used && !Cupid.Love2Used)
                        {
                            if (Cupid.currentTarget == Cupid.Lover1) { Cupid.currentTarget = null; }
                            else
                            {
                                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetLover2, Hazel.SendOption.Reliable, -1);
                                writer.Write(Cupid.currentTarget.PlayerId);
                                AmongUsClient.Instance.FinishRpcImmediately(writer);
                                RPCProcedure.setLover2(Cupid.currentTarget.PlayerId);
                                Cupid.LoveUsed = true;
                                Cupid.Love2Used = true;
                                SoundManager.Instance.PlaySound(Used, false, 100f);

                                CupidAbilityButton.Timer = CupidAbilityButtonMaxTimer;
                            }
                        }
                        else if (Cupid.Love1Used && Cupid.Love2Used) { Cupid.currentTarget = null; }

                    }
                    else { Cupid.currentTarget = null; }
                },
                () => { return Cupid.Role != null && Cupid.Role == PlayerControl.LocalPlayer; },
                () => {
                    if (!Cupid.Love1Used && !Cupid.Love1Used && !Cupid.Fail) // 0 lovers
                    {
                        loverText.text = "" + STR_LOVERS;
                        loverText.color = WhiteColor;
                        CupidAbilityButton.Sprite = loveIco;
                        CupidAbilityButton.actionButton.OverrideText(BTT_Role_Cupid);
                        CupidAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.CupidColor);
                    }
                    else if (Cupid.Love1Used && !Cupid.Love1Used && !Cupid.Fail) // 1 lover
                    {
                        loverText.text = "" + STR_LOVERS;
                        loverText.color = WhiteColor;
                        CupidAbilityButton.Sprite = love1Ico;
                        CupidAbilityButton.actionButton.OverrideText(BTT_Role_Cupid);
                        CupidAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.CupidColor);
                    }
                    else if (Cupid.Love1Used && Cupid.Love1Used && !Cupid.Fail) // 2 lover
                    {
                        loverText.text = "" + STR_LOVERS;
                        loverText.color = WhiteColor;
                        CupidAbilityButton.Sprite = love2Ico;
                        CupidAbilityButton.actionButton.OverrideText(BTT_Role_Cupid);
                        CupidAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.CupidColor);
                    }
                    else if (Cupid.Fail) // Fail
                    {
                        loverText.text = "" + STR_LOVERS;
                        loverText.color = RedColor;
                        CupidAbilityButton.Sprite = noloveIco;
                        CupidAbilityButton.actionButton.OverrideText(BTT_Role_Cupid);
                        CupidAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.GreyColor);
                    }

                    return (Cupid.currentTarget || Cupid.LoveUsed || Cupid.Fail) && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                loveIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );
            loverText = GameObject.Instantiate(CupidAbilityButton.actionButton.cooldownTimerText, CupidAbilityButton.actionButton.cooldownTimerText.transform.parent);
            loverText.text = "";
            loverText.transform.localScale = Vector3.one * 0.65f;
            loverText.color = WhiteColor;
            loverText.enableWordWrapping = false;


            // Cultist convert
            CultistAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Cultist.Role, Cultist.currentTarget);


                    if (!Cultist.CulteUsed)
                    {
                        if ((Cultist.currentTarget.Data.Role.IsImpostor) ||
                             (Jester.Role == Cultist.currentTarget
                             || (Eater.Role == Cultist.currentTarget)
                             || (Outlaw.Role == Cultist.currentTarget)
                             || (Arsonist.Role == Cultist.currentTarget)
                             || (Cursed.Role == Cultist.currentTarget)
                             ))
                        {
                            Cultist.CulteTargetFail = true;
                            CultistAbilityButton.Timer = CultistAbilityButtonMaxTimer;
                        }
                        else
                        {
                            if (!Cultist.Culte1Used && !Cultist.Culte2Used && !Cultist.Culte3Used)
                            {
                                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCulte1Player, Hazel.SendOption.Reliable, -1);
                                writer.Write(Cultist.currentTarget.PlayerId);
                                AmongUsClient.Instance.FinishRpcImmediately(writer);
                                RPCProcedure.setCulte1Player(Cultist.currentTarget.PlayerId);
                                CultistAbilityButton.Timer = CultistAbilityButtonMaxTimer;
                                SoundManager.Instance.PlaySound(Used, false, 100f);
                            }
                            else if (Cultist.Culte1Used && !Cultist.Culte2Used && !Cultist.Culte3Used)
                            {
                                if (Cultist.currentTarget == Cultist.Culte1) { Cultist.currentTarget = null; }
                                else
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCulte2Player, Hazel.SendOption.Reliable, -1);
                                    writer.Write(Cultist.currentTarget.PlayerId);
                                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                                    RPCProcedure.setCulte2Player(Cultist.currentTarget.PlayerId);
                                    CultistAbilityButton.Timer = CultistAbilityButtonMaxTimer;
                                    SoundManager.Instance.PlaySound(Used, false, 100f);
                                }
                            }
                            else if (Cultist.Culte1Used && Cultist.Culte2Used && !Cultist.Culte3Used)
                            {
                                if (Cultist.currentTarget == Cultist.Culte1 || Cultist.currentTarget == Cultist.Culte2) { Cultist.currentTarget = null; }
                                else
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCulte3Player, Hazel.SendOption.Reliable, -1);
                                    writer.Write(Cultist.currentTarget.PlayerId);
                                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                                    RPCProcedure.setCulte3Player(Cultist.currentTarget.PlayerId);
                                    CultistAbilityButton.Timer = CultistAbilityButtonMaxTimer;
                                    SoundManager.Instance.PlaySound(Used, false, 100f);
                                }

                            }
                            else if (Cultist.Culte1Used && Cultist.Culte2Used && Cultist.Culte3Used) { Cultist.currentTarget = null; }
                        }
                    }
                    else { Cultist.currentTarget = null; }
                },
                () => { return Cultist.Role != null && !Cultist.CulteUsed && Cultist.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    if (!Cultist.CulteUsed)
                    {
                        CultistAbilityButton.Sprite = CulteIco;
                        CultistAbilityButton.actionButton.OverrideText(BTT_Role_Cultist);
                        CultistAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.CulteColor);
                    }
                    else
                    {
                        CultistAbilityButton.Sprite = empty;
                        CultistAbilityButton.actionButton.cooldownTimerText.color = new Color(0F, 0F, 0F, 0F);
                        CultistAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Cultist.CulteUsed && Cultist.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                CulteIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );

            // EATER 
            EaterDraggAbilityButton = new CustomButton(
                () => {


                    EaterDraggAbilityButton.Timer = 1f;
                    //drop
                    if (draggers.Contains(PlayerControl.LocalPlayer.PlayerId))
                    {

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DropBody, Hazel.SendOption.None, -1);
                        writer.WritePacked(PlayerControl.LocalPlayer.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.dropBody(PlayerControl.LocalPlayer.PlayerId);

                    }
                    else //dragg
                    {
                        List<DeadBody> _bodys = new List<DeadBody>();
                        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance - 2.5f, Constants.PlayersOnlyMask))
                        {
                            if (collider2D.tag == "DeadBody")
                            {
                                DeadBody body = (DeadBody)((Component)collider2D).GetComponent<DeadBody>();
                                _bodys.Add(body);
                            }
                        }
                        if (_bodys.Count != 0)
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DraggBody, Hazel.SendOption.None, -1);
                            writer.WritePacked(_bodys[0].ParentId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.draggBody(_bodys[0].ParentId);
                            RPC.RPCProcedure.MoveBody(_bodys[0].ParentId);
                        }
                    }


                },
                () => { return Eater.Role != null && Eater.CanDragg && Eater.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {

                    EaterDraggAbilityButton.Sprite = DragIco;
                    if (draggers.Contains(PlayerControl.LocalPlayer.PlayerId))
                    {
                        EaterDraggAbilityButton.actionButton.OverrideText(BTT_Role_EaterDrop);
                        EaterDraggAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.EaterColor);

                    }
                    else
                    {
                        EaterDraggAbilityButton.actionButton.OverrideText(BTT_Role_EaterDragg);
                        EaterDraggAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.EaterColor);

                    }



                    return (Eater.TargetBody || draggers.Contains(PlayerControl.LocalPlayer.PlayerId)) && PlayerControl.LocalPlayer.CanMove;
                },
                () => {
                },
                DragIco,
                new Vector3(-0.95f, 1f, 0),
                __instance,
                KeyCode.F
            );

            EaterEatAbilityButton = new CustomButton(
               () => {


                   EaterEatAbilityButton.Timer = EaterEatAbilityButtonMaxTimer;
                   PlayerControl.LocalPlayer.moveable = false;
                   PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                   DeadBody component = Eater.deadbodyTarget;

                   if (component != null && !component.Reported)
                   {




                       GameData.PlayerInfo playerInfo = GameData.Instance.GetPlayerById(component.ParentId);

                       SoundManager.Instance.PlaySound(Used, false, 100f);
                       PlayerControl.LocalPlayer.moveable = false;
                       PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;

                       if (PlayerControl.LocalPlayer.transform.position.x != component.transform.position.x || PlayerControl.LocalPlayer.transform.position.y != component.transform.position.y)
                       {
                           PlayerControl.LocalPlayer.transform.position = new Vector3(component.transform.position.x, component.transform.position.y, PlayerControl.LocalPlayer.transform.position.z);
                       }


                       //CAST

                   }
               },
               () => { return Eater.Role != null && Eater.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
               () => {

                   EaterEatAbilityButton.Sprite = EaterIco;
                   EaterEatAbilityButton.actionButton.OverrideText(BTT_Role_EaterEat);
                   EaterEatAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.EaterColor);


                   if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                   {
                       EaterEatAbilityButton.Sprite = EaterIco2;
                   }
                   else
                   {
                       EaterEatAbilityButton.Sprite = EaterIco;
                   }





                   return (Eater.CanEat) && PlayerControl.LocalPlayer.CanMove && !draggers.Contains(PlayerControl.LocalPlayer.PlayerId) && Eater.deadbodyTarget != null;
               },
               () => {
               },
               EaterIco,
               new Vector3(0f, 1f, 0),
               __instance,
               ChallengerMod.Challenger.KeycodeKill,
               true,
                EaterEatAbilityButtonEffectDuration,
                () => {
                    //EAT
                    SoundManager.Instance.PlaySound(Used, false, 100f);
                    PlayerControl.LocalPlayer.moveable = true;
                    DeadBody component = Eater.deadbodyTarget;

                    if (component != null && !component.Reported)
                    {
                        GameData.PlayerInfo playerInfo = GameData.Instance.GetPlayerById(component.ParentId);

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CleanBody, Hazel.SendOption.Reliable, -1);
                        writer.Write(playerInfo.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPC.RPCProcedure.cleanBody(playerInfo.PlayerId);
                        Eater.DistBody = 0;
                        SoundManager.Instance.PlaySound(Eated, false, 100f);
                        EaterEatAbilityButton.Timer = EaterEatAbilityButtonMaxTimer;
                    }
                    else { EaterEatAbilityButton.Timer = 0f; }



                }
           );
            // Cursed 
            CursedAbilityButton = new CustomButton(
                () => {

                    CursedAbilityButton.EffectDuration = CursedAbilityButtonEffectDuration;
                    Cursed.NoCurse = true;

                    //clic

                },
                () => {
                    return (Cursed.Role != null && Cursed.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead);
                },

                () => {

                    CursedAbilityButton.actionButton.OverrideText(BTT_Role_Cursed);
                    CursedAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.CursedColor);

                    if (CursedAbilityButton.isEffectActive)
                    {
                        CursedAbilityButton.actionButton.cooldownTimerText.color = Color.cyan;
                    }
                    if (!CursedAbilityButton.isEffectActive && Cursed.CurseStart == true)
                    {
                        CursedAbilityButton.actionButton.cooldownTimerText.color = Color.white;
                    }
                    if (!CursedAbilityButton.isEffectActive && Cursed.CurseStart == false)
                    {
                        CursedAbilityButton.actionButton.cooldownTimerText.color = Color.cyan;
                    }
                    if (CursedAbilityButton.Timer <= 0 && RoleTaskAssigned) { Cursed.CurseStart = true; }







                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    Cursed.CurseStart = false;
                    CursedAbilityButton.Timer = CursedTime;
                    CursedAbilityButton.isEffectActive = false;
                    CursedAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                CeciteIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                CursedAbilityButtonEffectDuration,
                () => {
                    Cursed.NoCurse = false;
                    CursedAbilityButton.Timer = CursedAbilityButtonMaxTimer;
                }
            );


            // Mercenary Kill
            MercenaryKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Mercenary.Role, Mercenary.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        MercenaryKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MercenaryTryKill, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.mercenaryTryKill();
                            MercenaryKillButton.Timer = MercenaryKillButtonMaxTimer;
                            Mercenary.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MercenaryKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.mercenaryKill(targetId);
                            MercenaryKillButton.Timer = MercenaryKillButtonMaxTimer;
                            Mercenary.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MercenaryTryKill, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.mercenaryTryKill();
                            MercenaryKillButton.Timer = MercenaryKillButtonMaxTimer;
                            Mercenary.currentTarget = null;
                            return;
                        }
                        else
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MercenaryTryKill, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.mercenaryTryKill();
                            MercenaryKillButton.Timer = 0f;
                            Mercenary.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Mercenary.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors && Mercenary.isImpostor)
                       || (Mercenary.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors && Mercenary.isImpostor)
                       || ((Fake.Role == Mercenary.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors && Mercenary.isImpostor)
                       || ((Assassin.Role == Mercenary.currentTarget) && Assassin.Shielded == true)
                            )
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MercenaryTryKill, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.mercenaryTryKill();
                            MercenaryKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {

                            //KILL
                            targetId = Mercenary.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MercenaryKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.mercenaryKill(targetId);
                            MercenaryKillButton.Timer = MercenaryKillButtonMaxTimer;
                            Mercenary.currentTarget = null;
                            return;
                        }
                    }


                },
                () => { return Mercenary.Role != null && Mercenary.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    MercenaryKillButton.actionButton.OverrideText(BTT_Role_Kill);
                    MercenaryKillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.MercenaryColor);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        MercenaryKillButton.Sprite = KillMercenaryIco2;
                    }
                    else
                    {
                        MercenaryKillButton.Sprite = KillMercenaryIco;
                    }

                    return Mercenary.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {
                    if (StartTimer == false)
                    {
                        MercenaryKillButton.Timer = MercenaryKillButtonMaxTimer * 2;
                    }
                    else
                    {
                        MercenaryKillButton.Timer = MercenaryKillButtonMaxTimer;
                    }

                },
                KillMercenaryIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );

            // Hunter Track
            RevengerAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Revenger.Role, Revenger.currentTarget);





                    if (!Revenger.EMP3_Used && !Revenger.EMP2_Used && !Revenger.EMP1_Used)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetEMP1Player, Hazel.SendOption.Reliable, -1);
                        writer.Write(Revenger.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setEMP1Player(Revenger.currentTarget.PlayerId);
                        RevengerAbilityButton.Timer = RevengerAbilityButtonMaxTimer;
                    }
                    else if (!Revenger.EMP3_Used && !Revenger.EMP2_Used && Revenger.EMP1_Used)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetEMP2Player, Hazel.SendOption.Reliable, -1);
                        writer.Write(Revenger.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setEMP2Player(Revenger.currentTarget.PlayerId);
                        RevengerAbilityButton.Timer = RevengerAbilityButtonMaxTimer;
                    }
                    else if (!Revenger.EMP3_Used && Revenger.EMP2_Used && Revenger.EMP1_Used)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetEMP3Player, Hazel.SendOption.Reliable, -1);
                        writer.Write(Revenger.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setEMP3Player(Revenger.currentTarget.PlayerId);
                        RevengerAbilityButton.Timer = RevengerAbilityButtonMaxTimer;
                    }
                },
                () => { return Revenger.Role != null && !Revenger.EMP3_Used && Revenger.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    if (!Revenger.EMP3_Used)
                    {
                        RevengerAbilityButton.Sprite = VengerIco;
                        RevengerAbilityButton.actionButton.OverrideText(BTT_Role_Revenger);
                        RevengerAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.RevengerColor);
                    }
                    else
                    {
                        RevengerAbilityButton.Sprite = empty;
                        RevengerAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !Revenger.EMP3_Used && Revenger.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        RevengerAbilityButton.Timer = 15f;
                    }
                    else
                    {
                        RevengerAbilityButton.Timer = RevengerAbilityButtonMaxTimer;
                    }

                },
                VengerIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );
            // CopyCat copy
            CopyCatScanAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(CopyCat.Role, CopyCat.currentTarget);

                    if (Sheriff1.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 1);
                    }
                    else if (Sheriff2.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 1);
                    }
                    else if (Sheriff3.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 1);
                    }
                    else if (Guardian.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(2);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 2);
                    }
                    else if (Engineer.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(3);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 3);
                    }
                    else if (Timelord.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(4);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 4);
                    }
                    else if (Hunter.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(5);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 5);
                    }
                    else if (Mystic.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(6);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 6);
                    }
                    else if (Spirit.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(7);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 7);
                    }
                    else if (Mayor.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(8);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 8);
                    }
                    else if (Detective.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(9);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 9);
                    }
                    else if (Nightwatch.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(10);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 10);
                    }
                    else if (Spy.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(11);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 11);
                    }
                    else if (Informant.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(12);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 12);
                    }
                    else if (Bait.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(13);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 13);
                    }
                    else if (Mentalist.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(14);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 14);
                    }
                    else if (Builder.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(15);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 15);
                    }
                    else if (Dictator.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(16);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 16);
                    }
                    else if (Sentinel.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(17);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 17);
                    }
                    else if (Lawkeeper.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(18);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 18);
                    }
                    else if (Traveler.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(19);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 20);
                    }
                    else if (Leader.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(20);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 21);
                    }
                    else if (Doctor.Role == CopyCat.currentTarget)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(21);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 22);
                    }
                    else if ((CopySpe.getSelection() == 0) && ((Cultist.Role == CopyCat.currentTarget)
                    || (Outlaw.Role == CopyCat.currentTarget)
                    || (Jester.Role == CopyCat.currentTarget)
                    || (Eater.Role == CopyCat.currentTarget)
                    || (Arsonist.Role == CopyCat.currentTarget)
                    || (Cursed.Role == CopyCat.currentTarget) //die
                    ))
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(0);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 0);
                        CopyCat.CopyCatDie = true;
                    }
                    else if ((CopySpe.getSelection() == 1) && ((Cultist.Role == CopyCat.currentTarget)
                    || (Outlaw.Role == CopyCat.currentTarget)
                    || (Jester.Role == CopyCat.currentTarget)
                    || (Eater.Role == CopyCat.currentTarget)
                    || (Arsonist.Role == CopyCat.currentTarget)
                    || (Cursed.Role == CopyCat.currentTarget) //Sheriff
                    ))
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 1);
                    }
                    else if ((CopySpe.getSelection() == 2) && ((Cultist.Role == CopyCat.currentTarget)
                    || (Outlaw.Role == CopyCat.currentTarget)
                    || (Jester.Role == CopyCat.currentTarget)
                    || (Eater.Role == CopyCat.currentTarget)
                    || (Arsonist.Role == CopyCat.currentTarget)
                    || (Cursed.Role == CopyCat.currentTarget) //Crew
                    ))
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(24);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 24);
                    }
                    else if (CopyCat.currentTarget.Data.Role.IsImpostor && CopyImp.getSelection() == 0) //die
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(0);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 0);
                        CopyCat.CopyCatDie = true;
                    }
                    else if (CopyCat.currentTarget.Data.Role.IsImpostor && CopyImp.getSelection() == 1) //Impo
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(25);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 25);
                    }
                    else if (CopyCat.currentTarget.Data.Role.IsImpostor && CopyImp.getSelection() == 2) //Sheriff
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 1);
                    }
                    else if (CopyCat.currentTarget.Data.Role.IsImpostor && CopyImp.getSelection() == 3) //Crew
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(24);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 24);
                    }
                    else //Crew
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCopyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(CopyCat.currentTarget.PlayerId);
                        writer.Write(24);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setCopyPlayer(CopyCat.currentTarget.PlayerId, 24);
                    }


                    CopyCatScanAbilityButton.Timer = 5f;

                },
                () => { return CopyCat.Role != null && !CopyCat.CopyUsed && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    if (!CopyCat.CopyUsed)
                    {
                        CopyCatScanAbilityButton.Sprite = CopyIco;
                        CopyCatScanAbilityButton.actionButton.OverrideText(BTT_Role_CopyCat);
                        CopyCatScanAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.CopyCatColor);
                    }
                    else
                    {
                        CopyCatScanAbilityButton.Sprite = empty;
                        CopyCatScanAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return !CopyCat.CopyUsed && CopyCat.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => { },
                CopyIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );


            // Outlaw Kill
            OutlawKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Outlaw.Role, Outlaw.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        OutlawKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            OutlawKillButton.Timer = OutlawKillButtonMaxTimer;
                            Outlaw.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.OutlawKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.outlawKill(targetId);
                            OutlawKillButton.Timer = OutlawKillButtonMaxTimer;
                            Outlaw.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            OutlawKillButton.Timer = OutlawKillButtonMaxTimer;
                            Outlaw.currentTarget = null;
                            return;
                        }
                        else
                        {
                            OutlawKillButton.Timer = 0f;
                            Outlaw.currentTarget = null;
                            return;
                        }
                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        //KILL
                        targetId = Outlaw.currentTarget.PlayerId;
                        MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.OutlawKill, Hazel.SendOption.Reliable, -1);
                        messageWriter.Write(targetId);
                        AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                        RPCProcedure.outlawKill(targetId);
                        OutlawKillButton.Timer = ImpostorsKillButtonMaxTimer;
                        Outlaw.currentTarget = null;
                    }


                },
                () => { return Outlaw.Role != null && Outlaw.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {

                    if (Outlaw.canKill)
                    {
                        OutlawKillButton.actionButton.OverrideText(BTT_Role_Kill);
                        OutlawKillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.OutlawColor);

                        if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                        {
                            OutlawKillButton.Sprite = OutlawKill2;
                        }
                        else
                        {
                            OutlawKillButton.Sprite = OutlawKill;
                        }


                    }
                    else
                    {
                        OutlawKillButton.actionButton.OverrideText(BTT_EMPTY);
                        OutlawKillButton.Sprite = Outlaw0;

                    }
                    return Outlaw.currentTarget && PlayerControl.LocalPlayer.CanMove && Outlaw.canKill;
                },
                () => {

                    if (StartTimer == false)
                    {
                        OutlawKillButton.Timer = 15f;
                    }
                    else
                    {
                        OutlawKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                OutlawKill,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );



            //Arsonist

            ArsonistOilAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Arsonist.Role, Arsonist.currentTarget);

                    if (Arsonist.CanBurn)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ArsonistWin, Hazel.SendOption.Reliable, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.arsonistWin();
                    }
                    else
                    {
                        if (Arsonist.currentTarget != null)
                        {
                            Arsonist.castTarget = Arsonist.currentTarget;
                            Arsonist.Fail = false;
                        }

                    }
                },
                () => { return Arsonist.Role != null && Arsonist.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {

                    if (!Arsonist.CanBurn)
                    {
                        if (OilText != null && ArsonistFuelQT.getFloat() != 0f)
                        {
                            OilText.text = "" + Arsonist.FuelPercent + "%\n(-" + Arsonist.FuelSpeed + "%)";
                            if (Arsonist.FuelPercent >= Arsonist.FuelSpeed)
                            {
                                OilText.color = GreenColor;
                            }
                            else
                            {
                                OilText.color = RedColor;
                            }
                        }

                        ArsonistOilAbilityButton.Sprite = OilIco;
                        ArsonistOilAbilityButton.actionButton.OverrideText(BTT_Role_ArsonistOil);
                        ArsonistOilAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.ArsonistColor);

                        if (ArsonistOilAbilityButton.isEffectActive && Arsonist.currentTarget != Arsonist.castTarget && !Arsonist.Fail)
                        {
                            Arsonist.Fail = true;
                            Arsonist.castTarget = null;
                            ArsonistOilAbilityButton.Timer = 0.1f;
                            ArsonistOilAbilityButton.actionButton.cooldownTimerText.color = Color.red;
                        }
                        if (ArsonistOilAbilityButton.isEffectActive && Arsonist.currentTarget == Arsonist.castTarget)
                        {
                            ArsonistOilAbilityButton.actionButton.cooldownTimerText.color = Color.yellow;
                        }
                        if (!ArsonistOilAbilityButton.isEffectActive && !Arsonist.Fail)
                        {
                            ArsonistOilAbilityButton.actionButton.cooldownTimerText.color = Color.white;
                        }
                        if (!ArsonistOilAbilityButton.isEffectActive && Arsonist.Fail)
                        {
                            ArsonistOilAbilityButton.actionButton.cooldownTimerText.color = Color.red;
                        }
                    }
                    else
                    {
                        if (OilText != null)
                        {
                            OilText.text = "-";
                            OilText.color = nocolor;
                        }
                        if (ArsonistOilAbilityButton.Timer > 0f)
                        {
                            ArsonistOilAbilityButton.Timer = 0f;
                        }
                        ArsonistOilAbilityButton.Sprite = BurnIco;
                        ArsonistOilAbilityButton.actionButton.OverrideText(BTT_Role_ArsonistBurn);
                        ArsonistOilAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.ArsonistColor);

                    }
                    return ((Arsonist.currentTarget && (Arsonist.FuelPercent >= Arsonist.FuelSpeed) && !Arsonist.NullTarget) || Arsonist.CanBurn) && PlayerControl.LocalPlayer.CanMove;
                },
                () =>
                {
                    ArsonistOilAbilityButton.Timer = ArsonistOilAbilityButtonMaxTimer;
                    ArsonistOilAbilityButton.isEffectActive = false;
                    Arsonist.castTarget = null;
                },
                OilIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                ArsonistOilAbilityButtonEffectDuration,
                () =>
                {
                    if (Arsonist.castTarget != null)
                    {
                        byte targetId = 0;
                        targetId = Arsonist.castTarget.PlayerId;
                        MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ArsonistAddOil, Hazel.SendOption.Reliable, -1);
                        messageWriter.Write(targetId);
                        AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                        RPCProcedure.arsonistAddOil(targetId);
                        ArsonistOilAbilityButton.Timer = ArsonistOilAbilityButtonMaxTimer;
                        Arsonist.currentTarget = null;
                        Arsonist.castTarget = null;
                        Arsonist.Fuel -= (Arsonist.FuelSpeed * 10);
                    }
                    else
                    {
                        ArsonistOilAbilityButton.Timer = Arsonist.FailTimer;
                        ArsonistOilAbilityButton.actionButton.cooldownTimerText.color = LawkeeperColor;
                    }

                }
            );
            OilText = GameObject.Instantiate(ArsonistOilAbilityButton.actionButton.cooldownTimerText, ArsonistOilAbilityButton.actionButton.cooldownTimerText.transform.parent);
            OilText.text = "";
            OilText.color = ArsonistColor;
            OilText.transform.localScale = Vector3.one * 0.62f;
            OilText.transform.localPosition += new Vector3(0f, 0.9f, 0);
            OilText.enableWordWrapping = false;


            // Vector Infect 
            VectorInfectAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Vector.Role, Vector.currentTarget);


                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        VectorInfectAbilityButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        VectorInfectAbilityButton.Timer = VectorInfectAbilityButtonMaxTimer;
                        Vector.currentTarget = null;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            VectorInfectAbilityButton.Timer = VectorInfectAbilityButtonMaxTimer;
                            Vector.currentTarget = null;
                            return;
                        }
                        else
                        {
                            VectorInfectAbilityButton.Timer = 0f;
                            Vector.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {

                        if ((Vector.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Vector.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Vector.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Vector.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            VectorInfectAbilityButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            if (!AbilityDisabled)
                            {
                                //INFECT
                                VectorInfectAbilityButton.Timer = VectorInfectAbilityButtonMaxTimer;
                                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetInfectePlayer, Hazel.SendOption.Reliable, -1);
                                writer.Write(Vector.currentTarget.PlayerId);
                                AmongUsClient.Instance.FinishRpcImmediately(writer);
                                RPCProcedure.setInfectePlayer(Vector.currentTarget.PlayerId);
                                Vector.infect = true;
                                VectorKillButton.Timer = VectorKillButtonMaxTimer;
                                return;
                            }
                            else
                            {
                                //KILL
                                VectorInfectAbilityButton.Timer = VectorInfectAbilityButtonMaxTimer;
                                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.VectorKill, Hazel.SendOption.Reliable, -1);
                                writer.Write(Vector.currentTarget.PlayerId);
                                AmongUsClient.Instance.FinishRpcImmediately(writer);
                                RPCProcedure.vectorKill(Vector.currentTarget.PlayerId);
                                VectorKillButton.Timer = VectorKillButtonMaxTimer;
                                return;


                            }

                        }
                    }
                },
                () => { return Vector.Role != null && Vector.Infected == null && Vector.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    if (Vector.Infected == null && !AbilityDisabled)
                    {
                        VectorInfectAbilityButton.actionButton.OverrideText(BTT_Role_Vector);
                        VectorInfectAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.VectorColor);

                        if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                        {
                            VectorInfectAbilityButton.Sprite = slayerIco2;
                        }
                        else
                        {
                            VectorInfectAbilityButton.Sprite = slayerIco;
                        }

                    }
                    else if (AbilityDisabled)
                    {
                        VectorInfectAbilityButton.actionButton.OverrideText(BTT_Role_Kill);
                        VectorInfectAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.RedColor);

                        if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                        {
                            VectorInfectAbilityButton.Sprite = IkillIco2;
                        }
                        else
                        {
                            VectorInfectAbilityButton.Sprite = IkillIco;
                        }


                    }
                    else
                    {
                        VectorInfectAbilityButton.Sprite = empty;
                        VectorInfectAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return Vector.Infected == null && Vector.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        VectorInfectAbilityButton.Timer = 15f;
                    }
                    else
                    {
                        VectorInfectAbilityButton.Timer = VectorInfectAbilityButtonMaxTimer;
                    }


                },
                slayerIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill
            );


            // Vector FakeKill
            VectorKillButton = new CustomButton(
                () => {


                    VectorKillButton.Timer = VectorKillButtonMaxTimer;
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.KillInfected, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.killInfected();
                    VectorInfectAbilityButton.Timer = VectorInfectAbilityButtonMaxTimer;


                },
                () => { return Vector.Role != null && Vector.Infected != null && Vector.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (Vector.Infected != null)
                    {
                        VectorKillButton.actionButton.OverrideText(BTT_Role_Kill);
                        VectorKillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.VectorColor);

                        if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                        {
                            VectorKillButton.Sprite = KillSlayerIco2;
                        }
                        else
                        {
                            VectorKillButton.Sprite = KillSlayerIco;
                        }

                    }
                    else
                    {
                        VectorKillButton.Sprite = empty;
                        VectorKillButton.actionButton.OverrideText(BTT_EMPTY);
                    }


                    return Vector.Infected != null && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    VectorKillButton.Timer = VectorKillButtonMaxTimer;
                },
                KillSlayerIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill
            );





            // Morphling Scan 
            MorphlingScanAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Morphling.Role, Morphling.currentTarget);

                    MorphlingScanAbilityButton.Timer = MorphlingScanAbilityButtonMaxTimer;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetMorphPlayer, Hazel.SendOption.Reliable, -1);
                    writer.Write(Morphling.currentTarget.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.setMorphPlayer(Morphling.currentTarget.PlayerId);
                    MorphlingMorphAbilityButton.Timer = MorphlingMorphAbilityButtonMaxTimer;

                },
                () => { return Morphling.Role != null && Morphling.Morph == null && Morphling.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (Morphling.Morph == null)
                    {
                        MorphlingScanAbilityButton.Sprite = ScanIco;
                        MorphlingScanAbilityButton.actionButton.OverrideText(BTT_Role_MorphlingSteal);
                        MorphlingScanAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.MorphlingColor);
                    }
                    else
                    {
                        MorphlingScanAbilityButton.Sprite = empty;
                        MorphlingScanAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }
                    return Morphling.Morph == null && Morphling.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        MorphlingScanAbilityButton.Timer = MorphlingScanAbilityButtonMaxTimer / 2;
                    }
                    else
                    {
                        MorphlingScanAbilityButton.Timer = MorphlingScanAbilityButtonMaxTimer;
                    }


                },
                ScanIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F
            );
            // Morphling Morph
            MorphlingMorphAbilityButton = new CustomButton(
                () => {

                    MorphlingMorphAbilityButton.EffectDuration = MorphlingMorphAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MorphOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.morphOn();
                    ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 50f / 255f, 255f / 255f), 1f);

                },
                () => { return Morphling.Role != null && Morphling.Morph != null && Morphling.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    MorphlingMorphAbilityButton.actionButton.OverrideText(BTT_Role_MorphlingMorph);
                    MorphlingMorphAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.MorphlingColor);


                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    MorphlingMorphAbilityButton.Timer = MorphlingMorphAbilityButtonMaxTimer;
                    MorphlingMorphAbilityButton.isEffectActive = false;
                    MorphlingMorphAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                MorphIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                MorphlingMorphAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MorphOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.morphOff();
                    ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 50f / 255f, 255f / 255f), 1f);
                    MorphlingMorphAbilityButton.Timer = MorphlingMorphAbilityButtonMaxTimer;
                }
            );



            // Ghost hide
            GhostAbilityButton = new CustomButton(
                () => {

                    GhostAbilityButton.EffectDuration = GhostAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GhostOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.ghostOn();

                    PlayerControl.LocalPlayer.Visible = true;
                    SoundManager.Instance.PlaySound(PoisonDelay, false, 100f);
                    PlayerControl.LocalPlayer.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                    PlayerControl.LocalPlayer.cosmetics.skin.layer.color = Palette.DisabledClear;
                    PlayerControl.LocalPlayer.cosmetics.hat.BackLayer.color = Palette.DisabledClear;
                    PlayerControl.LocalPlayer.cosmetics.hat.FrontLayer.color = Palette.DisabledClear;
                    PlayerControl.LocalPlayer.cosmetics.currentPet.rend.color = Palette.DisabledClear;
                    PlayerControl.LocalPlayer.cosmetics.visor.Visible = false;

                },
                () => { return Ghost.Role != null && Ghost.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    GhostAbilityButton.actionButton.OverrideText(BTT_Role_Ghost);
                    GhostAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.GhostColor);


                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    GhostAbilityButton.Timer = GhostAbilityButtonMaxTimer;
                    GhostAbilityButton.isEffectActive = false;
                    GhostAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                Hideico,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                GhostAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GhostOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.ghostOff();
                    PlayerControl.LocalPlayer.Visible = true;
                    SoundManager.Instance.StopSound(PoisonDelay);
                    if (ComIsSab == true && StartComSabUnk == true)
                    {
                        PlayerControl.LocalPlayer.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                    }
                    else
                    {
                        PlayerControl.LocalPlayer.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;

                    }
                    PlayerControl.LocalPlayer.cosmetics.skin.layer.color = Palette.EnabledColor;
                    PlayerControl.LocalPlayer.cosmetics.hat.BackLayer.color = Palette.EnabledColor;
                    PlayerControl.LocalPlayer.cosmetics.hat.FrontLayer.color = Palette.EnabledColor;
                    PlayerControl.LocalPlayer.cosmetics.currentPet.rend.color = Palette.EnabledColor;
                    PlayerControl.LocalPlayer.cosmetics.visor.Visible = true;
                    GhostAbilityButton.Timer = GhostAbilityButtonMaxTimer;
                }
            );

            // Scrambler hide
            ScramblerAbilityButton = new CustomButton(
                () => {

                    ScramblerAbilityButton.EffectDuration = ScramblerAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CamoOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.camoOn();



                },
                () => { return Scrambler.Role != null && Scrambler.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    ScramblerAbilityButton.actionButton.OverrideText(BTT_Role_Scrambler);
                    ScramblerAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.ScramblerColor);


                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    ScramblerAbilityButton.Timer = ScramblerAbilityButtonMaxTimer;
                    ScramblerAbilityButton.isEffectActive = false;
                    ScramblerAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                CamoIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                ScramblerAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CamoOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.camoOff();


                    ScramblerAbilityButton.Timer = ScramblerAbilityButtonMaxTimer;
                }
            );

            // Barghest Shadow
            BarghestShadowAbilityButton = new CustomButton(
                () => {

                    BarghestShadowAbilityButton.EffectDuration = BarghestShadowAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShadowOn, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.shadowOn();
                    PlayerControl.LocalPlayer.MyPhysics.Speed = 1.85f;



                },
                () => { return Barghest.Role != null && Barghest.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    BarghestShadowAbilityButton.actionButton.OverrideText(BTT_Role_BarghestShadow);
                    BarghestShadowAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.BarghestColor);


                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    BarghestShadowAbilityButton.Timer = BarghestShadowAbilityButtonMaxTimer;
                    BarghestShadowAbilityButton.isEffectActive = false;
                    BarghestShadowAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                ShadowIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                BarghestShadowAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShadowOff, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.shadowOff();
                    PlayerControl.LocalPlayer.MyPhysics.Speed = 2.5f;


                    BarghestShadowAbilityButton.Timer = BarghestShadowAbilityButtonMaxTimer;
                }
            );

            BarghestCreateVentAbilityButton = new CustomButton(
                () => {
                    BarghestCreateVentAbilityButton.Timer = BarghestCreateVentAbilityButtonMaxTimer;

                    var pos = PlayerControl.LocalPlayer.transform.position;
                    byte[] buff = new byte[sizeof(float) * 2];
                    Buffer.BlockCopy(BitConverter.GetBytes(pos.x), 0, buff, 0 * sizeof(float), sizeof(float));
                    Buffer.BlockCopy(BitConverter.GetBytes(pos.y), 0, buff, 1 * sizeof(float), sizeof(float));

                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CreateVent, Hazel.SendOption.Reliable);
                    writer.WriteBytesAndSize(buff);
                    writer.EndMessage();
                    RPCProcedure.createVent(buff);
                    Barghest.VentUse = true;

                },
                () => { return Barghest.Role != null && Barghest.Role == PlayerControl.LocalPlayer && !Barghest.VentUse && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled; },
                () => {
                    if (!Barghest.VentUse)
                    {
                        BarghestCreateVentAbilityButton.Sprite = createventIco;
                        BarghestCreateVentAbilityButton.actionButton.OverrideText(BTT_Role_BarghestVent);
                        BarghestCreateVentAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.BarghestColor);

                    }
                    else
                    {
                        BarghestCreateVentAbilityButton.Sprite = empty;
                        BarghestCreateVentAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }

                    return PlayerControl.LocalPlayer.CanMove && !Barghest.VentUse;
                },
                () => {

                    BarghestCreateVentAbilityButton.Timer = BarghestCreateVentAbilityButtonMaxTimer;
                },
                createventIco,
                new Vector3(0f, 2f, 0),
                __instance,
                KeyCode.G
            );


            // SORCERER  
            SorcererFindAbilityButton = new CustomButton(
                () => {
                    Sorcerer.CircleEnabled = true;
                    Sorcerer.ButtonCircle = false;
                },
                () => {
                    return (Sorcerer.Role != null && Sorcerer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    if (RuneText != null)
                    {
                        if (!Sorcerer.LootValue4)
                        {
                            RuneText.text = "" + Sorcerer.TotalRuneLoot + " / 4";
                            RuneText.color = SorcererColor;
                            SorcererFindAbilityButton.Sprite = LocRune;
                            SorcererFindAbilityButton.actionButton.OverrideText(BTT_Role_SorcererFind);
                            SorcererFindAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SorcererColor);
                        }
                        else
                        {
                            RuneText.text = "-";
                            RuneText.color = nocolor;
                            SorcererFindAbilityButton.Sprite = empty;
                            SorcererFindAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                        }
                    }
                    return !Sorcerer.LootValue4 && !FirstTurn && !Sorcerer.ButtonCircle && PlayerControl.LocalPlayer.CanMove;
                },
                () =>
                {
                    if (StartTimer == false)
                    {
                        SorcererFindAbilityButton.Timer = 0f;
                    }
                    else
                    {
                        SorcererFindAbilityButton.Timer = SorcererFindAbilityButtonMaxTimer;
                    }
                },
                LocRune,
                new Vector3(-1.8f, 0f, 0),
                __instance,
                KeyCode.F
            );
            RuneText = GameObject.Instantiate(SorcererFindAbilityButton.actionButton.cooldownTimerText, SorcererFindAbilityButton.actionButton.cooldownTimerText.transform.parent);
            RuneText.text = "";
            RuneText.color = SorcererColor;
            RuneText.transform.localScale = Vector3.one * 0.75f;
            RuneText.transform.localPosition += new Vector3(0f, 0.8f, 0);
            RuneText.enableWordWrapping = false;

            // SORCERER  1
            Sorcerer1AbilityButton = new CustomButton(
                () => {

                    Sorcerer.TotalRune -= 1;
                    ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 0f / 255f), 0.5f);
                    Sorcerer1AbilityButton.Timer = 0.5f;
                    Sorcerer2AbilityButton.Timer = 0.5f;
                    Sorcerer3AbilityButton.Timer = 0.5f;
                    Sorcerer4AbilityButton.Timer = 0.5f;
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                    if (SorcererKillButton.Timer > 3f)
                    {
                        SorcererKillButton.Timer -= 3f;
                    }
                    else
                    {
                        SorcererKillButton.Timer = 0f;
                    }
                },
                () => {
                    return (Sorcerer.Role != null && Sorcerer.CanUse1 && Sorcerer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    Sorcerer1AbilityButton.Sprite = SorcererIco1;
                    Sorcerer1AbilityButton.actionButton.OverrideText(BTT_Role_Sorcerer1);
                    Sorcerer1AbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SorcererColor);

                    return (Sorcerer.TotalRune > 0) && (SorcererKillButton.Timer > 0) && PlayerControl.LocalPlayer.CanMove;
                },
                () => { Sorcerer1AbilityButton.Timer = 5f; },
                SorcererIco1,
                new Vector3(0f, 2f, 0),
                __instance,
                KeyCode.F1
            );
            // SORCERER  2
            Sorcerer2AbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Sorcerer.Role, Sorcerer.currentTarget);

                    if (Sorcerer.Scan1 == null)
                    {
                        if (Sheriff1.Role != null && Sheriff1.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 1; }
                        else if (Sheriff2.Role != null && Sheriff2.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 1; }
                        else if (Sheriff3.Role != null && Sheriff3.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 1; }
                        else if (Guardian.Role != null && Guardian.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 2; }
                        else if (Engineer.Role != null && Engineer.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 3; }
                        else if (Timelord.Role != null && Timelord.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 4; }
                        else if (Hunter.Role != null && Hunter.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 5; }
                        else if (Mystic.Role != null && Mystic.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 6; }
                        else if (Spirit.Role != null && Spirit.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 7; }
                        else if (Mayor.Role != null && Mayor.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 8; }
                        else if (Detective.Role != null && Detective.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 9; }
                        else if (Nightwatch.Role != null && Nightwatch.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 10; }
                        else if (Spy.Role != null && Spy.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 11; }
                        else if (Informant.Role != null && Informant.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 12; }
                        else if (Bait.Role != null && Bait.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 13; }
                        else if (Mentalist.Role != null && Mentalist.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 14; }
                        else if (Builder.Role != null && Builder.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 15; }
                        else if (Dictator.Role != null && Dictator.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 16; }
                        else if (Sentinel.Role != null && Sentinel.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 17; }
                        else if (Teammate1.Role != null && Teammate1.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 18; }
                        else if (Teammate2.Role != null && Teammate2.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 18; }
                        else if (Lawkeeper.Role != null && Lawkeeper.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 19; }
                        else if (Fake.Role != null && Fake.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 20; }
                        else if (Traveler.Role != null && Traveler.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 21; }
                        else if (Leader.Role != null && Leader.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 22; }
                        else if (Doctor.Role != null && Doctor.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 23; }
                        else if (Slave.Role != null && Slave.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 24; }
                        else if (Cupid.Role != null && Cupid.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 25; }
                        else if (Cultist.Role != null && Cultist.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 26; }
                        else if (Outlaw.Role != null && Outlaw.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 27; }
                        else if (Jester.Role != null && Jester.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 28; }
                        else if (Eater.Role != null && Eater.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 29; }
                        else if (Arsonist.Role != null && Arsonist.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 30; }
                        else if (Mercenary.Role != null && Mercenary.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 31; }
                        else if (CopyCat.Role != null && CopyCat.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 32; }
                        else if (Survivor.Role != null && Survivor.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 33; }
                        else if (Revenger.Role != null && Revenger.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 34; }
                        else if (Assassin.Role != null && Assassin.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 35; }
                        else if (Vector.Role != null && Vector.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 36; }
                        else if (Morphling.Role != null && Morphling.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 37; }
                        else if (Scrambler.Role != null && Scrambler.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 38; }
                        else if (Barghest.Role != null && Barghest.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 39; }
                        else if (Ghost.Role != null && Ghost.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 40; }
                        else if (Guesser.Role != null && Guesser.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 41; }
                        else if (Mesmer.Role != null && Mesmer.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 42; }
                        else if (Basilisk.Role != null && Basilisk.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 43; }
                        else if (Reaper.Role != null && Reaper.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 44; }
                        else if (Saboteur.Role != null && Saboteur.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 45; }
                        else if (Impostor1.Role != null && Impostor1.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 47; }
                        else if (Impostor2.Role != null && Impostor2.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 47; }
                        else if (Impostor3.Role != null && Impostor3.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 47; }
                        else if (Cursed.Role != null && Cursed.Role == Sorcerer.currentTarget) { Sorcerer.SetScan1 = 48; }
                        else { Sorcerer.SetScan1 = 46; }

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetScan1Player, Hazel.SendOption.Reliable, -1);
                        writer.Write(Sorcerer.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setScan1Player(Sorcerer.currentTarget.PlayerId);
                        Sorcerer.TotalRune -= 2;
                        ChallengerMod.Utils.Helpers.showFlash(new Color(150f / 255f, 100f / 255f, 50f / 255f), 0.5f);
                        Sorcerer1AbilityButton.Timer = 0.5f;
                        Sorcerer2AbilityButton.Timer = 0.5f;
                        Sorcerer3AbilityButton.Timer = 0.5f;
                        Sorcerer4AbilityButton.Timer = 0.5f;
                        SoundManager.Instance.PlaySound(Used, false, 100f);

                    }
                    else
                    {
                        if (Sheriff1.Role != null && Sheriff1.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 1; }
                        else if (Sheriff2.Role != null && Sheriff2.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 1; }
                        else if (Sheriff3.Role != null && Sheriff3.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 1; }
                        else if (Guardian.Role != null && Guardian.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 2; }
                        else if (Engineer.Role != null && Engineer.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 3; }
                        else if (Timelord.Role != null && Timelord.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 4; }
                        else if (Hunter.Role != null && Hunter.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 5; }
                        else if (Mystic.Role != null && Mystic.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 6; }
                        else if (Spirit.Role != null && Spirit.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 7; }
                        else if (Mayor.Role != null && Mayor.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 8; }
                        else if (Detective.Role != null && Detective.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 9; }
                        else if (Nightwatch.Role != null && Nightwatch.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 10; }
                        else if (Spy.Role != null && Spy.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 11; }
                        else if (Informant.Role != null && Informant.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 12; }
                        else if (Bait.Role != null && Bait.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 13; }
                        else if (Mentalist.Role != null && Mentalist.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 14; }
                        else if (Builder.Role != null && Builder.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 15; }
                        else if (Dictator.Role != null && Dictator.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 16; }
                        else if (Sentinel.Role != null && Sentinel.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 17; }
                        else if (Teammate1.Role != null && Teammate1.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 18; }
                        else if (Teammate2.Role != null && Teammate2.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 18; }
                        else if (Lawkeeper.Role != null && Lawkeeper.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 19; }
                        else if (Fake.Role != null && Fake.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 20; }
                        else if (Traveler.Role != null && Traveler.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 21; }
                        else if (Leader.Role != null && Leader.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 22; }
                        else if (Doctor.Role != null && Doctor.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 23; }
                        else if (Slave.Role != null && Slave.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 24; }
                        else if (Cupid.Role != null && Cupid.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 25; }
                        else if (Cultist.Role != null && Cultist.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 26; }
                        else if (Outlaw.Role != null && Outlaw.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 27; }
                        else if (Jester.Role != null && Jester.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 28; }
                        else if (Eater.Role != null && Eater.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 29; }
                        else if (Arsonist.Role != null && Arsonist.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 30; }
                        else if (Mercenary.Role != null && Mercenary.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 31; }
                        else if (CopyCat.Role != null && CopyCat.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 32; }
                        else if (Survivor.Role != null && Survivor.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 33; }
                        else if (Revenger.Role != null && Revenger.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 34; }
                        else if (Assassin.Role != null && Assassin.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 35; }
                        else if (Vector.Role != null && Vector.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 36; }
                        else if (Morphling.Role != null && Morphling.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 37; }
                        else if (Scrambler.Role != null && Scrambler.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 38; }
                        else if (Barghest.Role != null && Barghest.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 39; }
                        else if (Ghost.Role != null && Ghost.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 40; }
                        else if (Guesser.Role != null && Guesser.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 41; }
                        else if (Mesmer.Role != null && Mesmer.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 42; }
                        else if (Basilisk.Role != null && Basilisk.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 43; }
                        else if (Reaper.Role != null && Reaper.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 44; }
                        else if (Saboteur.Role != null && Saboteur.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 45; }
                        else if (Impostor1.Role != null && Impostor1.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 47; }
                        else if (Impostor2.Role != null && Impostor2.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 47; }
                        else if (Impostor3.Role != null && Impostor3.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 47; }
                        else if (Cursed.Role != null && Cursed.Role == Sorcerer.currentTarget) { Sorcerer.SetScan2 = 48; }
                        else { Sorcerer.SetScan2 = 46; }

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetScan2Player, Hazel.SendOption.Reliable, -1);
                        writer.Write(Sorcerer.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setScan2Player(Sorcerer.currentTarget.PlayerId);
                        Sorcerer.TotalRune -= 2;
                        ChallengerMod.Utils.Helpers.showFlash(new Color(150f / 255f, 100f / 255f, 50f / 255f), 0.5f);
                        Sorcerer1AbilityButton.Timer = 0.5f;
                        Sorcerer2AbilityButton.Timer = 0.5f;
                        Sorcerer3AbilityButton.Timer = 0.5f;
                        Sorcerer4AbilityButton.Timer = 0.5f;
                        SoundManager.Instance.PlaySound(Used, false, 100f);

                    }
                    //TAG 1/2


                },
                () => {
                    return (Sorcerer.Role != null && Sorcerer.CanUse2 && Sorcerer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    Sorcerer2AbilityButton.Sprite = SorcererIco2;
                    Sorcerer2AbilityButton.actionButton.OverrideText(BTT_Role_Sorcerer2);
                    Sorcerer2AbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SorcererColor);

                    return Sorcerer.currentTarget && (Sorcerer.TotalRune > 1) && PlayerControl.LocalPlayer.CanMove;
                },
                () => { Sorcerer2AbilityButton.Timer = 5f; },
                SorcererIco2,
                new Vector3(-0.9f, 2f, 0),
                __instance,
                 KeyCode.F2
            );
            // SORCERER  3
            Sorcerer3AbilityButton = new CustomButton(
                () => {

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SabAdmin, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.sabAdmin();
                    Sorcerer.TotalRune -= 3;
                    ChallengerMod.Utils.Helpers.showFlash(new Color(150f / 255f, 150f / 255f, 150f / 255f), 0.5f);
                    Sorcerer1AbilityButton.Timer = 0.5f;
                    Sorcerer2AbilityButton.Timer = 0.5f;
                    Sorcerer3AbilityButton.Timer = 0.5f;
                    Sorcerer4AbilityButton.Timer = 0.5f;
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                    //ADMIN
                },
                () => {
                    return (Sorcerer.Role != null && Sorcerer.CanUse3 && Sorcerer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    Sorcerer3AbilityButton.Sprite = SorcererIco3;
                    Sorcerer3AbilityButton.actionButton.OverrideText(BTT_Role_Sorcerer3);
                    Sorcerer3AbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SorcererColor);

                    return (Sorcerer.TotalRune > 2) && PlayerControl.LocalPlayer.CanMove;
                },
                () => { Sorcerer3AbilityButton.Timer = 5f; },
                SorcererIco3,
                new Vector3(-1.8f, 2f, 0),
                __instance,
                 KeyCode.F3
            );
            // SORCERER  4
            Sorcerer4AbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Sorcerer.Role, Sorcerer.currentTarget);

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetExtPlayer, Hazel.SendOption.Reliable, -1);
                    writer.Write(Sorcerer.currentTarget.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.setExtPlayer(Sorcerer.currentTarget.PlayerId);
                    Sorcerer.TotalRune -= 4;
                    Sorcerer1AbilityButton.Timer = 0.5f;
                    Sorcerer2AbilityButton.Timer = 0.5f;
                    Sorcerer3AbilityButton.Timer = 0.5f;
                    Sorcerer4AbilityButton.Timer = 0.5f;
                    ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 0f / 255f, 0f / 255f), 0.5f);
                    SoundManager.Instance.PlaySound(Used, false, 100f);

                },
                () => {
                    return (Sorcerer.Role != null && Sorcerer.CanUse4 && Sorcerer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled);
                },

                () => {

                    Sorcerer4AbilityButton.Sprite = KillSorcererIco;
                    Sorcerer4AbilityButton.actionButton.OverrideText(BTT_Role_Sorcerer);
                    Sorcerer4AbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.SorcererColor);

                    return Sorcerer.currentTarget && (Sorcerer.TotalRune > 3) && PlayerControl.LocalPlayer.CanMove;
                },
                () => { Sorcerer4AbilityButton.Timer = 5f; },
                KillSorcererIco,
                new Vector3(0f, 3f, 0),
                __instance,
                 KeyCode.F4
            );

            // Basilisk petrify
            BasiliskAbilityButton = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Basilisk.Role, Basilisk.currentTarget);

                    BasiliskAbilityButton.Timer = 0f;

                    if (Petrifiedplayers.Contains(Basilisk.currentTarget)) { }
                    else
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetPetrifyPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Basilisk.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setPetrifyPlayer(Basilisk.currentTarget.PlayerId);

                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                },
                () => { return Basilisk.Role != null && !Basilisk.Used && Basilisk.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled && Basilisk.CanPetrify; },
                () => {

                    if (ParalyzeText != null)
                    {
                        if (!Basilisk.Used)
                        {


                            ParalyzeText.text = "(-" + Basilisk.CostParalize + ")";
                            ParalyzeText.color = PurpleColor;

                            BasiliskAbilityButton.Sprite = PetrifyIco;
                            BasiliskAbilityButton.actionButton.OverrideText(BTT_Role_Basilisk);
                            BasiliskAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.BasiliskColor);
                        }
                        else
                        {
                            BasiliskAbilityButton.Sprite = empty;
                            BasiliskAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                        }
                    }
                    return !Basilisk.Used && Basilisk.currentTarget && !Basilisk.NullTarget && PlayerControl.LocalPlayer.CanMove && Basilisk.PetrifyCount >= Basilisk.CostParalize;
                },
                () => { },
                PetrifyIco,
                new Vector3(0f, 2f, 0),
                __instance,
                 KeyCode.F
            );
            ParalyzeText = GameObject.Instantiate(BasiliskAbilityButton.actionButton.cooldownTimerText, BasiliskAbilityButton.actionButton.cooldownTimerText.transform.parent);
            ParalyzeText.text = "";
            ParalyzeText.color = PurpleColor;
            ParalyzeText.transform.localScale = Vector3.one * 0.68f;
            ParalyzeText.transform.localPosition += new Vector3(0f, 0.72f, 0);
            ParalyzeText.enableWordWrapping = false;


            BasiliskAbility2Button = new CustomButton(
                () => {
                    MurderAttemptResult murder = Helpers.checkMurderAttempt(Basilisk.Role, Basilisk.currentTarget);

                    BasiliskAbility2Button.Timer = 0f;

                    if (Petrifiedplayers.Contains(Basilisk.currentTarget)) { }
                    else
                    {

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetPetrifyAndShieldPlayer, Hazel.SendOption.Reliable, -1);
                        writer.Write(Basilisk.currentTarget.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setPetrifyAndShieldPlayer(Basilisk.currentTarget.PlayerId);

                        SoundManager.Instance.PlaySound(Used, false, 100f);
                    }
                },
                () => { return Basilisk.Role != null && !Basilisk.Used && Basilisk.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead && !AbilityDisabled && Basilisk.CanPetrifyAndShield; },
                () => {

                    if (ParalyzeText != null)
                    {
                        if (!Basilisk.Used)
                        {


                            PetrifyText.text = "(-" + Basilisk.CostPetrify + ")";
                            PetrifyText.color = RedColor;


                            BasiliskAbility2Button.Sprite = Petrify2Ico;
                            BasiliskAbility2Button.actionButton.OverrideText(BTT_Role_Basilisk2);
                            BasiliskAbility2Button.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.BasiliskColor);
                        }
                        else
                        {
                            BasiliskAbility2Button.Sprite = empty;
                            BasiliskAbility2Button.actionButton.OverrideText(BTT_EMPTY);
                        }
                    }
                    return !Basilisk.Used && Basilisk.currentTarget && !Basilisk.NullTarget && PlayerControl.LocalPlayer.CanMove && Basilisk.PetrifyCount >= Basilisk.CostPetrify;
                },
                () => { },
                Petrify2Ico,
                new Vector3(-0.9f, 2f, 0),
                __instance,
                 KeyCode.G
            );
            PetrifyText = GameObject.Instantiate(BasiliskAbility2Button.actionButton.cooldownTimerText, BasiliskAbility2Button.actionButton.cooldownTimerText.transform.parent);
            PetrifyText.text = "";
            PetrifyText.color = RedColor;
            PetrifyText.transform.localScale = Vector3.one * 0.68f;
            PetrifyText.transform.localPosition += new Vector3(0f, 0.72f, 0);
            PetrifyText.enableWordWrapping = false;


            // Assassin BreakTime
            AssassinTimelordAbilityButton = new CustomButton(
                () => {

                    AssassinTimelordAbilityButton.EffectDuration = TimelordAbilityButtonEffectDuration;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.TimeStop_Start, Hazel.SendOption.Reliable, -1);
                    writer.Write(3);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.timeStop_Start(3);
                },
                () => { return Assassin.Role != null && Assassin.Role == PlayerControl.LocalPlayer && Assassin.StealTime && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {

                    if (Assassin.StealTime)
                    {
                        AssassinTimelordAbilityButton.Sprite = stopIco;
                        AssassinTimelordAbilityButton.actionButton.OverrideText(BTT_Role_Timelord);
                        AssassinTimelordAbilityButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.AssassinColor);

                    }
                    else
                    {
                        AssassinTimelordAbilityButton.Sprite = empty;
                        AssassinTimelordAbilityButton.actionButton.cooldownTimerText.color = new Color(0F, 0F, 0F, 0F);
                        AssassinTimelordAbilityButton.actionButton.OverrideText(BTT_EMPTY);
                    }

                    return PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    AssassinTimelordAbilityButton.Timer = TimelordAbilityButtonMaxTimer;
                    AssassinTimelordAbilityButton.isEffectActive = false;
                    AssassinTimelordAbilityButton.actionButton.cooldownTimerText.color = Palette.EnabledColor;

                },
                stopIco,
                new Vector3(-1.9f, 0f, 0),
                __instance,
                KeyCode.F,
                true,
                TimelordAbilityButtonEffectDuration,
                () => {
                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.TimeStop_End, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.timeStop_End();
                    AssassinTimelordAbilityButton.Timer = TimelordAbilityButtonMaxTimer;
                }
            );
            // Assassin Kill
            AssassinKillButton = new CustomButton(
             () => {
                 MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Assassin.Role, Assassin.currentTarget);
                 if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                 {
                     AssassinKillButton.Timer = 0f;
                     return;
                 }
                 else if (murderAttemptResult == MurderAttemptResult.Guardianshield && !Assassin.CanKillShield) //GUARDIAN SHIELD
                 {
                     byte targetId = 0;
                     if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                     {
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.currentTarget = null;
                         return;
                     }
                     else //Guardian shield - Reflect
                     {
                         //SELF-KILL
                         targetId = PlayerControl.LocalPlayer.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.currentTarget = null;
                         return;
                     }

                 }
                 else if (murderAttemptResult == MurderAttemptResult.MysticShield && !Assassin.CanKillShield)  // MYSTIC SHIELD
                 {
                     if (Mystic.DoubleShield)
                     {
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.currentTarget = null;
                         return;
                     }
                     else
                     {
                         AssassinKillButton.Timer = 0f;
                         Assassin.currentTarget = null;
                         return;
                     }

                 }
                 else if ((Assassin.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                         || (Assassin.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                         || ((Fake.Role == Assassin.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                         || ((Assassin.Role == Assassin.currentTarget) && Assassin.Shielded == true)
                              )
                 {
                     AssassinKillButton.Timer = 0f;
                     return;
                 }
                 else
                 {
                     byte targetId = 0;

                     if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer == Assassin.currentTarget)
                     {
                         //Cancel & Save bonus for CopyCat - CopiedPlayer Ability
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (Sheriff1.Role != null && Sheriff1.Role == Assassin.currentTarget && Assassin.BSheriff == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = 0f;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 0 / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (Sheriff2.Role != null && Sheriff2.Role == Assassin.currentTarget && Assassin.BSheriff == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = 0f;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 0 / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (Sheriff3.Role != null && Sheriff3.Role == Assassin.currentTarget && Assassin.BSheriff == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = 0f;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 0 / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 1) && (CopyCat.CopyStart == true) && Assassin.BSheriff == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = 0f;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 0 / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (Guardian.Role != null && Guardian.Role == Assassin.currentTarget && Assassin.BGuardian == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealShield = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 2) && (CopyCat.CopyStart == true) && Assassin.BGuardian == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealShield = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (Engineer.Role != null && Engineer.Role == Assassin.currentTarget && Assassin.BEngineer == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVent = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(140f / 255f, 80f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 3) && (CopyCat.CopyStart == true) && Assassin.BEngineer == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVent = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(140f / 255f, 80f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Timelord.Role != null && Timelord.Role == Assassin.currentTarget && Assassin.BTimelord == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealTime = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 125f / 255f, 255f / 255f), 0.5f);
                         AssassinTimelordAbilityButton.Timer = TimelordAbilityButtonMaxTimer;
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 4) && (CopyCat.CopyStart == true) && Assassin.BTimelord == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealTime = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 125f / 255f, 255f / 255f), 0.5f);
                         AssassinTimelordAbilityButton.Timer = TimelordAbilityButtonMaxTimer;
                         Assassin.currentTarget = null;

                         return;
                     }
                     else if (Mystic.Role != null && Mystic.Role == Assassin.currentTarget && Assassin.BMystic == true && !AbilityDisabled)
                     {

                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealShield = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 6) && (CopyCat.CopyStart == true) && Assassin.BMystic == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealShield = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Mayor.Role != null && Mayor.Role == Assassin.currentTarget && Assassin.BMayor == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVoteColor = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 8) && (CopyCat.CopyStart == true) && Assassin.BMayor == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVoteColor = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Detective.Role != null && Detective.Role == Assassin.currentTarget && Assassin.BDetective == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealFootPrint = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 9) && (CopyCat.CopyStart == true) && Assassin.BDetective == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealFootPrint = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Nightwatch.Role != null && Nightwatch.Role == Assassin.currentTarget && Assassin.BNightwatcher == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVision = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 10) && (CopyCat.CopyStart == true) && Assassin.BNightwatcher == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVision = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Spy.Role != null && Spy.Role == Assassin.currentTarget && Assassin.BSpy == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVision = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 11) && (CopyCat.CopyStart == true) && Assassin.BSpy == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVision = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Informant.Role != null && Informant.Role == Assassin.currentTarget && Assassin.BInfor == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealPlayerInfo = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 12) && (CopyCat.CopyStart == true) && Assassin.BInfor == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealPlayerInfo = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Mentalist.Role != null && Mentalist.Role == Assassin.currentTarget && Assassin.BMentalist == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealAdminColor = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 14) && (CopyCat.CopyStart == true) && Assassin.BMentalist == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealAdminColor = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Builder.Role != null && Builder.Role == Assassin.currentTarget && Assassin.BBuilder == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVent = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(140f / 255f, 80f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 15) && (CopyCat.CopyStart == true) && Assassin.BBuilder == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVent = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(140f / 255f, 80f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;
                     }
                     else if (Sentinel.Role != null && Sentinel.Role == Assassin.currentTarget && Assassin.BSentinel == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVision = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (CopyCat.Role != null && CopyCat.Role == Assassin.currentTarget && (CopyCat.copyRole == 17) && (CopyCat.CopyStart == true) && Assassin.BSentinel == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.StealVision = true;
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return; ;
                     }

                     else if (Fake.Role != null && Fake.Role == Assassin.currentTarget && Assassin.BImpo == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = (AssassinKillButtonMaxTimer / 2);
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else if (Assassin.currentTarget.Data.Role.IsImpostor && Assassin.BImpo == true && !AbilityDisabled)
                     {
                         //KILL
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = (AssassinKillButtonMaxTimer / 2);
                         ChallengerMod.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 0f / 255f), 0.5f);
                         Assassin.currentTarget = null;
                         return;

                     }
                     else
                     {
                         //KILL Normal
                         targetId = Assassin.currentTarget.PlayerId;
                         MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinKill, Hazel.SendOption.Reliable, -1);
                         messageWriter.Write(targetId);
                         AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                         RPCProcedure.assassinKill(targetId);
                         AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                         Assassin.currentTarget = null;
                         return;
                     }


                 }


             },
             () => { return Assassin.Role != null && Assassin.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
             () => {
                 if (AbilityDisabled)
                 {
                     AssassinKillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.RedColor);
                     AssassinKillButton.actionButton.OverrideText(BTT_Role_Kill);

                     if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                     {
                         AssassinKillButton.Sprite = IkillIco2;
                     }
                     else
                     {
                         AssassinKillButton.Sprite = IkillIco;
                     }

                 }
                 else
                 {
                     AssassinKillButton.actionButton.buttonLabelText.SetOutlineColor(ChallengerMod.ColorTable.AssassinColor);
                     AssassinKillButton.actionButton.OverrideText(BTT_Role_Kill);

                     if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                     {
                         AssassinKillButton.Sprite = KillAssassinIco2;
                     }
                     else
                     {
                         AssassinKillButton.Sprite = KillAssassinIco;
                     }

                 }
                 return Assassin.currentTarget && PlayerControl.LocalPlayer.CanMove;
             },
             () => {
                 if (StartTimer == false)
                 {
                     AssassinKillButton.Timer = 15f;
                 }
                 else
                 {
                     AssassinKillButton.Timer = AssassinKillButtonMaxTimer;
                 }
             },
             KillAssassinIco,
             new Vector3(0f, 1f, 0),
             __instance,
             ChallengerMod.Challenger.KeycodeKill

         );


            // Impostor Kill
            Impostor1KillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Impostor1.Role, Impostor1.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        Impostor1KillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            Impostor1KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor1.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Impostor1Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.impostor1Kill(targetId);
                            Impostor1KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor1.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            Impostor1KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor1.currentTarget = null;
                            return;
                        }
                        else
                        {
                            Impostor1KillButton.Timer = 0f;
                            Impostor1.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Impostor1.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                       || (Impostor1.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                       || ((Fake.Role == Impostor1.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                       || ((Assassin.Role == Impostor1.currentTarget) && Assassin.Shielded == true)
                            )
                        {
                            Impostor1KillButton.Timer = 0f;
                            return;
                        }
                        else
                        {

                            //KILL
                            targetId = Impostor1.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Impostor1Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.impostor1Kill(targetId);
                            Impostor1KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor1.currentTarget = null;
                            return;
                        }
                    }


                },
                () => { return Impostor1.Role != null && Impostor1.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    Impostor1KillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        Impostor1KillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        Impostor1KillButton.Sprite = IkillIco;
                    }

                    return Impostor1.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        Impostor1KillButton.Timer = 15f;
                    }
                    else
                    {
                        Impostor1KillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );


            // Impostor Kill
            Impostor2KillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Impostor2.Role, Impostor2.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        Impostor2KillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            Impostor2KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor2.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Impostor2Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.impostor2Kill(targetId);
                            Impostor2KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor2.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            Impostor2KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor2.currentTarget = null;
                            return;
                        }
                        else
                        {
                            Impostor2KillButton.Timer = 0f;
                            Impostor2.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Impostor2.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                       || (Impostor2.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                       || ((Fake.Role == Impostor2.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                       || ((Assassin.Role == Impostor2.currentTarget) && Assassin.Shielded == true)
                            )
                        {
                            Impostor2KillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Impostor2.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Impostor2Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.impostor2Kill(targetId);
                            Impostor2KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor2.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Impostor2.Role != null && Impostor2.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    Impostor2KillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        Impostor2KillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        Impostor2KillButton.Sprite = IkillIco;
                    }

                    return Impostor2.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        Impostor2KillButton.Timer = 15f;
                    }
                    else
                    {
                        Impostor2KillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );



            // Impostor Kill
            Impostor3KillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Impostor3.Role, Impostor3.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        Impostor3KillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            Impostor3KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor3.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Impostor3Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.impostor3Kill(targetId);
                            Impostor3KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor3.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            Impostor3KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor3.currentTarget = null;
                            return;
                        }
                        else
                        {
                            Impostor3KillButton.Timer = 0f;
                            Impostor3.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Impostor3.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                       || (Impostor3.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                       || ((Fake.Role == Impostor3.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                       || ((Assassin.Role == Impostor3.currentTarget) && Assassin.Shielded == true)
                            )
                        {
                            Impostor3KillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Impostor3.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Impostor3Kill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.impostor3Kill(targetId);
                            Impostor3KillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Impostor3.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Impostor3.Role != null && Impostor3.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    Impostor3KillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        Impostor3KillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        Impostor3KillButton.Sprite = IkillIco;
                    }

                    return Impostor3.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        Impostor3KillButton.Timer = 15f;
                    }
                    else
                    {
                        Impostor3KillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );




            // Morphling Kill
            MorphlingKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Morphling.Role, Morphling.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        MorphlingKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            MorphlingKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Morphling.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MorphlingKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.morphlingKill(targetId);
                            MorphlingKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Morphling.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            MorphlingKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Morphling.currentTarget = null;
                            return;
                        }
                        else
                        {
                            MorphlingKillButton.Timer = 0f;
                            Morphling.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Morphling.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Morphling.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Morphling.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Morphling.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            MorphlingKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Morphling.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MorphlingKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.morphlingKill(targetId);
                            MorphlingKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Morphling.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Morphling.Role != null && Morphling.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    MorphlingKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        MorphlingKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        MorphlingKillButton.Sprite = IkillIco;
                    }

                    return Morphling.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        MorphlingKillButton.Timer = 15f;
                    }
                    else
                    {
                        MorphlingKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // Scrambler Kill
            ScramblerKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Scrambler.Role, Scrambler.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        ScramblerKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            ScramblerKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Scrambler.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ScramblerKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.scramblerKill(targetId);
                            ScramblerKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Scrambler.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            ScramblerKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Scrambler.currentTarget = null;
                            return;
                        }
                        else
                        {
                            ScramblerKillButton.Timer = 0f;
                            Scrambler.currentTarget = null;
                            return;

                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Scrambler.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Scrambler.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Scrambler.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Scrambler.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            ScramblerKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Scrambler.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ScramblerKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.scramblerKill(targetId);
                            ScramblerKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Scrambler.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Scrambler.Role != null && Scrambler.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    ScramblerKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        ScramblerKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        ScramblerKillButton.Sprite = IkillIco;
                    }

                    return Scrambler.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        ScramblerKillButton.Timer = 15f;
                    }
                    else
                    {
                        ScramblerKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // Barghest Kill
            BarghestKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Barghest.Role, Barghest.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        BarghestKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            BarghestKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Barghest.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.BarghestKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.barghestKill(targetId);
                            BarghestKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Barghest.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            BarghestKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Barghest.currentTarget = null;
                            return;
                        }
                        else
                        {
                            BarghestKillButton.Timer = 0f;
                            Barghest.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Barghest.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Barghest.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Barghest.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Barghest.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            BarghestKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Barghest.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.BarghestKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.barghestKill(targetId);
                            BarghestKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Barghest.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Barghest.Role != null && Barghest.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    BarghestKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        BarghestKillButton.Sprite = BarghestKillIco2;
                    }
                    else
                    {
                        BarghestKillButton.Sprite = BarghestKillIco;
                    }

                    return Barghest.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        BarghestKillButton.Timer = 15f;
                    }
                    else
                    {
                        BarghestKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                BarghestKillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // Ghost Kill
            GhostKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Ghost.Role, Ghost.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        GhostKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            GhostKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Ghost.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GhostKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.ghostKill(targetId);
                            GhostKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Ghost.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            GhostKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Ghost.currentTarget = null;
                            return;
                        }
                        else
                        {
                            GhostKillButton.Timer = 0f;
                            Ghost.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Ghost.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Ghost.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Ghost.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Ghost.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            GhostKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Ghost.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GhostKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.ghostKill(targetId);
                            GhostKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Ghost.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Ghost.Role != null && Ghost.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    GhostKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        GhostKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        GhostKillButton.Sprite = IkillIco;
                    }

                    return Ghost.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        GhostKillButton.Timer = 15f;
                    }
                    else
                    {
                        GhostKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // Sorcerer Kill
            SorcererKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Sorcerer.Role, Sorcerer.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        SorcererKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            SorcererKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Sorcerer.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SorcererKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sorcererKill(targetId);
                            SorcererKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Sorcerer.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            SorcererKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Sorcerer.currentTarget = null;
                            return;
                        }
                        else
                        {
                            SorcererKillButton.Timer = 0f;
                            Sorcerer.currentTarget = null;
                            return;
                        }

                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Sorcerer.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Sorcerer.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Sorcerer.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Sorcerer.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            SorcererKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Sorcerer.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SorcererKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.sorcererKill(targetId);
                            SorcererKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Sorcerer.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Sorcerer.Role != null && Sorcerer.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    SorcererKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        SorcererKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        SorcererKillButton.Sprite = IkillIco;
                    }

                    return Sorcerer.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        SorcererKillButton.Timer = 15f;
                    }
                    else
                    {
                        SorcererKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill
            );


            // Guesser Kill
            GuesserKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Guesser.Role, Guesser.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        GuesserKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            GuesserKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Guesser.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GuesserKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.guesserKill(targetId);
                            GuesserKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Guesser.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            GuesserKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Guesser.currentTarget = null;
                            return;
                        }
                        else
                        {
                            GuesserKillButton.Timer = 0f;
                            Guesser.currentTarget = null;
                            return;
                        }
                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Guesser.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Guesser.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Guesser.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Guesser.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            GuesserKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Guesser.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GuesserKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.guesserKill(targetId);
                            GuesserKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Guesser.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Guesser.Role != null && Guesser.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    GuesserKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        GuesserKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        GuesserKillButton.Sprite = IkillIco;
                    }

                    return Guesser.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        GuesserKillButton.Timer = 15f;
                    }
                    else
                    {
                        GuesserKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );
            // Basilisk Kill
            BasiliskKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(Basilisk.Role, Basilisk.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        BasiliskKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            BasiliskKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Basilisk.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.BasiliskKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.basiliskKill(targetId);
                            BasiliskKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Basilisk.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            BasiliskKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Basilisk.currentTarget = null;
                            return;
                        }
                        else
                        {
                            BasiliskKillButton.Timer = 0f;
                            Basilisk.currentTarget = null;
                            return;
                        }
                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((Basilisk.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (Basilisk.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == Basilisk.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == Basilisk.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            BasiliskKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = Basilisk.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.BasiliskKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.basiliskKill(targetId);
                            BasiliskKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            Basilisk.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return Basilisk.Role != null && Basilisk.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    BasiliskKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        BasiliskKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        BasiliskKillButton.Sprite = IkillIco;
                    }

                    return Basilisk.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        BasiliskKillButton.Timer = 15f;
                    }
                    else
                    {
                        BasiliskKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );

            // CopyCat Kill
            CopyCatKillButton = new CustomButton(
                () => {
                    MurderAttemptResult murderAttemptResult = Helpers.checkMurderAttempt(CopyCat.Role, CopyCat.currentTarget);
                    if (murderAttemptResult == MurderAttemptResult.SuppressKill)
                    {
                        CopyCatKillButton.Timer = 0f;
                        return;
                    }
                    else if (murderAttemptResult == MurderAttemptResult.Guardianshield) //GUARDIAN SHIELD
                    {
                        byte targetId = 0;
                        if (ShieldSettings.getSelection() == 0) //Guardian shield - Protected
                        {
                            CopyCatKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }
                        else //Guardian shield - Reflect
                        {
                            //SELF-KILL
                            targetId = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.copyCatKill(targetId);
                            CopyCatKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }

                    }
                    else if (murderAttemptResult == MurderAttemptResult.MysticShield)  // MYSTIC SHIELD
                    {
                        if (Mystic.DoubleShield)
                        {
                            CopyCatKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }
                        else
                        {
                            CopyCatKillButton.Timer = 0f;
                            CopyCat.currentTarget = null;
                            return;
                        }
                    }
                    if ((murderAttemptResult == MurderAttemptResult.PerformKill))
                    {
                        byte targetId = 0;

                        if ((CopyCat.currentTarget.Data.Role.IsImpostor && Fake.Role == null && !UnknowImpostors)
                        || (CopyCat.currentTarget.Data.Role.IsImpostor && Fake.Role != null && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Fake.Role == CopyCat.currentTarget) && !ImpostorCanKillOther && !UnknowImpostors)
                        || ((Assassin.Role == CopyCat.currentTarget) && Assassin.Shielded == true)
                             )
                        {
                            CopyCatKillButton.Timer = 0f;
                            return;
                        }
                        else
                        {
                            //KILL
                            targetId = CopyCat.currentTarget.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatKill, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(targetId);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.copyCatKill(targetId);
                            CopyCatKillButton.Timer = ImpostorsKillButtonMaxTimer;
                            CopyCat.currentTarget = null;
                            return;
                        }


                    }


                },
                () => { return CopyCat.Role != null && CopyCat.copyRole == 25 && CopyCat.CopyStart && CopyCat.Role == PlayerControl.LocalPlayer && !PlayerControl.LocalPlayer.Data.IsDead; },
                () => {
                    CopyCatKillButton.actionButton.OverrideText(BTT_Role_Kill);

                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C")
                    {
                        CopyCatKillButton.Sprite = IkillIco2;
                    }
                    else
                    {
                        CopyCatKillButton.Sprite = IkillIco;
                    }

                    return CopyCat.currentTarget && PlayerControl.LocalPlayer.CanMove;
                },
                () => {

                    if (StartTimer == false)
                    {
                        CopyCatKillButton.Timer = 15f;
                    }
                    else
                    {
                        CopyCatKillButton.Timer = ImpostorsKillButtonMaxTimer;
                    }
                },
                IkillIco,
                new Vector3(0f, 1f, 0),
                __instance,
                ChallengerMod.Challenger.KeycodeKill

            );

            setCustomButtonCooldowns();
        }
    }
}