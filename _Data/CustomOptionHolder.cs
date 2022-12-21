using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using System.Reflection;
using System.Text;
using Types = ChallengerMod.Utils.Option.CustomOption.CustomOptionType;
using ChallengerMod.Utils.Option;
using static ChallengerMod.Set.Data;

namespace ChallengerMod.Utils.Option
{
    public class CustomOptionHolder
    {



        public static string[] rates = new string[] { cs(new Color(255f / 255f, 0, 0, 1f), "0%"), "5%", "10%", "15%", "20%", "25%", "30%", "35%", "40%", "45%", "50%", "55%", "60%", "65%", "70%", "75%", "80%", "85%", "90%", "95%", "100%" };
        public static string[] ratesModifier = new string[] { "1", "2", "3" };
        public static string[] presets = new string[] { cs(ChallengerMod.ColorTable.GuardianColor, "<Preset 1> "), cs(ChallengerMod.ColorTable.MercenaryColor, "<Preset 2> "), cs(ChallengerMod.ColorTable.RedColor, "<Preset 3> "), cs(ChallengerMod.ColorTable.SheriffColor, "<Preset 4> "), cs(ChallengerMod.ColorTable.HunterColor, "<Preset 5> ") };
        public static string[] TXT = new string[] { "" };
        public static string[] addrole = new string[] { cs(new Color(255f / 255f, 0, 0, 1f), "No"), cs(new Color(0, 255f / 255f, 0, 1f), "Yes") };


        public static CustomOption presetSelection;
        public static CustomOption Ranked;
        public static CustomOption RankedInt;
        public static CustomOption HIDE_Sheriff;
        public static CustomOption HIDE_Map;


        //P1 - LOBBY
        // public static CustomOption Debugg;

        public static CustomOption ImpostorsKnowEachother;
        public static CustomOption BuzzCommon;
        
        public static CustomOption BetterMapPL;
        public static CustomOption BetterMapSK;
        public static CustomOption BetterMapHQ;

        public static CustomOption NuclearTimerMod;
        public static CustomOption NuclearTime1;
        public static CustomOption NuclearTime2;


        public static CustomOption BetterTaskWeapon;
        public static CustomOption BetterTaskWire;
      

        public static CustomOption ReactorSabotageShaking;
        public static CustomOption NoOxySabotage;
        public static CustomOption CommsSabotageAnonymous;
        

        public static CustomOption DisabledAdmin;
        public static CustomOption DisabledVitales;
        public static CustomOption DisabledCamera;
        
        public static CustomOption AdminTimeOn;
        public static CustomOption VitalTimeOn;
        public static CustomOption CamTimeOn;
        

        public static CustomOption AdminTime;
        public static CustomOption VitalTime;
        public static CustomOption CamTime;
        


        // P2 - ROLES

        public static CustomOption QTCrew;
        public static CustomOption QTSpe;
        public static CustomOption QTDuo;
        public static CustomOption QTImp;
        
        

        public static CustomOption SherifAdd;
        public static CustomOption GuardianAdd;
        public static CustomOption engineerAdd;
        public static CustomOption TimeLordAdd;
        public static CustomOption HunterAdd;
        public static CustomOption MysticAdd;
        public static CustomOption SpiritAdd;
        public static CustomOption MayorAdd;
        public static CustomOption DetectiveAdd;
        public static CustomOption NightwatcherAdd;
        public static CustomOption SpyAdd;
        public static CustomOption InforAdd;
        public static CustomOption BaitAdd;
        public static CustomOption MentalistAdd;
        public static CustomOption BuilderAdd;
        public static CustomOption DictatorAdd;
        public static CustomOption SentinelAdd;
        public static CustomOption MateAdd;
        public static CustomOption LawkeeperAdd;
        public static CustomOption FakeAdd;

        public static CustomOption CupidAdd;
        public static CustomOption CultisteAdd;
        public static CustomOption JesterAdd;
        public static CustomOption EaterAdd;
        public static CustomOption OutlawAdd;
        public static CustomOption ArsonistAdd;
        public static CustomOption CursedAdd;

        public static CustomOption MercenaryAdd;
        public static CustomOption CopyCatAdd;
        public static CustomOption SorcererAdd;
        public static CustomOption RevengerAdd;

        public static CustomOption AssassinAdd;
        public static CustomOption VectorAdd;
        public static CustomOption MorphlingAdd;
        public static CustomOption CamoAdd;
        public static CustomOption BarghestAdd;
        public static CustomOption GhostAdd;
        public static CustomOption WarAdd;
        public static CustomOption GuesserAdd;
        public static CustomOption BasiliskAdd;












        //P3 - Crewmates













        public static CustomOption SherifSpawnChance;
        public static CustomOption Sherif2SpawnChance;
        public static CustomOption Sherif3SpawnChance;
        public static CustomOption SherifKillSettings;
        public static CustomOption SherifKillCooldown;
        public static CustomOption SherifKillRange;
        public static CustomOption SherifKillCulteMember;

        public static CustomOption GuardianSpawnChance;
        public static CustomOption ShieldSettings;
        public static CustomOption GuardianShieldVisibility;
        public static CustomOption GuardianShieldVisibilitytry;
        public static CustomOption GuardianShieldSound;

        public static CustomOption engineerSpawnChance;
        public static CustomOption EngineerCanVent;
        public static CustomOption EngineerRepairCD;
        public static CustomOption RepairSettings;

        public static CustomOption TimeLordSpawnChance;
        public static CustomOption TimeLordStopCooldown;
        public static CustomOption TimeLordStopDuration;

        public static CustomOption HunterSpawnChance;
        public static CustomOption ResetTrack;
        public static CustomOption Followtrack;

        public static CustomOption MysticSpawnChance;
        public static CustomOption MysticSetCooldown;
        public static CustomOption MysticSetDuration;

        public static CustomOption SpiritSpawnChance;
        public static CustomOption SpiritSab;

        public static CustomOption MayorSpawnChance;
        public static CustomOption BonusBuzz;
        public static CustomOption BuzzCooldown;

        public static CustomOption DetectiveSpawnChance;
        public static CustomOption detectiveFootprintcooldown;
        public static CustomOption detectiveFootprintDuration2;
        public static CustomOption detectiveFootprintDuration;
        public static CustomOption detectiveFootprintanonymous;

        public static CustomOption NightwatcherSpawnChance;
        public static CustomOption NightwatcherSetCooldown;
        public static CustomOption NightwatcherSetDuration;

        public static CustomOption SpySpawnChance;
        public static CustomOption SpyDuration;
        public static CustomOption SpyRange;
        

        public static CustomOption InforSpawnChance;
        public static CustomOption InforCooldown;
        public static CustomOption InforAnalyseMod;
        public static CustomOption InforAnalyseTeam;

        public static CustomOption BaitSpawnChance;
        public static CustomOption BaitReporttime;
        public static CustomOption BaitReporttimeRnd;
        public static CustomOption BaitCanVent;

        public static CustomOption MentalistSpawnChance;
        public static CustomOption MentalistAbility;
        public static CustomOption AdminSetting;
        public static CustomOption AdminDuration;

        public static CustomOption BuilderSpawnChance;
        public static CustomOption BuildRound;
        public static CustomOption MaxBuild;
        public static CustomOption BuildCooldown;

        public static CustomOption DictatorSpawnChance;
        public static CustomOption DictatorMeeting;
        public static CustomOption DictatorFirstTurn;

        public static CustomOption SentinelSpawnChance;
        public static CustomOption ScanCooldown;
        public static CustomOption ScanDuration;
        public static CustomOption ScanAbility;

        public static CustomOption MateSpawnChance;

        public static CustomOption LawkeeperSpawnChance;
        public static CustomOption LKTimer;
        public static CustomOption TimeRName;
        public static CustomOption TimeRList;
        public static CustomOption LKInfo;
        public static CustomOption SuperInfo;



        public static CustomOption FakeSpawnChance;
        public static CustomOption ImpostorCanKillFake;
        public static CustomOption FakeCanVent;




        //P4 - Hybrid / Sprécial



        public static CustomOption CupidSpawnChance;
        public static CustomOption Loverdie;

        public static CustomOption CultisteSpawnChance;
        public static CustomOption CultisteCooldown;
        public static CustomOption CulteMember;
        public static CustomOption Cultistdie;

        public static CustomOption JesterSpawnChance;
        public static CustomOption JesterCooldown;
        public static CustomOption JesterSingle;

        public static CustomOption EaterSpawnChance;
        public static CustomOption EaterCooldown;
        public static CustomOption Eaterduration;
        public static CustomOption Eatvalueforwin;
        public static CustomOption EaterCanVent;
        public static CustomOption EaterCanDrag;
        public static CustomOption BodyRemove;

        public static CustomOption OutlawSpawnChance;
        public static CustomOption OutlawKillCooldown;
        public static CustomOption OutlawKillRange;

        public static CustomOption ArsonistSpawnChance;
        public static CustomOption ArsonistFuelQT;
        public static CustomOption ArsonistCooldown;
        public static CustomOption ArsonistDuration;
        public static CustomOption ArsonistFailDuration;
        public static CustomOption AutoRefuel;


        public static CustomOption CursedSpawnChance;
        public static CustomOption CursedTimer;
        public static CustomOption CursedAbility;
        public static CustomOption CursedCooldown;
        public static CustomOption CursedDuration;
        public static CustomOption CursedSpeedModifieur;

        


        public static CustomOption MercenarySpawnChance;
        public static CustomOption MercenaryKillCooldown;
        public static CustomOption MercenaryCanVent;

        public static CustomOption CopyCatSpawnChance;
        public static CustomOption CopyImp;
        public static CustomOption CopySpe;

        public static CustomOption SorcererSpawnChance;
        public static CustomOption SurvivorWinJester;
        public static CustomOption SurvivorWinEater;
        public static CustomOption SurvivorWinOutlaw;
        public static CustomOption SurvivorWinArsonist;
        public static CustomOption SurvivorWinCulte;
        public static CustomOption SurvivorWinCursed;

        public static CustomOption RevengerSpawnChance;
        public static CustomOption QtVenger;
        public static CustomOption VengerCooldown;
        public static CustomOption VengerKill;
        public static CustomOption VengerExil;




        //P5 Impostor
        public static CustomOption AssassinSpawnChance;
        public static CustomOption AssassinKillCooldown;
        public static CustomOption AssassinCanKillShield;
        public static CustomOption BSheriff;
        public static CustomOption BGuardian;
        public static CustomOption BEngineer;
        public static CustomOption BTimelord;
        public static CustomOption BMystic;
        public static CustomOption BMayor;
        public static CustomOption BDetective;
        public static CustomOption BNightwatcher;
        public static CustomOption BSpy;
        public static CustomOption BInfor;
        public static CustomOption BMentalist;
        public static CustomOption BBuilder;
        public static CustomOption BDictator;
        public static CustomOption BSentinel;
        public static CustomOption BLawkeeper;
        public static CustomOption BImpo;

        public static CustomOption VectorSpawnChance;
        public static CustomOption VectorBuffCooldown;
        public static CustomOption VectorKillCooldown;
        public static CustomOption VectorBuffVisibility;
        public static CustomOption VectorCanVent;

        public static CustomOption MorphlingSpawnChance;
        public static CustomOption MorphSetCooldown;
        public static CustomOption MorphSetDuration;
        public static CustomOption MorphlingCanVent;

        public static CustomOption CamoSpawnChance;
        public static CustomOption CamoSetCooldown;
        public static CustomOption CamoSetDuration;
        public static CustomOption CamoCanVent;


        public static CustomOption BarghestSpawnChance;
        public static CustomOption BargestLightCooldown;
        public static CustomOption BargestLightDuration;
        public static CustomOption BarghestAffectImpostor;
        public static CustomOption BarghestCamlight;
        public static CustomOption BarghestCanCreateVent;
        public static CustomOption BarghestVentCD;
        public static CustomOption BarghestCanVent;
        public static CustomOption CanUseBarghestVent;


        public static CustomOption GhostSpawnChance;
        public static CustomOption HideSetCooldown;
        public static CustomOption HideSetDuration;
        public static CustomOption GhostCanVent;


        public static CustomOption WarSpawnChance;
        public static CustomOption WarCooldown;
        public static CustomOption War1;
        public static CustomOption War2;
        public static CustomOption War3;
        public static CustomOption War4;
        public static CustomOption WarCanVent;

        public static CustomOption GuesserSpawnChance;
        public static CustomOption Gestry;
        public static CustomOption GuessTryOne;
        public static CustomOption GuessDie;
        public static CustomOption GuessCanVent;
        public static CustomOption GuessMystic;
        public static CustomOption GuessSpirit;
        public static CustomOption GuessFake;

        public static CustomOption BasiliskSpawnChance;
        public static CustomOption BasiliskCooldown;
        public static CustomOption BasiliskStart;
        public static CustomOption BasiliskKill;
        public static CustomOption BasiliskMeet;
        public static CustomOption BasiliskVote;
        public static CustomOption BasiliskParalizeCost;
        public static CustomOption BasiliskPetrifyCost;
        
            


        public static CustomOption BasiliskSinglePetrify;
        public static CustomOption BasiliskCanVent;






        public static CustomOption ROLE_spawn;
        public static CustomOption ROLE_name;
        public static CustomOption TEST_cd;
        public static CustomOption TEST_str;
        public static CustomOption TEST_yn; 


        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s)
        {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }

        private static byte ToByte(float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static void Load()
        {
            //P1
            presetSelection = CustomOption.Create(0, Types.P6, cs(ChallengerMod.ColorTable.EaterColor, "PRESET"), presets, null, true);
            Ranked = CustomOption.Create(900, Types.P6, "RANKED", false);
            RankedInt = CustomOption.Create(902, Types.P6, "> INT", 0f, 0f, 100f, 1f, Ranked);
            HIDE_Map = CustomOption.Create(903, Types.P6, "HM", false);
            HIDE_Sheriff = CustomOption.Create(904, Types.P6, "HR", false);



            // Debugg = CustomOption.Create(901, Types.P1, cs(ChallengerMod.ColorTable.RedColor, "(DEBUGG) ") + " -", new string[] { cs(ChallengerMod.ColorTable.WhiteColor, "Disables"), cs(ChallengerMod.ColorTable.YellowColor, "Enabled") }, null, true);


            BuzzCommon = CustomOption.Create(2, Types.P1, cs(ChallengerMod.ColorTable.MercenaryColor, "(GameMod) ") + "Common Emergency", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") }, null, true);
            ImpostorsKnowEachother = CustomOption.Create(1, Types.P1, cs(ChallengerMod.ColorTable.MercenaryColor, "(GameMod) ") + "Unknown Impostors", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") }, null);

            BetterMapPL = CustomOption.Create(3, Types.P1, cs(ChallengerMod.ColorTable.GuardianColor, "(Map) ") + "Polus Version    ", new string[] { "Normal", cs(ChallengerMod.ColorTable.MentalistColor, "Better Polus") + cs(ChallengerMod.ColorTable.NightwatchColor, "\nBy Brybry"), cs(ChallengerMod.ColorTable.EaterColor, "Challenger Polus") + cs(ChallengerMod.ColorTable.StelliaColor, "\nBy Lunastellia") }, null, true);
            BetterMapSK = CustomOption.Create(4, Types.P1, cs(ChallengerMod.ColorTable.GuardianColor, "(Map) ") + "The Skeld Version", new string[] { "Normal", cs(ChallengerMod.ColorTable.EaterColor, "Challenger Skeld") + cs(ChallengerMod.ColorTable.StelliaColor, "\nBy Lunastellia") }, null);
            BetterMapHQ = CustomOption.Create(5, Types.P1, cs(ChallengerMod.ColorTable.GuardianColor, "(Map) ") + "Mira HQ Version", new string[] { "Normal", cs(ChallengerMod.ColorTable.EaterColor, "Challenger Mira") + cs(ChallengerMod.ColorTable.StelliaColor, "\nBy Lunastellia") }, null);

            NuclearTimerMod = CustomOption.Create(7, Types.P1, "> Nuclear Polus Mod", true, HIDE_Map);
            NuclearTime1 = CustomOption.Create(8, Types.P1, "> Nuclear Timer", 300f, 120f, 600f, 10f, NuclearTimerMod);
            NuclearTime2 = CustomOption.Create(9, Types.P1, "> Emergency Timer", 10f, 5f, 30f, 1f, NuclearTimerMod);

            BetterTaskWeapon = CustomOption.Create(10, Types.P1, cs(ChallengerMod.ColorTable.SheriffColor, "(Task) ") + "Weapon smaller asteroid", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") }, null, true);
            BetterTaskWire = CustomOption.Create(11, Types.P6, cs(ChallengerMod.ColorTable.SheriffColor, "(Task) ") + "More Eletric Wires (x8)", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") }, null);

            ReactorSabotageShaking = CustomOption.Create(31, Types.P6, cs(ChallengerMod.ColorTable.DictatorColor, "(Sabotage) ") + "Reactor Shaking Screen", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled/Fix") }, null, true);
            NoOxySabotage = CustomOption.Create(32, Types.P6, cs(ChallengerMod.ColorTable.DictatorColor, "(Sabotage) ") + "Oxygen fainting Effect", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") }, null);
            CommsSabotageAnonymous = CustomOption.Create(33, Types.P1, cs(ChallengerMod.ColorTable.DictatorColor, "(Sabotage) ") + "Coms Unknown Player", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") }, null, true);

            DisabledAdmin = CustomOption.Create(40, Types.P1, cs(ChallengerMod.ColorTable.SentinelColor, "(Survey) ") + "Admin Table Available", new string[] { cs(ChallengerMod.ColorTable.TrackedColor, "Yes"), cs(ChallengerMod.ColorTable.BuffedColor, "Never"), cs(ChallengerMod.ColorTable.SheriffColor, "Only for") + cs(ChallengerMod.ColorTable.CrewColor, "\nCrewmate"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n1 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n2 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n2 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n4 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n5 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n6 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n7 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n8 Player die"), }, null, true);
            DisabledVitales = CustomOption.Create(41, Types.P1, cs(ChallengerMod.ColorTable.SentinelColor, "(Survey) ") + "Vitales Available", new string[] { cs(ChallengerMod.ColorTable.TrackedColor, "Yes"), cs(ChallengerMod.ColorTable.BuffedColor, "Never"), cs(ChallengerMod.ColorTable.SheriffColor, "Only for") + cs(ChallengerMod.ColorTable.CrewColor, "\nCrewmate"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n1 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n2 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n2 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n4 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n5 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n6 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n7 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n8 Player die"), }, null);
            DisabledCamera = CustomOption.Create(42, Types.P1, cs(ChallengerMod.ColorTable.SentinelColor, "(Survey) ") + "Camera Available", new string[] { cs(ChallengerMod.ColorTable.TrackedColor, "Yes"), cs(ChallengerMod.ColorTable.BuffedColor, "Never"), cs(ChallengerMod.ColorTable.SheriffColor, "Only for") + cs(ChallengerMod.ColorTable.CrewColor, "\nCrewmate"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n1 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n2 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n2 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n4 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n5 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n6 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n7 Player die"), cs(ChallengerMod.ColorTable.JesterColor, "Only if") + cs(ChallengerMod.ColorTable.BuffedColor, "\n8 Player die"), }, null);

            AdminTimeOn = CustomOption.Create(43, Types.P1, cs(ChallengerMod.ColorTable.SentinelColor, "(Utility) ") + "Admin Limited time", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") + cs(ChallengerMod.ColorTable.LovedColor, "\n(Single)"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") + cs(ChallengerMod.ColorTable.LovedColor, "\n(Round)") }, null);
            AdminTime = CustomOption.Create(44, Types.P1, "> Timer", 30f, 1f, 60f, 1f, AdminTimeOn);

            VitalTimeOn = CustomOption.Create(45, Types.P1, cs(ChallengerMod.ColorTable.SentinelColor, "(Utility) ") + "Vital Limited time", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") + cs(ChallengerMod.ColorTable.LovedColor, "\n(Single)"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") + cs(ChallengerMod.ColorTable.LovedColor, "\n(Round)") }, null);
            VitalTime = CustomOption.Create(46, Types.P1, "> Timer", 30f, 1f, 60f, 1f, VitalTimeOn);

            CamTimeOn = CustomOption.Create(47, Types.P1, cs(ChallengerMod.ColorTable.SentinelColor, "(Utility) ") + "Camera Limited time", new string[] { cs(ChallengerMod.ColorTable.BuffedColor, "Disables"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") + cs(ChallengerMod.ColorTable.LovedColor, "\n(Single)"), cs(ChallengerMod.ColorTable.TrackedColor, "Enabled") + cs(ChallengerMod.ColorTable.LovedColor, "\n(Round)") }, null);
            CamTime = CustomOption.Create(48, Types.P1, "> Timer", 30f, 1f, 60f, 1f, CamTimeOn);


            
            
         

         
         
         
        

        

        //P2

        /*

        TAGS LEGEND

        ▼  Killer
        ✚ support
        ◉ Protector
        ★ Investigator
        ❖ Special

         */


            QTCrew = CustomOption.Create(50, Types.P2, cs(ChallengerMod.ColorTable.TimeLordColor, "CREWMATE ROLE QUANTITY"), 0f, 0f, 14f, 1f, null, true);
            SherifAdd = CustomOption.Create(54, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.SheriffColor, "Sheriff"), addrole, QTCrew);
            GuardianAdd = CustomOption.Create(55, Types.P2, cs(ChallengerMod.ColorTable._DefensiveColor, "◉ ") + cs(ChallengerMod.ColorTable.GuardianColor, "Guardian"), addrole, QTCrew);
            engineerAdd = CustomOption.Create(56, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.EngineerColor, "Engineer"), addrole, QTCrew);
            TimeLordAdd = CustomOption.Create(57, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.TimeLordColor, "TimeLord"), addrole, QTCrew);
            HunterAdd = CustomOption.Create(58, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.HunterColor, "Hunter"), addrole, QTCrew);
            MysticAdd = CustomOption.Create(59, Types.P2, cs(ChallengerMod.ColorTable._DefensiveColor, "◉ ") + cs(ChallengerMod.ColorTable.MysticColor, "Mystic"), addrole, QTCrew);
            SpiritAdd = CustomOption.Create(60, Types.P2, cs(ChallengerMod.ColorTable._DefensiveColor, "◉ ") + cs(ChallengerMod.ColorTable.SpiritColor, "Spirit"), addrole, QTCrew);
            MayorAdd = CustomOption.Create(61, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.MayorColor, "Mayor"), addrole, QTCrew);
            DetectiveAdd = CustomOption.Create(62, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.DetectiveColor, "Detective"), addrole, QTCrew);
            NightwatcherAdd = CustomOption.Create(63, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.NightwatchColor, "Nightwatch"), addrole, QTCrew);
            SpyAdd = CustomOption.Create(64, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.SpyColor, "Spy"), addrole, QTCrew);
            InforAdd = CustomOption.Create(65, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.InformantColor, "Informant"), addrole, QTCrew);
            BaitAdd = CustomOption.Create(66, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.BaitColor, "Bait"), addrole, QTCrew);
            MentalistAdd = CustomOption.Create(67, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.MentalistColor, "Mentalist"), addrole, QTCrew);
            BuilderAdd = CustomOption.Create(68, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.BuilderColor, "Builder"), addrole, QTCrew);
            DictatorAdd = CustomOption.Create(69, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.DictatorColor, "Dictator"), addrole, QTCrew);
            SentinelAdd = CustomOption.Create(70, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.SentinelColor, "Sentinel"), addrole, QTCrew);
            MateAdd = CustomOption.Create(71, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.CrewColor, "Teammate"), addrole, QTCrew);
            LawkeeperAdd = CustomOption.Create(72, Types.P2, cs(ChallengerMod.ColorTable._InvestigatorColor, "★ ") + cs(ChallengerMod.ColorTable.LawkeeperColor, "Lawkeeper"), addrole, QTCrew);
            FakeAdd = CustomOption.Create(73, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.FakeColor, "Fake"), addrole, QTCrew);

            QTSpe = CustomOption.Create(51, Types.P2, cs(ChallengerMod.ColorTable.LovedColor, "SPECIAL ROLE QUANTITY"), 0f, 0f, 6f, 1f, null, true);
            CupidAdd = CustomOption.Create(90, Types.P2, cs(ChallengerMod.ColorTable.CupidColor, "♥ ") + cs(ChallengerMod.ColorTable.CupidColor, "Cupid"), addrole, QTSpe);
            CultisteAdd = CustomOption.Create(91, Types.P2, cs(ChallengerMod.ColorTable.CulteColor, "φ ") + cs(ChallengerMod.ColorTable.CulteColor, "Cultist"), addrole, QTSpe);
            JesterAdd = CustomOption.Create(92, Types.P2, cs(ChallengerMod.ColorTable.JesterColor, "❖ ") + cs(ChallengerMod.ColorTable.JesterColor, "Jester"), addrole, QTSpe);
            EaterAdd = CustomOption.Create(93, Types.P2, cs(ChallengerMod.ColorTable.EaterColor, "❖ ") + cs(ChallengerMod.ColorTable.EaterColor, "Eater"), addrole, QTSpe);
            OutlawAdd = CustomOption.Create(94, Types.P2, cs(ChallengerMod.ColorTable.OutlawColor, "❖ ") + cs(ChallengerMod.ColorTable.OutlawColor, "Outlaw"), addrole, QTSpe);
            ArsonistAdd = CustomOption.Create(95, Types.P2, cs(ChallengerMod.ColorTable.ArsonistColor, "❖ ") + cs(ChallengerMod.ColorTable.ArsonistColor, "Arsonist"), addrole, QTSpe);
            CursedAdd = CustomOption.Create(96, Types.P2, cs(ChallengerMod.ColorTable.CursedColor, "❖ ") + cs(ChallengerMod.ColorTable.CursedColor, "Cursed"), addrole, QTSpe);

            QTDuo = CustomOption.Create(52, Types.P2, cs(ChallengerMod.ColorTable.DuoColor, "HYBRID ROLE QUANTITY"), 0f, 0f, 4f, 1f, null, true);
           
            MercenaryAdd = CustomOption.Create(110, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.MercenaryColor, "Mercenary"), addrole, QTDuo);
            CopyCatAdd = CustomOption.Create(111, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.CopyCatColor, "CopyCat"), addrole, QTDuo);
            SorcererAdd = CustomOption.Create(112, Types.P2, cs(ChallengerMod.ColorTable.SurvivorColor, "❖ ") + cs(ChallengerMod.ColorTable.SurvivorColor, "Survivor"), addrole, QTDuo);
            RevengerAdd = CustomOption.Create(113, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.RevengerColor, "Revenger"), addrole, QTDuo);

            QTImp = CustomOption.Create(53, Types.P2, cs(ChallengerMod.ColorTable.RedColor, "IMPOSTOR ROLE QUANTITY"), 0f, 0f, 3f, 1f, null, true);
            AssassinAdd = CustomOption.Create(120, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.AssassinColor, "Assassin"), addrole, QTImp);
            VectorAdd = CustomOption.Create(121, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.VectorColor, "Vector"), addrole, QTImp);
            MorphlingAdd = CustomOption.Create(122, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.MorphlingColor, "Morphling"), addrole, QTImp);
            CamoAdd = CustomOption.Create(123, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.ScramblerColor, "Scrambler"), addrole, QTImp);
            BarghestAdd = CustomOption.Create(124, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.BarghestColor, "Barghest"), addrole, QTImp);
            GhostAdd = CustomOption.Create(125, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.GhostColor, "Ghost"), addrole, QTImp);
            WarAdd = CustomOption.Create(126, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.SorcererColor, "Sorcerer"), addrole, QTImp);
            GuesserAdd = CustomOption.Create(127, Types.P2, cs(ChallengerMod.ColorTable._KillerColor, "▼ ") + cs(ChallengerMod.ColorTable.GuesserColor, "Guesser"), addrole, QTImp);
            BasiliskAdd = CustomOption.Create(129, Types.P2, cs(ChallengerMod.ColorTable._SupportColor, "✚ ") + cs(ChallengerMod.ColorTable.BasiliskColor, "Basilisk"), addrole, QTImp);


            //P3

            SherifSpawnChance = CustomOption.Create(200, Types.P3, cs(ChallengerMod.ColorTable.SheriffColor, "Sheriff Spawn Chance"), 100f, 0f, 100f, 5f, SherifAdd, true);
            Sherif2SpawnChance = CustomOption.Create(201, Types.P3, cs(ChallengerMod.ColorTable.SheriffColor, "Sheriff II Spawn Chance"), 0f, 0f, 100f, 5f, SherifAdd);
            Sherif3SpawnChance = CustomOption.Create(202, Types.P3, cs(ChallengerMod.ColorTable.SheriffColor, "Sheriff III Spawn Chance"), 0f, 0f, 100f, 5f, SherifAdd);
            SherifKillSettings = CustomOption.Create(203, Types.P3, "> Kill Setting", new string[] { "Ability Enable", "Disabled at\nFirst Round", "Drop Gun" }, HIDE_Sheriff);
            SherifKillCooldown = CustomOption.Create(204, Types.P3, "> Kill Cooldown", 30f, 10f, 60f, 2.5f, HIDE_Sheriff);
            SherifKillRange = CustomOption.Create(205, Types.P3, "> Kill Range", new string[] { "100%", "120%" }, HIDE_Sheriff);
            SherifKillCulteMember = CustomOption.Create(206, Types.P3, "> Can Kill Cult Members", true, HIDE_Sheriff);
             
            GuardianSpawnChance = CustomOption.Create(210, Types.P3, cs(ChallengerMod.ColorTable.GuardianColor, "Guardian Spawn Chance"), 100f, 0f, 100f, 5f, GuardianAdd, true);
            ShieldSettings = CustomOption.Create(211, Types.P3, "> Shield Setting", new string[] { "Protected", "Reflect" }, GuardianAdd);
            GuardianShieldVisibility = CustomOption.Create(212, Types.P3, "> Protected Player Can See Shield", false, GuardianAdd);
            GuardianShieldVisibilitytry = CustomOption.Create(213, Types.P3, "> Shield Visibility after try kill", new string[] { "Everyone", "Shielded \nPlayer", "Nobody" }, GuardianAdd);
            GuardianShieldSound = CustomOption.Create(214, Types.P3, "> PlaySound When try to kill", true, GuardianAdd);

            engineerSpawnChance = CustomOption.Create(220, Types.P3, cs(ChallengerMod.ColorTable.EngineerColor, "Engineer Spawn Chance"), 100f, 0f, 100f, 5f, engineerAdd, true);
            EngineerCanVent = CustomOption.Create(221, Types.P3, "> Can Use Vent", true, engineerAdd);
            EngineerRepairCD = CustomOption.Create(222, Types.P3, "> Repair Cooldown", 30f, 10f, 60f, 2.5f, engineerAdd);
            RepairSettings = CustomOption.Create(223, Types.P3, "> Repair Settings", new string[] { "Single Use", "Can be used\nonce per turn" }, engineerAdd);
          
            TimeLordSpawnChance = CustomOption.Create(230, Types.P3, cs(ChallengerMod.ColorTable.TimeLordColor, "TimeLord Spawn Chance"), 100f, 0f, 100f, 5f, TimeLordAdd, true);
            TimeLordStopCooldown = CustomOption.Create(231, Types.P3, "> Break Time Cooldown", 40f, 10f, 180f, 2.5f, TimeLordAdd);
            TimeLordStopDuration = CustomOption.Create(232, Types.P3, "> Break Time Duration", 7f, 1f, 20f, 1f, TimeLordAdd);

            HunterSpawnChance = CustomOption.Create(240, Types.P3, cs(ChallengerMod.ColorTable.HunterColor, "Hunter Spawn Chance"), 100f, 0f, 100f, 5f, HunterAdd, true);
            ResetTrack = CustomOption.Create(241, Types.P3, "> Can reuse Track", true, HunterAdd);
            Followtrack = CustomOption.Create(242, Types.P3, "> Follow tracked player", true, HunterAdd);
            
            MysticSpawnChance = CustomOption.Create(250, Types.P3, cs(ChallengerMod.ColorTable.MysticColor, "Mystic Spawn Chance"), 100f, 0f, 100f, 5f, MysticAdd, true);
            MysticSetCooldown = CustomOption.Create(251, Types.P3, "> Self Protect Cooldown", 30f, 10f, 180f, 2.5f, MysticAdd);
            MysticSetDuration = CustomOption.Create(252, Types.P3, "> Self Protect Duration", 10f, 1f, 20f, 1f, MysticAdd);
            
            SpiritSpawnChance = CustomOption.Create(260, Types.P3, cs(ChallengerMod.ColorTable.SpiritColor, "Spirit Spawn Chance"), 100f, 0f, 100f, 5f, SpiritAdd, true);
            SpiritSab = CustomOption.Create(261, Types.P3, "> Can Use Door Sabotage if die", false, SpiritAdd);

            MayorSpawnChance = CustomOption.Create(270, Types.P3, cs(ChallengerMod.ColorTable.MayorColor, "Mayor Spawn Chance"), 100f, 0f, 100f, 5f, MayorAdd, true);
            BonusBuzz = CustomOption.Create(271, Types.P3, "> Buzz Bonus available", new string[] { "Disabled", "Enabled", "When all tasks\nare completed" }, MayorAdd);
            BuzzCooldown = CustomOption.Create(272, Types.P3, "> Buzz Bonus Cooldown", 15f, 5f, 60f, 2.5f, MayorAdd);

            DetectiveSpawnChance = CustomOption.Create(280, Types.P3, cs(ChallengerMod.ColorTable.DetectiveColor, "Detective Spawn Chance"), 100f, 0f, 100f, 5f, DetectiveAdd, true);
            detectiveFootprintcooldown = CustomOption.Create(281, Types.P3, "> Detection Cooldown", 30f, 10f, 60f, 2.5f, DetectiveAdd);
            detectiveFootprintDuration2 = CustomOption.Create(282, Types.P3, "> Detection Duration", 15f, 5f, 30f, 1f, DetectiveAdd);
            detectiveFootprintDuration = CustomOption.Create(283, Types.P3, "> Mark persistence duration", 10f, 1f, 30f, 1f, DetectiveAdd);
            detectiveFootprintanonymous = CustomOption.Create(284, Types.P3, "> Anonymous Mark", false, DetectiveAdd);
            
            NightwatcherSpawnChance = CustomOption.Create(290, Types.P3, cs(ChallengerMod.ColorTable.NightwatchColor, "Nighwatch Spawn Chance"), 100f, 0f, 100f, 5f, NightwatcherAdd, true);
            NightwatcherSetCooldown = CustomOption.Create(291, Types.P3, "> Power of Light Cooldown", 30f, 10f, 60f, 2.5f, NightwatcherAdd);
            NightwatcherSetDuration = CustomOption.Create(292, Types.P3, "> Power of Light Duration", 8f, 1f, 20f, 1f, NightwatcherAdd);

            SpySpawnChance = CustomOption.Create(300, Types.P3, cs(ChallengerMod.ColorTable.SpyColor, "Spy Spawn Chance"), 100f, 0f, 100f, 5f, SpyAdd, true);
            SpyDuration = CustomOption.Create(301, Types.P3, "> Spy Ability Duration", 5f, 1f, 10f, 1f, SpyAdd);
            SpyRange = CustomOption.Create(302, Types.P3, "> Spy VIsion Range", new string[] { "100%", "125%", "150%" }, SpyAdd);


            InforSpawnChance = CustomOption.Create(310, Types.P3, cs(ChallengerMod.ColorTable.InformantColor, "Informant Spawn Chance"), 100f, 0f, 100f, 5f, InforAdd, true);
            InforCooldown = CustomOption.Create(311, Types.P3, "> Analyse-Player Cooldown", 30f, 10f, 60f, 2.5f, InforAdd);
            InforAnalyseMod = CustomOption.Create(312, Types.P3, "> Analyne-Player Settings", new string[] { "Single Use", "Can be used\nonce per turn", "Usable at will" }, InforAdd);
            InforAnalyseTeam = CustomOption.Create(313, Types.P3, "> Analyne-Player Team", true, InforAdd);

            BaitSpawnChance = CustomOption.Create(320, Types.P3, cs(ChallengerMod.ColorTable.BaitColor, "Bait Spawn Chance"), 100f, 0f, 100f, 5f, BaitAdd, true);
            BaitReporttime = CustomOption.Create(321, Types.P3, "> Time Before Killer Self-Report", 1f, 1f, 10f, 1f, BaitAdd);
            BaitReporttimeRnd = CustomOption.Create(322, Types.P3, "> Random additionnal time", 0f, 0f, 10f, 1f, BaitAdd);
            BaitCanVent = CustomOption.Create(323, Types.P3, "> Can Use Vent", false, BaitAdd);
       
            MentalistSpawnChance = CustomOption.Create(330, Types.P3, cs(ChallengerMod.ColorTable.MentalistColor, "Mentalist Spawn Chance"), 100f, 0f, 100f, 5f, MentalistAdd, true);
            MentalistAbility = CustomOption.Create(331, Types.P3, "> Mentalist Ability", new string[] { "Admin Color\nOnly", "Vote Color\nOnly", "Admin + Vote\nColor" }, MentalistAdd);
            AdminSetting = CustomOption.Create(332, Types.P3, "> Admin Table Color Settings", new string[] { "Single Use", "Can be used\nonce per turn" }, MentalistAdd);
            AdminDuration = CustomOption.Create(333, Types.P3, "> Admin Color Duration", 10f, 1f, 60f, 1f, MentalistAdd);
          
            BuilderSpawnChance = CustomOption.Create(340, Types.P3, cs(ChallengerMod.ColorTable.BuilderColor, "Builder Spawn Chance"), 100f, 0f, 100f, 5f, BuilderAdd, true);
            BuildRound = CustomOption.Create(341, Types.P3, "> Block only 1 Vent per round", true, BuilderAdd);
            MaxBuild = CustomOption.Create(342, Types.P3, "> Amount of use available", new string[] { "x1", "x2", "x3" }, BuilderAdd);
            BuildCooldown = CustomOption.Create(343, Types.P3, "> Block Vent Ability Cooldown", 30f, 10f, 60f, 2.5f, BuilderAdd);

            DictatorSpawnChance = CustomOption.Create(350, Types.P3, cs(ChallengerMod.ColorTable.DictatorColor, "Dictator Spawn Chance"), 100f, 0f, 100f, 5f, DictatorAdd, true);
            DictatorMeeting = CustomOption.Create(351, Types.P3, "> NoSkipVote Ability Setting", new string[] { "Passif", "Can be used\nonce per turn", "Single Use" }, DictatorAdd);
            DictatorFirstTurn = CustomOption.Create(352, Types.P3, "> Disable Ability at first round", true, DictatorAdd);

            SentinelSpawnChance = CustomOption.Create(360, Types.P3, cs(ChallengerMod.ColorTable.SentinelColor, "Sentinel Spawn Chance"), 100f, 0f, 100f, 5f, SentinelAdd, true);
            ScanCooldown = CustomOption.Create(361, Types.P3, "> Scan Ability Cooldown", 30f, 10f, 60f, 2.5f, SentinelAdd);
            ScanDuration = CustomOption.Create(362, Types.P3, "> Scan Ability Duration", 10f, 1f, 20f, 1f, SentinelAdd);
            ScanAbility = CustomOption.Create(363, Types.P3, "> Scan Ability Settings", new string[] { "Scan Vent\nOnly", "Scan Corpse\nOnly", "Scan Vent\nAnd Corpse" }, SentinelAdd);


            MateSpawnChance = CustomOption.Create(370, Types.P3, cs(ChallengerMod.ColorTable.CrewColor, "Teammate Spawn Chance"), 100f, 0f, 100f, 5f, MateAdd, true);

            LawkeeperSpawnChance = CustomOption.Create(380, Types.P3, cs(ChallengerMod.ColorTable.LawkeeperColor, "Lawkeeper Spawn Chance"), 100f, 0f, 100f, 5f, LawkeeperAdd, true);
            LKTimer = CustomOption.Create(381, Types.P3, "> Can see death delay", true, LawkeeperAdd);
            LKInfo = CustomOption.Create(384, Types.P3, "> info", true, LawkeeperAdd);
            TimeRName = CustomOption.Create(382, Types.P3, "> Max delay to get the killer name", 0f, 0f, 60f, 1f, LawkeeperAdd);
            TimeRList = CustomOption.Create(383, Types.P3, "> Max delay to get Suspect List", 5f, 0f, 60f, 1f, LawkeeperAdd);
            SuperInfo = CustomOption.Create(385, Types.P3, "> Task End for sharing ability ", true, LawkeeperAdd);


            FakeSpawnChance = CustomOption.Create(390, Types.P3, cs(ChallengerMod.ColorTable.FakeColor, "Fake Spawn Chance"), 100f, 0f, 100f, 5f, FakeAdd, true);
            ImpostorCanKillFake = CustomOption.Create(391, Types.P3, "> Impostors can Kill Fake & Other Impostors", false, FakeAdd);
            FakeCanVent = CustomOption.Create(392, Types.P3, "> Can Use Vent", false, FakeAdd);
            
            //P4

            CupidSpawnChance = CustomOption.Create(500, Types.P4, cs(ChallengerMod.ColorTable.CupidColor, "Cupid Spawn Chance"), 100f, 0f, 100f, 5f, CupidAdd, true);
            Loverdie = CustomOption.Create(501, Types.P4, "> Both Lover Die", true, CupidAdd);

            CultisteSpawnChance = CustomOption.Create(510, Types.P4, cs(ChallengerMod.ColorTable.CulteColor, "Cultist Spawn Chance"), 100f, 0f, 100f, 5f, CultisteAdd, true);
            CultisteCooldown = CustomOption.Create(511, Types.P4, "> Cooldown for use convert", 30f, 10f, 60f, 2.5f, CultisteAdd);
            CulteMember = CustomOption.Create(512, Types.P4, "> Max culte member", 2f, 1f, 3f, 1f, CultisteAdd);
            Cultistdie = CustomOption.Create(513, Types.P4, "> When convert fail Cultist die", new string[] { "Disabled", "Immediately", "At the next\nmeeting" }, CultisteAdd);


            JesterSpawnChance = CustomOption.Create(520, Types.P4, cs(ChallengerMod.ColorTable.JesterColor, "Jester Spawn Chance"), 100f, 0f, 100f, 5f, JesterAdd, true);
            JesterCooldown = CustomOption.Create(521, Types.P4, "> Fake-Kill Ability Cooldown", 30f, 10f, 60f, 2.5f, JesterAdd);
            JesterSingle = CustomOption.Create(522, Types.P4, "> Fake Kill Ability Available", new string[] { "Single Use", "Enable", "Disabled" }, JesterAdd);

            EaterSpawnChance = CustomOption.Create(530, Types.P4, cs(ChallengerMod.ColorTable.EaterColor, "Eater Spawn Chance"), 100f, 0f, 100f, 5f, EaterAdd, true);
            EaterCooldown = CustomOption.Create(531, Types.P4, "> Eat Deadbody Ability Cooldown", 30f, 10f, 60f, 2.5f, EaterAdd);
            Eaterduration = CustomOption.Create(532, Types.P4, "> Delay for Eat deadbody", 5f, 1f, 20f, 1f, EaterAdd);
            Eatvalueforwin = CustomOption.Create(533, Types.P4, "> amount of corpse eat to win", new string[] { "x1", "x2", "x3", "x4", "x5" }, EaterAdd);
            EaterCanVent = CustomOption.Create(534, Types.P4, "> Can Use Vent", true, EaterAdd);
            EaterCanDrag = CustomOption.Create(535, Types.P4, "> Can Drag body", true, EaterAdd);
            BodyRemove = CustomOption.Create(536, Types.P4, "> Blood Remove after Meeting", false, EaterAdd);

            OutlawSpawnChance = CustomOption.Create(540, Types.P4, cs(ChallengerMod.ColorTable.OutlawColor, "Outlaw Spawn Chance"), 100f, 0f, 100f, 5f, OutlawAdd, true);
            OutlawKillCooldown = CustomOption.Create(541, Types.P4, "> Kill Cooldown", 30f, 10f, 60f, 2.5f, OutlawAdd);
            OutlawKillRange = CustomOption.Create(542, Types.P4, "> Kill Range", new string[] { "100%", "120%" }, OutlawAdd);

            ArsonistSpawnChance = CustomOption.Create(550, Types.P4, cs(ChallengerMod.ColorTable.ArsonistColor, "Arsonist Spawn Chance"), 100f, 0f, 100f, 5f, ArsonistAdd, true);
            ArsonistFuelQT = CustomOption.Create(551, Types.P4, "> Quantity of Fuel need for oil", 50f, 0f, 100f, 10f, ArsonistAdd);
            ArsonistCooldown = CustomOption.Create(552, Types.P4, "> Oil Ability Cooldown", 30f, 10f, 60f, 2.5f, ArsonistAdd);
            ArsonistDuration = CustomOption.Create(553, Types.P4, "> Oil Ability Cast-Time", 2f, 0f, 10f, 1f, ArsonistAdd);
            ArsonistFailDuration = CustomOption.Create(554, Types.P4, "> Oil Ability Fail Duration", 10f, 1f, 30f, 1f, ArsonistAdd);
            AutoRefuel = CustomOption.Create(555, Types.P4, "> Auto Refuel After Meeting", true, ArsonistAdd);

            CursedSpawnChance = CustomOption.Create(560, Types.P4, cs(ChallengerMod.ColorTable.CursedColor, "Cursed Spawn Chance"), 100f, 0f, 100f, 5f, CursedAdd, true);
            CursedTimer = CustomOption.Create(561, Types.P4, "> Curse timer", 20f, 10f, 60f, 2.5f, CursedAdd);
            CursedSpeedModifieur = CustomOption.Create(562, Types.P4, "> Curse Speed", new string[] { "100%", "110%", "120%", "130%", "140%", "150%", "80%", "90%" }, CursedAdd);
            CursedAbility = CustomOption.Create(563, Types.P4, "> Cecite enable", true, CursedAdd);
            CursedCooldown = CustomOption.Create(564, Types.P4, "> Cecite cooldown", 20f, 10f, 60f, 2.5f, CursedAbility);
            CursedDuration = CustomOption.Create(565, Types.P4, "> Cecite duration", 8f, 1f, 30f, 1f, CursedAbility);

            MercenarySpawnChance = CustomOption.Create(600, Types.P4, cs(ChallengerMod.ColorTable.MercenaryColor, "Mercenary Spawn Chance"), 100f, 0f, 100f, 5f, MercenaryAdd, true);
            MercenaryKillCooldown = CustomOption.Create(601, Types.P4, "> Kill Cooldown", 30f, 10f, 60f, 2.5f, MercenaryAdd);
            MercenaryCanVent = CustomOption.Create(602, Types.P4, "> Can Use Vent (if Impostor)", false, MercenaryAdd);


            CopyCatSpawnChance = CustomOption.Create(610, Types.P4, cs(ChallengerMod.ColorTable.CopyCatColor, "CopyCat Spawn Chance"), 100f, 0f, 100f, 5f, CopyCatAdd, true);
            CopyImp = CustomOption.Create(611, Types.P4, "> Result if he copies an Impostor", new string[] { "CopyCat Die", "CopyCat\nBecome Impostor", "CopyCat\nBecome Sheriff", "CopyCat\nBecome Crewmate" }, CopyCatAdd);
            CopySpe = CustomOption.Create(612, Types.P4, "> Result if he copies an Special Role", new string[] { "CopyCat Die", "CopyCat\nBecome Sheriff", "CopyCat\nBecome Crewmate" }, CopyCatAdd);

            SorcererSpawnChance = CustomOption.Create(620, Types.P4, cs(ChallengerMod.ColorTable.SurvivorColor, "Survivor Spawn Chance"), 100f, 0f, 100f, 5f, SorcererAdd, true);
            SurvivorWinJester = CustomOption.Create(621, Types.P4, "> Can win with the Jester", false, SorcererAdd);
            SurvivorWinEater = CustomOption.Create(622, Types.P4, "> Can win with the Eater", false, SorcererAdd);
            SurvivorWinOutlaw = CustomOption.Create(623, Types.P4, "> Can win with the Outlaw", false, SorcererAdd);
            SurvivorWinArsonist = CustomOption.Create(624, Types.P4, "> Can win with the Arsonist", false, SorcererAdd);
            SurvivorWinCulte = CustomOption.Create(625, Types.P4, "> Can win with the Culte", false, SorcererAdd);
            SurvivorWinCursed = CustomOption.Create(626, Types.P4, "> Can win with the Cursed", false, SorcererAdd);

            RevengerSpawnChance = CustomOption.Create(630, Types.P4, cs(ChallengerMod.ColorTable.RevengerColor, "Revenger Spawn Chance"), 100f, 0f, 100f, 5f, RevengerAdd, true);
            QtVenger = CustomOption.Create(631, Types.P4, "> Number of Use Ability Target EMP", 3f, 1f, 3f, 1f, RevengerAdd);
            VengerCooldown = CustomOption.Create(632, Types.P4, "> Target EMP Ability Cooldown", 30f, 10f, 60f, 2.5f, RevengerAdd);
            VengerKill = CustomOption.Create(633, Types.P4, "> EMP affect All players (Kill)", false, RevengerAdd);
            VengerExil = CustomOption.Create(634, Types.P4, "> EMP affect All players (Voted Out)", false, RevengerAdd);

            //P5

            AssassinSpawnChance = CustomOption.Create(670, Types.P5, cs(ChallengerMod.ColorTable.AssassinColor, "Assassin Spawn Chance"), 100f, 0f, 100f, 5f, AssassinAdd, true);
            AssassinKillCooldown = CustomOption.Create(671, Types.P5, "> Kill Cooldown", 25f, 10f, 60f, 2.5f, AssassinAdd);
            AssassinCanKillShield = CustomOption.Create(672, Types.P5, "> Can Kill Shielded player", false, AssassinAdd);
            BSheriff = CustomOption.Create(673, Types.P5, "> Bonus for kill the Sheriff", true, AssassinAdd);
            BGuardian = CustomOption.Create(674, Types.P5, "> Bonus for kill the Guardian", true, AssassinAdd);
            BEngineer = CustomOption.Create(675, Types.P5, "> Bonus for kill the Engineer", true, AssassinAdd);
            BTimelord = CustomOption.Create(676, Types.P5, "> Bonus for kill the Timelord", true, AssassinAdd);
            BMystic = CustomOption.Create(677, Types.P5, "> Bonus for kill the Mystic", true, AssassinAdd);
            BMayor = CustomOption.Create(678, Types.P5, "> Bonus for kill the Mayor", true, AssassinAdd);
            BDetective = CustomOption.Create(679, Types.P5, "> Bonus for kill the Detective", true, AssassinAdd);
            BNightwatcher = CustomOption.Create(680, Types.P5, "> Bonus for kill the Nightwatch", true, AssassinAdd);
            BSpy = CustomOption.Create(681, Types.P5, "> Bonus for kill the Spy", true, AssassinAdd);
            BInfor = CustomOption.Create(682, Types.P5, "> Bonus for kill the Informant", true, AssassinAdd);
            BMentalist = CustomOption.Create(683, Types.P5, "> Bonus for kill the Mentalist", true, AssassinAdd);
            BBuilder = CustomOption.Create(684, Types.P5, "> Bonus for kill the Builder", true, AssassinAdd);
            BDictator = CustomOption.Create(685, Types.P5, "> Bonus for kill the Dictator", true, AssassinAdd);
            BSentinel = CustomOption.Create(686, Types.P5, "> Bonus for kill the Sentinel", true, AssassinAdd);
            BLawkeeper = CustomOption.Create(687, Types.P5, "> Bonus for kill the Lawkeeper", true, AssassinAdd);
            BImpo = CustomOption.Create(688, Types.P5, "> Bonus for kill the Impostors", true, AssassinAdd);

            VectorSpawnChance = CustomOption.Create(700, Types.P5, cs(ChallengerMod.ColorTable.VectorColor, "Vector Spawn Chance"), 100f, 0f, 100f, 5f, VectorAdd, true);
            VectorBuffCooldown = CustomOption.Create(701, Types.P5, "> Cooldown for infect another player", 30f, 10f, 60f, 2.5f, VectorAdd);
            VectorKillCooldown = CustomOption.Create(702, Types.P5, "> Cooldown to kill the infected player", 5f, 1f, 60f, 1f, VectorAdd);
            VectorBuffVisibility = CustomOption.Create(703, Types.P5, "> The infected player knows he is contaminated", true, VectorAdd);
            VectorCanVent = CustomOption.Create(704, Types.P5, "> Can Use vent", false, VectorAdd);

            MorphlingSpawnChance = CustomOption.Create(720, Types.P5, cs(ChallengerMod.ColorTable.MorphlingColor, "Morphling Spawn Chance"), 100f, 0f, 100f, 5f, MorphlingAdd, true);
            MorphSetCooldown = CustomOption.Create(721, Types.P5, "> Morph Ability Cooldown", 35f, 10f, 60f, 2.5f, MorphlingAdd);
            MorphSetDuration = CustomOption.Create(722, Types.P5, "> Morph Ability Duratuion", 15f, 1f, 30f, 1f, MorphlingAdd);
            MorphlingCanVent = CustomOption.Create(724, Types.P5, "> Can Use vent", true, MorphlingAdd);

            CamoSpawnChance = CustomOption.Create(730, Types.P5, cs(ChallengerMod.ColorTable.ScramblerColor, "Scrambler Spawn Chance"), 100f, 0f, 100f, 5f, CamoAdd, true);
            CamoSetCooldown = CustomOption.Create(731, Types.P5, "> Camo Ability Cooldown", 35f, 10f, 60f, 2.5f, CamoAdd);
            CamoSetDuration = CustomOption.Create(732, Types.P5, "> Camo Ability Duratuion", 8f, 1f, 30f, 1f, CamoAdd);
            CamoCanVent = CustomOption.Create(733, Types.P5, "> Can Use vent", true, CamoAdd);

            BarghestSpawnChance = CustomOption.Create(740, Types.P5, cs(ChallengerMod.ColorTable.BarghestColor, "Barghest Spawn Chance"), 100f, 0f, 100f, 5f, BarghestAdd, true);
            BargestLightCooldown = CustomOption.Create(741, Types.P5, "> Shadow Ability Cooldown", 35f, 10f, 60f, 2.5f, BarghestAdd);
            BargestLightDuration = CustomOption.Create(742, Types.P5, "> Shadow Ability Duratuion", 8f, 1f, 30f, 1f, BarghestAdd);
            BarghestAffectImpostor = CustomOption.Create(743, Types.P5, "> Shadow Ability Affect other Impostor", false, BarghestAdd);
            BarghestCamlight = CustomOption.Create(744, Types.P5, "> Shadow Ability Disable Camera", true, BarghestAdd);
            BarghestCanCreateVent = CustomOption.Create(745, Types.P5, "> Create Vent Ability Available", true, BarghestAdd);
            BarghestVentCD = CustomOption.Create(746, Types.P5, "> Create Vent cooldown", 35f, 10f, 60f, 2.5f, BarghestCanCreateVent);
            BarghestCanVent = CustomOption.Create(747, Types.P5, "> Can Use vent", true, BarghestCanCreateVent);
            CanUseBarghestVent = CustomOption.Create(748, Types.P5, "> Who can Use Barghest Vent", new string[] { "Only Barghest", "All Impostors", "All Impostors\nIf Can use Vent", "Everyone\nIf Can use Vent" }, BarghestCanCreateVent);

            GhostSpawnChance = CustomOption.Create(750, Types.P5, cs(ChallengerMod.ColorTable.GhostColor, "Ghost Spawn Chance"), 100f, 0f, 100f, 5f, GhostAdd, true);
            HideSetCooldown = CustomOption.Create(751, Types.P5, "> Invisibility Ability Cooldown", 35f, 10f, 60f, 2.5f, GhostAdd);
            HideSetDuration = CustomOption.Create(752, Types.P5, "> Invisibility Ability Duratuion", 8f, 1f, 30f, 1f, GhostAdd);
            GhostCanVent = CustomOption.Create(753, Types.P5, "> Can Use vent", true, GhostAdd);

            WarSpawnChance = CustomOption.Create(760, Types.P5, cs(ChallengerMod.ColorTable.SorcererColor, "Sorcerer Spawn Chance"), 100f, 0f, 100f, 5f, WarAdd, true);
            WarCooldown = CustomOption.Create(761, Types.P5, "> Find Rune Ability Cooldown", 35f, 10f, 90f, 2.5f, WarAdd);
            War1 = CustomOption.Create(762, Types.P5, "> Focus Ability Enable (x1 rune)", true, WarAdd);
            War2 = CustomOption.Create(763, Types.P5, "> Vision Ability Enable (x2 runes)", true, WarAdd);
            War3 = CustomOption.Create(764, Types.P5, "> Confuse Ability Enable (x3 runes)", true, WarAdd);
            War4 = CustomOption.Create(765, Types.P5, "> Destroy Ability Enable (x4 runes)", true, WarAdd);
            WarCanVent = CustomOption.Create(766, Types.P5, "> Can Use vent", true, WarAdd);

            GuesserSpawnChance = CustomOption.Create(770, Types.P5, cs(ChallengerMod.ColorTable.GuesserColor, "Guesser Spawn Chance"), 100f, 0f, 100f, 5f, GuesserAdd, true);
            Gestry = CustomOption.Create(771, Types.P5, "> Number of Guess-Kill during meeting", 3f, 1f, 10f, 1f, GuesserAdd);
            GuessTryOne = CustomOption.Create(772, Types.P5, "> Only One Guess-Kill per Meeting", true, GuesserAdd);
            GuessDie = CustomOption.Create(773, Types.P5, "> Guesser Die if he is wrong Guess", false, GuesserAdd);
            GuessMystic = CustomOption.Create(774, Types.P5, "> Mystic is not a guessable role", true, GuesserAdd);
            GuessSpirit = CustomOption.Create(775, Types.P5, "> Spirit is not a guessable role", true, GuesserAdd);
            GuessFake = CustomOption.Create(776, Types.P5, "> Fake is not a guessable role", true, GuesserAdd);
            GuessCanVent = CustomOption.Create(777, Types.P5, "> Can Use vent", true, GuesserAdd);

            BasiliskSpawnChance = CustomOption.Create(780, Types.P5, cs(ChallengerMod.ColorTable.BasiliskColor, "Basilisk Spawn Chance"), 100f, 0f, 100f, 5f, BasiliskAdd, true);
            BasiliskCooldown = CustomOption.Create(781, Types.P5, "> Max storable dose(s)", 10f, 1f, 10f, 1f, BasiliskAdd);
            BasiliskStart = CustomOption.Create(782, Types.P5, "> Dose(s) at the Start", 0f, 0f, 10f, 1f, BasiliskAdd);
            BasiliskKill = CustomOption.Create(783, Types.P5, "> Dose(s) gained per kill", 3f, 0f, 10f, 1f, BasiliskAdd);
            BasiliskMeet = CustomOption.Create(784, Types.P5, "> Dose(s) gained per round", 1f, 0f, 10f, 1f, BasiliskAdd);
            BasiliskVote = CustomOption.Create(785, Types.P5, "> Ability Avalaible Setting", new string[] { "Paralyze and\nPetrify", "Only Paralyze", "Only Petrify" }, BasiliskAdd);
            BasiliskParalizeCost = CustomOption.Create(786, Types.P5, "> Paralize Ability Cost", 5f, 1f, 10f, 1f, BasiliskAdd);
            BasiliskPetrifyCost = CustomOption.Create(787, Types.P5, "> Petrify Ability Cost", 7f, 1f, 10f, 1f, BasiliskAdd);
            BasiliskSinglePetrify = CustomOption.Create(788, Types.P5, "> Target Affected once", true, BasiliskAdd);
            BasiliskCanVent = CustomOption.Create(789, Types.P5, "> Can Use vent", true, BasiliskAdd);


        }
    }
}
