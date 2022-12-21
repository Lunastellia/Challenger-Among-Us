using HarmonyLib;
using System.Linq;
using System;
using System.Collections.Generic;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using UnityEngine;
using static ChallengerMod.Set.Data;


using ChallengerMod.RPC;

namespace ChallengerMod.RoleInfos
{
    class RoleInfo
    {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public bool isSpecialRole;

        RoleInfo(string name, Color color, string introDescription, string shortDescription, SetRoleID roleId, bool isSpecialRole = false)
        {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.isSpecialRole = isSpecialRole;
        }
        public static RoleInfo _Crewmate = new RoleInfo(Role_Crewmate, CrewmatesColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate1,  false);
        public static RoleInfo _Crewmate1 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate1,  false);
        public static RoleInfo _Crewmate2 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate2,  false);
        public static RoleInfo _Crewmate3 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate3,  false);
        public static RoleInfo _Crewmate4 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate4,  false);
        public static RoleInfo _Crewmate5 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate5,  false);
        public static RoleInfo _Crewmate6 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate6,  false);
        public static RoleInfo _Crewmate7 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate7, false);
        public static RoleInfo _Crewmate8 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate8,  false);
        public static RoleInfo _Crewmate9 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate9,  false);
        public static RoleInfo _Crewmate10 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate10,  false);
        public static RoleInfo _Crewmate11 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate11,  false);
        public static RoleInfo _Crewmate12 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate12,  false);
        public static RoleInfo _Crewmate13 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate13,  false);
        public static RoleInfo _Crewmate14 = new RoleInfo(Role_Crewmate, CrewmateColor, Task_Role_Crewmate, Task_Role_Crewmate, SetRoleID.SetCrewmate14,  false);

        public static RoleInfo _Sheriff = new RoleInfo(Role_Sheriff, SheriffsColor, Task_Role_Sheriff, Task_Role_Sheriff, SetRoleID.SetSheriff1, false);
        public static RoleInfo _Sheriff1 = new RoleInfo(Role_Sheriff, SheriffColor, Task_Role_Sheriff, Task_Role_Sheriff, SetRoleID.SetSheriff1, false);
        public static RoleInfo _Sheriff2 = new RoleInfo(Role_Sheriff, SheriffColor, Task_Role_Sheriff, Task_Role_Sheriff, SetRoleID.SetSheriff2, false);
        public static RoleInfo _Sheriff3 = new RoleInfo(Role_Sheriff, SheriffColor, Task_Role_Sheriff, Task_Role_Sheriff, SetRoleID.SetSheriff3, false);
        public static RoleInfo _Guardian = new RoleInfo(Role_Guardian, GuardianColor, Task_Role_Guardian, Task_Role_Guardian, SetRoleID.SetGuardian, false);
        public static RoleInfo _Engineer = new RoleInfo(Role_Engineer, EngineerColor, Task_Role_Engineer, Task_Role_Engineer, SetRoleID.SetEngineer, false);
        public static RoleInfo _Hunter = new RoleInfo(Role_Hunter, HunterColor, Task_Role_Hunter, Task_Role_Hunter, SetRoleID.SetHunter, false);
        public static RoleInfo _Timelord = new RoleInfo(Role_Timelord, TimeLordColor, Task_Role_Timelord, Task_Role_Timelord, SetRoleID.SetTimelord, false);
        public static RoleInfo _Mystic = new RoleInfo(Role_Mystic, MysticColor, Task_Role_Mystic, Task_Role_Mystic, SetRoleID.SetMystic, false);
        public static RoleInfo _Spirit = new RoleInfo(Role_Spirit, SpiritColor, Task_Role_Spirit, Task_Role_Spirit, SetRoleID.SetSpirit, false);
        public static RoleInfo _Mayor = new RoleInfo(Role_Mayor, MayorColor, Task_Role_Mayor, Task_Role_Mayor, SetRoleID.SetMayor, false);
        public static RoleInfo _Detective = new RoleInfo(Role_Detective, DetectiveColor, Task_Role_Detective, Task_Role_Detective, SetRoleID.SetDetective, false);
        public static RoleInfo _Nightwatch = new RoleInfo(Role_Nightwatch, NightwatchColor, Task_Role_Nightwatch, Task_Role_Nightwatch, SetRoleID.SetNightwatch, false);
        public static RoleInfo _Spy = new RoleInfo(Role_Spy, SpyColor, Task_Role_Spy, Task_Role_Spy, SetRoleID.SetSpy, false);
        public static RoleInfo _Informant = new RoleInfo(Role_Informant, InformantColor, Task_Role_Informant, Task_Role_Informant, SetRoleID.SetInformant, false);
        public static RoleInfo _Bait = new RoleInfo(Role_Bait, BaitColor, Task_Role_Bait, Task_Role_Bait, SetRoleID.SetBait, false);
        public static RoleInfo _Mentalist = new RoleInfo(Role_Mentalist, MentalistColor, Task_Role_Mentalist, Task_Role_Mentalist, SetRoleID.SetMentalist, false);
        public static RoleInfo _Builder = new RoleInfo(Role_Builder, BuilderColor, Task_Role_Builder, Task_Role_Builder, SetRoleID.SetBuilder, false);
        public static RoleInfo _Dictator = new RoleInfo(Role_Dictator, DictatorColor, Task_Role_Dictator, Task_Role_Dictator, SetRoleID.SetDictator, false);
        public static RoleInfo _Sentinel = new RoleInfo(Role_Sentinel, SentinelColor, Task_Role_Sentinel, Task_Role_Sentinel, SetRoleID.SetSentinel, false);
        public static RoleInfo _Teammate = new RoleInfo(Role_Teammate, TeammateColor, Task_Role_Teammate, Task_Role_Teammate, SetRoleID.SetTeammate1, false);
        public static RoleInfo _Teammate1 = new RoleInfo(Role_Teammate, CrewmateColor, Task_Role_Teammate, Task_Role_Teammate, SetRoleID.SetTeammate1, false);
        public static RoleInfo _Teammate2 = new RoleInfo(Role_Teammate, CrewmateColor, Task_Role_Teammate, Task_Role_Teammate, SetRoleID.SetTeammate2, false);
        public static RoleInfo _Lawkeeper = new RoleInfo(Role_Lawkeeper, LawkeeperColor, Task_Role_Lawkeeper, Task_Role_Lawkeeper, SetRoleID.SetLawkeeper, false);
        public static RoleInfo _Fake = new RoleInfo(Role_Fake, FakeColor, Task_Role_Fake, Task_Role_Fake, SetRoleID.SetFake, false);
        public static RoleInfo _Traveler = new RoleInfo(Role_Traveler, TravelerColor, Task_Role_Traveler, Task_Role_Traveler, SetRoleID.SetTraveler, false);
        public static RoleInfo _Leader = new RoleInfo(Role_Leader, LeaderColor, Task_Role_Leader, Task_Role_Leader, SetRoleID.SetLeader, false);
        public static RoleInfo _Doctor = new RoleInfo(Role_Doctor, DoctorColor, Task_Role_Doctor, Task_Role_Doctor, SetRoleID.SetDoctor, false);
        public static RoleInfo _Slave = new RoleInfo(Role_Slave, SlaveColor, Task_Role_Slave, Task_Role_Slave, SetRoleID.SetSlave, false);

        public static RoleInfo _Cupid = new RoleInfo(Role_Cupid, CupidColor, Task_Role_Cupid, Task_Role_Cupid, SetRoleID.SetCupid, true);
        public static RoleInfo _Cultist = new RoleInfo(Role_Cultist, CulteColor, Task_Role_Cultist, Task_Role_Cultist, SetRoleID.SetCultist, true);
        public static RoleInfo _Outlaw = new RoleInfo(Role_Outlaw, OutlawColor, Task_Role_Outlaw, Task_Role_Outlaw, SetRoleID.SetOutlaw, true);
        public static RoleInfo _Jester = new RoleInfo(Role_Jester, JesterColor, Task_Role_Jester, Task_Role_Jester, SetRoleID.SetJester, true);
        public static RoleInfo _Eater = new RoleInfo(Role_Eater, EaterColor, Task_Role_Eater, Task_Role_Eater, SetRoleID.SetEater, true);
        public static RoleInfo _Arsonist = new RoleInfo(Role_Arsonist, ArsonistColor, Task_Role_Arsonist, Task_Role_Arsonist, SetRoleID.SetArsonist, true);
        public static RoleInfo _Cursed = new RoleInfo(Role_Cursed, CursedColor, Task_Role_Cursed, Task_Role_Cursed, SetRoleID.SetCursed, true);

        public static RoleInfo _Mercenary = new RoleInfo(Role_Mercenary, MercenaryColor, Task_Role_Mercenary, Task_Role_Mercenary, SetRoleID.SetMercenary, true);
        public static RoleInfo _CopyCat = new RoleInfo(Role_CopyCat, CopyCatColor, Task_Role_CopyCat, Task_Role_CopyCat, SetRoleID.SetCopyCat, true);
        public static RoleInfo _Revenger = new RoleInfo(Role_Revenger, RevengerColor, Task_Role_Revenger, Task_Role_Revenger, SetRoleID.SetRevenger, true);
        public static RoleInfo _Survivor = new RoleInfo(Role_Survivor, SurvivorColor, Task_Role_Survivor, Task_Role_Survivor, SetRoleID.SetSurvivor, true);

        public static RoleInfo _Impostor = new RoleInfo(Role_Impostor, ImpostorColor, Task_Role_Impostor, Task_Role_Impostor, SetRoleID.SetImpostor1, false);
        public static RoleInfo _Impostor1 = new RoleInfo(Role_Impostor, ImpostorColor, Task_Role_Impostor, Task_Role_Impostor, SetRoleID.SetImpostor1, false);
        public static RoleInfo _Impostor2 = new RoleInfo(Role_Impostor, ImpostorColor, Task_Role_Impostor, Task_Role_Impostor, SetRoleID.SetImpostor2, false);
        public static RoleInfo _Impostor3 = new RoleInfo(Role_Impostor, ImpostorColor, Task_Role_Impostor, Task_Role_Impostor, SetRoleID.SetImpostor3, false);

        public static RoleInfo _Assassin = new RoleInfo(Role_Assassin, AssassinColor, Task_Role_Assassin, Task_Role_Assassin, SetRoleID.SetAssassin, false);
        public static RoleInfo _Vector = new RoleInfo(Role_Vector, VectorColor, Task_Role_Vector, Task_Role_Vector, SetRoleID.SetVector, false);
        public static RoleInfo _Morphling = new RoleInfo(Role_Morphling, MorphlingColor, Task_Role_Morphling, Task_Role_Morphling, SetRoleID.SetMorphling, false);
        public static RoleInfo _Scrambler = new RoleInfo(Role_Scrambler, ScramblerColor, Task_Role_Scrambler, Task_Role_Scrambler, SetRoleID.SetScrambler, false);
        public static RoleInfo _Barghest = new RoleInfo(Role_Barghest, BarghestColor, Task_Role_Barghest, Task_Role_Barghest, SetRoleID.SetBarghest, false);
        public static RoleInfo _Ghost = new RoleInfo(Role_Ghost, GhostColor, Task_Role_Ghost, Task_Role_Ghost, SetRoleID.SetGhost, false);
        public static RoleInfo _Sorcerer = new RoleInfo(Role_Sorcerer, SorcererColor, Task_Role_Sorcerer, Task_Role_Sorcerer, SetRoleID.SetSorcerer, false);
        public static RoleInfo _Guesser = new RoleInfo(Role_Guesser, GuesserColor, Task_Role_Guesser, Task_Role_Guesser, SetRoleID.SetGuesser, false);
        public static RoleInfo _Mesmer = new RoleInfo(Role_Mesmer, MesmerColor, Task_Role_Mesmer, Task_Role_Mesmer, SetRoleID.SetMesmer, false);
        public static RoleInfo _Basilisk = new RoleInfo(Role_Basilisk, BasiliskColor, Task_Role_Basilisk, Task_Role_Basilisk, SetRoleID.SetBasilisk, false);
        public static RoleInfo _Reaper = new RoleInfo(Role_Reaper, ReaperColor, Task_Role_Reaper, Task_Role_Reaper, SetRoleID.SetReaper, false);
        public static RoleInfo _Saboteur = new RoleInfo(Role_Saboteur, SaboteurColor, Task_Role_Saboteur, Task_Role_Saboteur, SetRoleID.SetSaboteur, false);




        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {

            _Crewmate,
            _Crewmate1,
            _Crewmate2,
            _Crewmate3,
            _Crewmate4,
            _Crewmate5,
            _Crewmate6,
            _Crewmate7,
            _Crewmate8,
            _Crewmate9,
            _Crewmate10,
            _Crewmate11,
            _Crewmate12,
            _Crewmate13,
            _Crewmate14,

            _Sheriff,
            _Sheriff1,
            _Sheriff2,
            _Sheriff3,

            _Guardian,
            _Engineer,
            _Hunter,
            _Timelord,
            _Mystic,
            _Spirit,
            _Mayor,
            _Detective,
            _Nightwatch,
            _Spy,
            _Informant,
            _Bait,
            _Mentalist,
            _Builder,
            _Dictator,
            _Sentinel,
            _Teammate,
            _Teammate1,
            _Teammate2,
            _Lawkeeper,
            _Fake,
            _Traveler,
            _Leader,
            _Doctor,
            _Slave,

            _Cupid,
            _Cultist,
            _Outlaw,
            _Jester,
            _Eater,
            _Arsonist,
            _Cursed,

            _Mercenary,
            _CopyCat,
            _Revenger,
            _Survivor,

            _Impostor,
            _Assassin,
            _Vector,
            _Morphling,
            _Scrambler,
            _Barghest,
            _Ghost,
            _Sorcerer,
            _Guesser,
            _Mesmer,
            _Basilisk,
            _Reaper,
            _Saboteur,
                        

        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p)
        {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Special roles
            
            if (p == Sheriff1.Role) infos.Add(_Sheriff);
            if (p == Sheriff2.Role) infos.Add(_Sheriff);
            if (p == Sheriff3.Role) infos.Add(_Sheriff);
            if (p == Guardian.Role) infos.Add(_Guardian);
            if (p == Engineer.Role) infos.Add(_Engineer);
            if (p == Timelord.Role) infos.Add(_Timelord);
            if (p == Hunter.Role) infos.Add(_Hunter);
            if (p == Mystic.Role) infos.Add(_Mystic);
            if (p == Spirit.Role) infos.Add(_Spirit);
            if (p == Mayor.Role) infos.Add(_Mayor);
            if (p == Detective.Role) infos.Add(_Detective);
            if (p == Nightwatch.Role) infos.Add(_Nightwatch);
            if (p == Spy.Role) infos.Add(_Spy);
            if (p == Informant.Role) infos.Add(_Informant);
            if (p == Bait.Role) infos.Add(_Bait);
            if (p == Mentalist.Role) infos.Add(_Mentalist);
            if (p == Builder.Role) infos.Add(_Builder);
            if (p == Dictator.Role) infos.Add(_Dictator);
            if (p == Sentinel.Role) infos.Add(_Sentinel);
            if (p == Teammate1.Role) infos.Add(_Teammate);
            if (p == Teammate2.Role) infos.Add(_Teammate);
            if (p == Lawkeeper.Role) infos.Add(_Lawkeeper);
            if (p == Fake.Role) infos.Add(_Fake);
            if (p == Traveler.Role) infos.Add(_Traveler);
            if (p == Leader.Role) infos.Add(_Leader);
            if (p == Doctor.Role) infos.Add(_Doctor);
            if (p == Slave.Role) infos.Add(_Slave);

            if (p == Crewmate1.Role) infos.Add(_Crewmate);
            if (p == Crewmate2.Role) infos.Add(_Crewmate);
            if (p == Crewmate3.Role) infos.Add(_Crewmate);
            if (p == Crewmate5.Role) infos.Add(_Crewmate);
            if (p == Crewmate5.Role) infos.Add(_Crewmate);
            if (p == Crewmate6.Role) infos.Add(_Crewmate);
            if (p == Crewmate7.Role) infos.Add(_Crewmate);
            if (p == Crewmate8.Role) infos.Add(_Crewmate);
            if (p == Crewmate9.Role) infos.Add(_Crewmate);
            if (p == Crewmate10.Role) infos.Add(_Crewmate);
            if (p == Crewmate11.Role) infos.Add(_Crewmate);
            if (p == Crewmate12.Role) infos.Add(_Crewmate);
            if (p == Crewmate13.Role) infos.Add(_Crewmate);
            if (p == Crewmate14.Role) infos.Add(_Crewmate);


            if (p == Cupid.Role) infos.Add(_Cupid);
            if (p == Cultist.Role) infos.Add(_Cultist);
            if (p == Outlaw.Role) infos.Add(_Outlaw);
            if (p == Jester.Role) infos.Add(_Jester);
            if (p == Eater.Role) infos.Add(_Eater);
            if (p == Arsonist.Role) infos.Add(_Arsonist);
            if (p == Cursed.Role) infos.Add(_Cursed);



            if (p == Mercenary.Role) infos.Add(_Mercenary);
            if (p == CopyCat.Role) infos.Add(_CopyCat);
            if (p == Revenger.Role) infos.Add(_Revenger);
            if (p == Survivor.Role) infos.Add(_Survivor);



            if (p == Assassin.Role) infos.Add(_Assassin);
            if (p == Vector.Role) infos.Add(_Vector);
            if (p == Morphling.Role) infos.Add(_Morphling);
            if (p == Scrambler.Role) infos.Add(_Scrambler);
            if (p == Barghest.Role) infos.Add(_Barghest);
            if (p == Ghost.Role) infos.Add(_Ghost);
            if (p == Sorcerer.Role) infos.Add(_Sorcerer);
            if (p == Guesser.Role) infos.Add(_Guesser);
            if (p == Mesmer.Role) infos.Add(_Mesmer);
            if (p == Basilisk.Role) infos.Add(_Basilisk);
            if (p == Reaper.Role) infos.Add(_Reaper);
            if (p == Saboteur.Role) infos.Add(_Saboteur);
            if (p == Impostor1.Role) infos.Add(_Impostor);
            if (p == Impostor2.Role) infos.Add(_Impostor);
            if (p == Impostor3.Role) infos.Add(_Impostor);



            return infos;
        }

        public static String GetRole(PlayerControl p)
        {
            string roleName;
            roleName = String.Join("", getRoleInfoForPlayer(p).Select(x => x.name).ToArray());
            return roleName;
        }
    }
}