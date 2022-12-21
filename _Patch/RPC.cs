using HarmonyLib;
using Hazel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using ChallengerMod.Utils;
using ChallengerMod.Utils.Option;

using ChallengerMod.Patches;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using ChallengerMod.Versioncheck;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.ResetData;
using static ChallengerMod.WinData;
using static ChallengerMod.Set.Data;
using ChallengerMod._Object;
using ChallengerMod.Item;
using Reactor.Extensions;

namespace ChallengerMod.RPC
{
    enum RPC
    {
        PlayAnimation = 0,
        CompleteTask = 1,
        SyncSettings = 2,
        SetInfected = 3,
        Exiled = 4,
        CheckName = 5,
        SetName = 6,
        CheckColor = 7,
        SetColor = 8,
        SetHat = 9,
        SetSkin = 10,
        ReportDeadBody = 11,
        MurderPlayer = 12,
        SendChat = 13,
        StartMeeting = 14,
        SetScanner = 15,
        SendChatNote = 16,
        SetPet = 17,
        SetStartCounter = 18,
        EnterVent = 19,
        ExitVent = 20,
        SnapTo = 21,
        Close = 22,
        VotingComplete = 23,
        CastVote = 24,
        ClearVote = 25,
        AddVote = 26,
        CloseDoorsOfType = 27,
        RepairSystem = 28,
        SetTasks = 29,
        UpdateGameData = 30,
    }
    enum SetRoleID
    {
        SetSheriff1 = 1,
        SetSheriff2,
        SetSheriff3,
        SetGuardian,
        SetEngineer,
        SetHunter,
        SetTimelord,
        SetMystic,
        SetSpirit,
        SetMayor,
        SetDetective,
        SetNightwatch,
        SetSpy,
        SetInformant,
        SetBait,
        SetMentalist,
        SetBuilder,
        SetDictator,
        SetSentinel,
        SetTeammate1,
        SetTeammate2,
        SetLawkeeper,
        SetFake,
        SetTraveler,
        SetLeader,
        SetDoctor,
        SetSlave,

        SetCrewmate1,
        SetCrewmate2,
        SetCrewmate3,
        SetCrewmate4,
        SetCrewmate5,
        SetCrewmate6,
        SetCrewmate7,
        SetCrewmate8,
        SetCrewmate9,
        SetCrewmate10,
        SetCrewmate11,
        SetCrewmate12,
        SetCrewmate13,
        SetCrewmate14,

        SetCupid,
        SetCultist,
        SetOutlaw,
        SetJester,
        SetEater,
        SetArsonist,
        SetCursed,

        SetMercenary,
        SetCopyCat,
        SetRevenger,
        SetSurvivor,


        SetAssassin,
        SetVector,
        SetMorphling,
        SetScrambler,
        SetBarghest,
        SetGhost,
        SetSorcerer,
        SetGuesser,
        SetMesmer,
        SetBasilisk,
        SetReaper,
        SetSaboteur,

        SetImpostor1,
        SetImpostor2,
        SetImpostor3,
    }


    enum CustomRPC
    {
        // Main Controls
        VersionHandshake = 60,
        ShareOptions,
        ShareReady,
        ShareNotReady,
        ShareAllRoles,
        SyncTimer,
        SyncDie,
        SyncEmergency,
        RemoveAllBodies,
        UncheckedMurderPlayer,
        UncheckedCmdReportDeadBody,
        UseUncheckedVent,
        SetLocalPlayers,
        SetRole,

        //winner
        SetWinLove,
        SetLooseLove,
        SetWinCrewmatesByTask,
        SetWinCrewmatesByKill,
        SetWinImpostorsByKill,
        SetWinImpostorsBySab,
        SetWinJester,
        SetWinEater,
        SetWinOutlaw,
        SetWinArsonist,
        SetWinCulte,
        SetWinCursed,


        //Items
        SpawnItem,
        DestroyItem,

        //sheriff
        Sheriff1Kill,
        Sheriff2Kill,
        Sheriff3Kill,

        //guardian
        ShieldedMurderAttempt,
        SetProtectedPlayer,
        SetProtectedMystic,
        SetProtectedCopyMystic,

        //engineer
        EngineerRepair,
        EngineerFixLight,

        //timelord
        TimeStop_Start,
        TimeStop_End,

        //hunter
        SetTrackedPlayer,
        HunterTrackedDie,
        HunterTrackedKill,
        SetCopyTrackedPlayer,
        HunterCopyTrackedDie,
        HunterCopyTrackedKill,

        //Mystic 
        MysticDoubleShield,
        MysticShieldOn,
        MysticShieldOff,

        //spirit
        SpiritRevive,
        CopyCatRevive,

        //Mayor
        MayorBuzz,

        //Detective
        DetectiveFindFPOn,
        DetectiveFindFPOff,

        //Nightwatch
        NightwatchLightOn,
        NightwatchLightOff,


        //Spy
        SpyOn,
        SpyOff,

        //Informant
        SetInfoPlayer,

        //Mentalist
        MentalistColorOn,
        MentalistColorOff,

        //Sentinel
        SentinelScanOn,
        SentinelScanOff,

        //Builder
        SealVent,

        //Dictator
        DictatorNoSkipVote,

        //Jester
        JesterFakeKill,
        JesterWin,

        //Eater
        CleanBody,

        //Cupid
        SetLover1,
        SetLover2,
        LoversExiled,
        KillLover1,
        KillLover2,

        //Cultist
        SetCulte1Player,
        SetCulte2Player,
        SetCulte3Player,
        CultistDie,

        //Eater
        DraggBody,
        DropBody,
        EatBody,

        //Cursed
        CursedWin,
        CurseSync,

        //Mercenary
        MercenaryKill,
        MercenaryTryKill,

        //CopyCat
        SetCopyPlayer,
        CopyCatDie,
        CopyCatKill,

        //Outlaw
        OutlawKill,

        //Arsonist
        ArsonistWin,
        ArsonistAddOil,

        //Revenger
        SetEMP1Player,
        SetEMP2Player,
        SetEMP3Player,

        //Sorcerer
        SetScan1Player,
        SetScan2Player,
        SetExtPlayer,
        SabAdmin,

        //Vector
        SetInfectePlayer,
        KillInfected,

        //Morphling
        SetMorphPlayer,
        MorphOn,
        MorphOff,


        //Scrambler
        CamoOn,
        CamoOff,

        //Barghest
        ShadowOn,
        ShadowOff,
        CreateVent,

       


        //Ghost
        GhostOn,
        GhostOff,

        //Sorcerer
        War1,
        War2,
        War3,
        War4,

        //Guesser
        GuesserShoot,
        GuesserFail,

        //Basilisk
        SetPetrifyPlayer,
        SetPetrifyAndShieldPlayer,

        //Impostors NormalKill
        VectorKill,
        Impostor1Kill,
        Impostor2Kill,
        Impostor3Kill,
        MorphlingKill,
        ScramblerKill,
        BarghestKill,
        GhostKill,
        SorcererKill,
        GuesserKill,
        BasiliskKill,
        ReaperKill,
        SaboteurKill,

        //Assassin
        AssassinKill,
        AssassinShield,





    }
    public static class RPCProcedure
    {
        public static void setRole(byte roleId, byte playerId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == playerId)
                {
                    switch ((SetRoleID)roleId)
                    {
                       
                        case SetRoleID.SetSheriff1:
                            Sheriff1.Role = player;
                            break;
                        case SetRoleID.SetSheriff2:
                            Sheriff2.Role = player;
                            break;
                        case SetRoleID.SetSheriff3:
                            Sheriff3.Role = player;
                            break;
                        case SetRoleID.SetGuardian:
                            Guardian.Role = player;
                            break;
                        case SetRoleID.SetEngineer:
                            Engineer.Role = player;
                            break;
                        case SetRoleID.SetTimelord:
                            Timelord.Role = player;
                            break;
                        case SetRoleID.SetHunter:
                            Hunter.Role = player;
                            break;
                        case SetRoleID.SetMystic:
                            Mystic.Role = player;
                            break;
                        case SetRoleID.SetSpirit:
                            Spirit.Role = player;
                            break;
                        case SetRoleID.SetMayor:
                            Mayor.Role = player;
                            break;
                        case SetRoleID.SetDetective:
                            Detective.Role = player;
                            break;
                        case SetRoleID.SetNightwatch:
                            Nightwatch.Role = player;
                            break;
                        case SetRoleID.SetSpy:
                            Spy.Role = player;
                            break;
                        case SetRoleID.SetInformant:
                            Informant.Role = player;
                            break;
                        case SetRoleID.SetBait:
                            Bait.Role = player;
                            break;
                        case SetRoleID.SetMentalist:
                            Mentalist.Role = player;
                            break;
                        case SetRoleID.SetBuilder:
                            Builder.Role = player;
                            break;
                        case SetRoleID.SetDictator:
                            Dictator.Role = player;
                            break;
                        case SetRoleID.SetSentinel:
                            Sentinel.Role = player;
                            break;
                        case SetRoleID.SetTeammate1:
                            Teammate1.Role = player;
                            break;
                        case SetRoleID.SetTeammate2:
                            Teammate2.Role = player;
                            break;
                        case SetRoleID.SetLawkeeper:
                            Lawkeeper.Role = player;
                            break;
                        case SetRoleID.SetFake:
                            Fake.Role = player;
                            break;
                        case SetRoleID.SetTraveler:
                            Traveler.Role = player;
                            break;
                        case SetRoleID.SetLeader:
                            Leader.Role = player;
                            break;
                        case SetRoleID.SetDoctor:
                            Doctor.Role = player;
                            break;
                        case SetRoleID.SetSlave:
                            Slave.Role = player;
                            break;
                        case SetRoleID.SetCrewmate1:
                            Crewmate1.Role = player;
                            break;
                        case SetRoleID.SetCrewmate2:
                            Crewmate2.Role = player;
                            break;
                        case SetRoleID.SetCrewmate3:
                            Crewmate3.Role = player;
                            break;
                        case SetRoleID.SetCrewmate4:
                            Crewmate4.Role = player;
                            break;
                        case SetRoleID.SetCrewmate5:
                            Crewmate5.Role = player;
                            break;
                        case SetRoleID.SetCrewmate6:
                            Crewmate6.Role = player;
                            break;
                        case SetRoleID.SetCrewmate7:
                            Crewmate7.Role = player;
                            break;
                        case SetRoleID.SetCrewmate8:
                            Crewmate8.Role = player;
                            break;
                        case SetRoleID.SetCrewmate9:
                            Crewmate9.Role = player;
                            break;
                        case SetRoleID.SetCrewmate10:
                            Crewmate10.Role = player;
                            break;
                        case SetRoleID.SetCrewmate11:
                            Crewmate11.Role = player;
                            break;
                        case SetRoleID.SetCrewmate12:
                            Crewmate12.Role = player;
                            break;
                        case SetRoleID.SetCrewmate13:
                            Crewmate13.Role = player;
                            break;
                        case SetRoleID.SetCrewmate14:
                            Crewmate14.Role = player;
                            break;
                        case SetRoleID.SetCupid:
                            Cupid.Role = player;
                            break;
                        case SetRoleID.SetCultist:
                            Cultist.Role = player;
                            break;
                        case SetRoleID.SetOutlaw:
                            Outlaw.Role = player;
                            break;
                        case SetRoleID.SetJester:
                            Jester.Role = player;
                            break;
                        case SetRoleID.SetEater:
                            Eater.Role = player;
                            break;
                        case SetRoleID.SetArsonist:
                            Arsonist.Role = player;
                            break;
                        case SetRoleID.SetCursed:
                            Cursed.Role = player;
                            break;
                        case SetRoleID.SetMercenary:
                            Mercenary.Role = player;
                            break;
                        case SetRoleID.SetCopyCat:
                            CopyCat.Role = player;
                            break;
                        case SetRoleID.SetSurvivor:
                            Survivor.Role = player;
                            break;
                        case SetRoleID.SetRevenger:
                            Revenger.Role = player;
                            break;
                        case SetRoleID.SetAssassin:
                            Assassin.Role = player;
                            break;
                        case SetRoleID.SetVector:
                            Vector.Role = player;
                            break;
                        case SetRoleID.SetMorphling:
                            Morphling.Role = player;
                            break;
                        case SetRoleID.SetScrambler:
                            Scrambler.Role = player;
                            break;
                        case SetRoleID.SetBarghest:
                            Barghest.Role = player;
                            break;
                        case SetRoleID.SetGhost:
                            Ghost.Role = player;
                            break;
                        case SetRoleID.SetSorcerer:
                            Sorcerer.Role = player;
                            break;
                        case SetRoleID.SetGuesser:
                            Guesser.Role = player;
                            break;
                        case SetRoleID.SetMesmer:
                            Mesmer.Role = player;
                            break;
                        case SetRoleID.SetBasilisk:
                            Basilisk.Role = player;
                            break;
                        case SetRoleID.SetReaper:
                            Reaper.Role = player;
                            break;
                        case SetRoleID.SetSaboteur:
                            Saboteur.Role = player;
                            break;
                        case SetRoleID.SetImpostor1:
                            Impostor1.Role = player;
                            break;
                        case SetRoleID.SetImpostor2:
                            Impostor2.Role = player;
                            break;
                        case SetRoleID.SetImpostor3:
                            Impostor3.Role = player;
                            break;
                    }
                }
        }
        // Main Controls


        public static void versionHandshake(int major, int minor, int build, int revision, Guid guid, int clientId)
        {
            System.Version ver;
            if (revision < 0)
                ver = new System.Version(major, minor, build);
            else
                ver = new System.Version(major, minor, build, revision);
            GameStartManagerPatch.playerVersions[clientId] = new GameStartManagerPatch.PlayerVersion(ver, guid);
        }
        public static void syncTimer(float TimerSyncro)
        {

            /** - This part of the code is not open source **/


        }
        public static void syncDie(byte Player)
        {

            /** - This part of the code is not open source **/

        }
        public static void syncEmergency(int Emergency)
        {

            /** - This part of the code is not open source **/

        }

        public static void uncheckedMurderPlayer(byte sourceId, byte targetId, byte showAnimation)
        {
            PlayerControl source = Helpers.playerById(sourceId);
            PlayerControl target = Helpers.playerById(targetId);
            if (source != null && target != null)
            {
                if (showAnimation == 0) KillAnimationCoPerformKillPatch.hideNextAnimation = true;
                source.MurderPlayer(target);
            }
        }
        public static void uncheckedCmdReportDeadBody(byte sourceId, byte targetId)
        {
            PlayerControl source = Helpers.playerById(sourceId);
            var t = targetId == Byte.MaxValue ? null : Helpers.playerById(targetId).Data;
            if (source != null) source.ReportDeadBody(t);
        }
        public static void useUncheckedVent(int ventId, byte playerId, byte isEnter)
        {
            PlayerControl player = Helpers.playerById(playerId);
            if (player == null) return;
            MessageReader reader = new MessageReader();
            byte[] bytes = BitConverter.GetBytes(ventId);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            reader.Buffer = bytes;
            reader.Length = bytes.Length;

            player.MyPhysics.HandleRpc(isEnter != 0 ? (byte)19 : (byte)20, reader);
        }
        public static void ShareOptions(int numberOfOptions, MessageReader reader)
        {
            try
            {
                for (int i = 0; i < numberOfOptions; i++)
                {
                    uint optionId = reader.ReadPackedUInt32();
                    uint selection = reader.ReadPackedUInt32();
                    CustomOption option = CustomOption.options.FirstOrDefault(option => option.id == (int)optionId);
                    option.updateSelection((int)selection);
                }
            }
            catch (Exception e) { }
        }
        public static void shareReady(string PlayerName)
        {

            /** - This part of the code is not open source **/

        }
        public static void shareNotReady(string PlayerName)
        {

            /** - This part of the code is not open source **/

        }

        public static void shareAllRoles()
        {

            /** - This part of the code is not open source **/

        }
        //WINNER
        public static void setWinLove()
        {

            /** - This part of the code is not open source **/

        }
        public static void setlooseLove()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinCrewmatesByTask()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinCrewmatesByKill()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinImpostorByKill()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinImpostorBySab()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinJester()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinEater()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinOutlaw()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinArsonist()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinCulte()
        {

            /** - This part of the code is not open source **/

        }
        public static void setWinCursed()
        {

            /** - This part of the code is not open source **/

        }

        //ITEM

        //SHERIFF
        public static void sheriff1kill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void sheriff2kill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void sheriff3kill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        //GUARDIAN
        public static void shieldedMurderAttempt()
        {

            /** - This part of the code is not open source **/

        }

        public static void setProtectedPlayer(byte protectedId)
        {


            /** - This part of the code is not open source **/

        }
        public static void setProtectedMystic(byte protectedmysticId)
        {

            /** - This part of the code is not open source **/

        }
        public static void setProtectedCopyMystic()
        {

            /** - This part of the code is not open source **/


        }

        //ENGINEER
        public static void engineerRepair()
        {

            /** - This part of the code is not open source **/


        }

        public static void engineerFixLight()
        {
            SwitchSystem switchSystem = ShipStatus.Instance.Systems[SystemTypes.Electrical].Cast<SwitchSystem>();
            switchSystem.ActualSwitches = switchSystem.ExpectedSwitches;
        }

        //TIMELORD

        public static void timeStop_Start(int WhoStopTime)
        {

            /** - This part of the code is not open source **/

        }

        public static void timeStop_End()
        {




            /** - This part of the code is not open source **/


        }
        //HUNTER
        public static void setTrackedPlayer(byte TrackedId)
        {

            /** - This part of the code is not open source **/



        }
        public static void hunterTrackedDie()
        {

            /** - This part of the code is not open source **/

        }
        public static void hunterTrackedKill()
        {

            /** - This part of the code is not open source **/

        }
        public static void setCopyTrackedPlayer(byte CopyTrackedId)
        {

            /** - This part of the code is not open source **/


        }
        public static void hunterCopyTrackedDie()
        {

            /** - This part of the code is not open source **/

        }
        public static void hunterCopyTrackedKill()
        {

            /** - This part of the code is not open source **/

        }

        //MYSTIC 

        public static void mysticShieldOn()
        {

            /** - This part of the code is not open source **/

        }
        public static void mysticShieldOff()
        {

            /** - This part of the code is not open source **/

        }


        //SPIRIT
        public static void spiritRevive()
        {

            /** - This part of the code is not open source **/



        }
        public static void copyCatRevive()
        {

            /** - This part of the code is not open source **/


        }
        //MAYOR
        public static void mayorBuzz()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                if (!Mayor.Role.Data.IsDead)
                {
                    MeetingRoomManager.Instance.reporter = Mayor.Role;
                    MeetingRoomManager.Instance.target = null;
                    DestroyableSingleton<HudManager>.Instance.OpenMeetingRoom(Mayor.Role);
                    Mayor.Role.RpcStartMeeting(null);
                    Mayor.BuzzUsed = true;
                    GLMod.GLMod.currentGame.addAction(Mayor.Role.Data.PlayerName, "", "buzz_used");
                }
                else
                {
                    MeetingRoomManager.Instance.reporter = CopyCat.Role;
                    MeetingRoomManager.Instance.target = null;
                    DestroyableSingleton<HudManager>.Instance.OpenMeetingRoom(CopyCat.Role);
                    CopyCat.Role.RpcStartMeeting(null);
                    Mayor.BuzzUsed = true;
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "buzz_used");

                }
            }
        }
        //DETECTIVE
        public static void detectiveFindFPOn()
        {
            Detective.FindFP = true;

            /** - This part of the code is not open source **/


        }
        public static void detectiveFindFPOff()
        {
            Detective.FindFP = false;
        }
        //NIGHTWATCH
        public static void nightwatchLightOn()
        {


            /** - This part of the code is not open source **/

        }
        public static void nightwatchLightOff()
        {

            /** - This part of the code is not open source **/

        }
        //SPY
        public static void spyOn()
        {

            /** - This part of the code is not open source **/

        }
        public static void spyOff()
        {

            /** - This part of the code is not open source **/



        }

        //INFORMANT
        public static void setInfoPlayer(byte infoId)
        {

            /** - This part of the code is not open source **/


        }
        //MENTALIST
        public static void mentalistColorOn()
        {
            Mentalist.AdminVisibility = true;


            /** - This part of the code is not open source **/

        }
        public static void mentalistColorOff()
        {
            Mentalist.AdminVisibility = false;
            Mentalist.AdminUsed = true;
        }
        //BUILDER
       
        public static void sealVent(int ventId)
        {
            Vent vent = ShipStatus.Instance.AllVents.FirstOrDefault((x) => x != null && x.Id == ventId);
            if (vent == null) return;


            if (PlayerControl.LocalPlayer == Builder.Role || PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 15 && CopyCat.CopyStart)
            {
                PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                animator?.Stop();
                vent.EnterVentAnim = vent.ExitVentAnim = null;
                vent.myRend.sprite = animator == null ? ChallengerMod.Unity.getStaticVentSealedSpriteuse() : ChallengerMod.Unity.getAnimatedVentSealedSpriteuse();
                vent.myRend.color = new Color(1f, 1f, 1f, 0.5f);
                vent.name = "LockedVent_" + vent.name;
            }


            /** - This part of the code is not open source **/


            ventsToSeal.Add(vent);

        }
        //DICTATOR
        public static void dictatorNoSkipVote()
        {
            Dictator.HMActive = true;
            CopyCat.HMActive = true;


            /** - This part of the code is not open source **/

        }
        //SENTINEL
        public static void sentinelScanOn()
        {
           

            /** - This part of the code is not open source **/

        }
        public static void sentinelScanOff()
        {


            /** - This part of the code is not open source **/

        }
        //JESTER
        public static void jesterFakeKill()
        {

            /** - This part of the code is not open source **/

        }
        public static void jesterWin()
        {

            /** - This part of the code is not open source **/

        }

        //EATER
        public static void cleanBody(byte playerId)
        {
            DeadBody[] array = UnityEngine.Object.FindObjectsOfType<DeadBody>();
            for (int i = 0; i < array.Length; i++)
            {
                if (GameData.Instance.GetPlayerById(array[i].ParentId).PlayerId == playerId)
                {
                    UnityEngine.Object.Destroy(array[i].gameObject);
                    ChallengerMod.Set.Data.EaterTask += 1;
                    new EaterMark(999f, Eater.Role);
                    GLMod.GLMod.currentGame.addAction(Eater.Role.Data.PlayerName, "", "player_eated");

                }
            }
        }

        //CUPID
        public static void setLover1(byte loved1Id)
        {

            /** - This part of the code is not open source **/

        }
        public static void setLover2(byte loved2Id)
        {

            /** - This part of the code is not open source **/

        }

        public static void loversExiled()
        {

            /** - This part of the code is not open source **/

        }
        public static void killLover1()
        {

            /** - This part of the code is not open source **/

        }
        public static void killLover2()
        {

            /** - This part of the code is not open source **/

        }

        //CULTIST
        public static void setCulte1Player(byte culted1Id)
        {

            /** - This part of the code is not open source **/

        }
        public static void setCulte2Player(byte culted2Id)
        {

            /** - This part of the code is not open source **/

        }
        public static void setCulte3Player(byte culted3Id)
        {

            /** - This part of the code is not open source **/

        }
        public static void cultistDie()
        {

            /** - This part of the code is not open source **/

        }

        //EATER
        public static void draggBody(int Get)
        {
            var body = ChallengerMod.Utils.Helpers.GetDeadBody(Get);
            if (body != null)
            {
                ChallengerMod.Challenger.draggers.Add(Eater.Role.PlayerId);
                ChallengerMod.Challenger.corpse.Add(body.ParentId);
                MoveBody(body.ParentId);
            }
        }
        public static void dropBody(int Get)
        {
            ChallengerMod.Challenger.corpse.Remove(ChallengerMod.Challenger.corpse[ChallengerMod.Challenger.draggers.IndexOf(Eater.Role.PlayerId)]);
            ChallengerMod.Challenger.draggers.Remove(Eater.Role.PlayerId);
        }
        public static void MoveBody(int bodyid)
        {
            if (Eater.Role.transform == null) return;
            if (draggers.Contains(Eater.Role.PlayerId))
            {
                var body = ChallengerMod.Utils.Helpers.GetDeadBody(bodyid);
                if (body == null) return;
                if (!Eater.Role.inVent)
                {
                    var pos = Eater.Role.transform.position;
                    pos.Set(pos.x, pos.y, pos.z + .001f);
                    body.transform.position = (Vector3.Lerp(ChallengerMod.Utils.Helpers.GetDeadBody(corpse[(draggers.IndexOf(Eater.Role.PlayerId))]).transform.position, pos, Time.deltaTime + 0.05f));
                }
                else
                    body.transform.position = (Eater.Role.transform.position);
                return;
            }
        }


        //COPYCAT
        public static void setCopyPlayer(byte TargerID, int CopyID)
        {

            /** - This part of the code is not open source **/




        }
        public static void copyCatDie()
        {

            /** - This part of the code is not open source **/

        }
        public static void copyCatKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        //OUTLAW
        public static void outlawKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }

        //ARSONIST
        public static void arsonistWin()
        {


            /** - This part of the code is not open source **/



        }
        public static void arsonistAddOil(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        //CURSE
        public static void cursedWin()
        {


            /** - This part of the code is not open source **/



        }
        public static void curseSync(int percentValue)
        {

            /** - This part of the code is not open source **/

        }

        //MERCENARY
        public static void mercenaryKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void mercenaryTryKill()
        {


            /** - This part of the code is not open source **/


        }
        //REVENGER

        public static void setEMP1Player(byte EMP1Id)
        {

            /** - This part of the code is not open source **/



        }
        public static void setEMP2Player(byte EMP2Id)
        {

            /** - This part of the code is not open source **/



        }
        public static void setEMP3Player(byte EMP3Id)
        {

            /** - This part of the code is not open source **/




        }
        public static void sabAdmin()
        {

            /** - This part of the code is not open source **/


        }

        //SORCERER

        public static void setScan1Player(byte Scan1Id)
        {

            /** - This part of the code is not open source **/


        }
        public static void setScan2Player(byte Scan2Id)
        {

            /** - This part of the code is not open source **/


        }
        public static void setExtPlayer(byte Scan3Id)
        {

            /** - This part of the code is not open source **/



        }

        //VECTOR
        public static void setInfectePlayer(byte InfectId)
        {

            /** - This part of the code is not open source **/


        }
        public static void killInfected()
        {

            /** - This part of the code is not open source **/

        }
        //MORPHLING

        public static void setMorphPlayer(byte ScanId)
        {

            /** - This part of the code is not open source **/


        }
        public static void morphOn()
        {
            Morphling.Morphed = true;

            /** - This part of the code is not open source **/


            if (ComSab && StartComSabUnk)
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 7, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 6, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                }
            }
            if (!ComSab || (ComSab && !StartComSabUnk))
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 7, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setLook(Morphling.Morph.Data.PlayerName, Morphling.Morph.Data.DefaultOutfit.ColorId, Morphling.Morph.Data.DefaultOutfit.HatId, Morphling.Morph.Data.DefaultOutfit.VisorId, Morphling.Morph.Data.DefaultOutfit.SkinId, Morphling.Morph.Data.DefaultOutfit.PetId);
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
            }
        }
        public static void morphOff()
        {
            Morphling.Morphed = false;

            if (ComSab && StartComSabUnk)
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 7, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 6, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                }
            }
            if (!ComSab || (ComSab && !StartComSabUnk))
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 7, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setDefaultLook();
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
            }
        }
        //SCRAMBLER
        public static void camoOn()
        {

            /** - This part of the code is not open source **/


            foreach (PlayerControl players in PlayerControl.AllPlayerControls)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                    players.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 7, "", "", "", "");
                }
            }
        }
        public static void camoOff()
        {

            /** - This part of the code is not open source **/

            foreach (PlayerControl players in PlayerControl.AllPlayerControls)
            {
                if (ComSab && CommsSabotageAnonymous.getSelection() == 1)
                {
                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                    players.setLook(ChallengerMod.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 6, "", "", "", "");
                }
                else
                {
                    if (Morphling.Role != null && Morphling.Morph != null && players.PlayerId == Morphling.Role.PlayerId && Morphling.Morphed)
                    {
                        players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                        players.setLook(Morphling.Morph.Data.PlayerName, Morphling.Morph.Data.DefaultOutfit.ColorId, Morphling.Morph.Data.DefaultOutfit.HatId, Morphling.Morph.Data.DefaultOutfit.VisorId, Morphling.Morph.Data.DefaultOutfit.SkinId, Morphling.Morph.Data.DefaultOutfit.PetId);
                    }
                    else
                    {
                        players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                        players.setDefaultLook();
                    }
                }
            }
        }
        //BARGHEST

        public static void createVent(byte[] buff)
        {
            Vector3 position = Vector3.zero;
            position.x = BitConverter.ToSingle(buff, 0 * sizeof(float));
            position.y = BitConverter.ToSingle(buff, 1 * sizeof(float));
            new BarghestVentObject(position);
            GLMod.GLMod.currentGame.addAction(Barghest.Role.Data.PlayerName, "", "vent_create");
        }
        public static void shadowOn()
        {

            /** - This part of the code is not open source **/



        }
        public static void shadowOff()
        {

            /** - This part of the code is not open source **/


        }
        //GHOST
        public static void ghostOn()
        {

            /** - This part of the code is not open source **/

        }
        public static void ghostOff()
        {

            /** - This part of the code is not open source **/

        }
        //SORCERER
        public static void war1()
        {

            /** - This part of the code is not open source **/

        }
        public static void war2()
        {

            /** - This part of the code is not open source **/

        }
        public static void war3()
        {

            /** - This part of the code is not open source **/

        }
        public static void war4()
        {

            /** - This part of the code is not open source **/

        }
        //GUESSER

        public static void guesserShoot(byte playerId)
        {
            PlayerControl target = Helpers.playerById(playerId);
            if (target == null)
            {
                return;
            }

            /** - This part of the code is not open source **/

            target.Exiled();
            PlayerControl partner = target.getPartner(); // Lover check
            byte partnerId = partner != null ? partner.PlayerId : playerId;
            Guesser.remainingShots = Mathf.Max(0, Guesser.remainingShots - 1);
            
            if (MeetingHud.Instance)
            {
                foreach (PlayerVoteArea pva in MeetingHud.Instance.playerStates)
                {
                    if (pva.TargetPlayerId == playerId || pva.TargetPlayerId == partnerId)
                    {
                        pva.SetDead(pva.DidReport, true);
                        pva.Overlay.gameObject.SetActive(true);
                    }
                }
                if (AmongUsClient.Instance.AmHost)
                    MeetingHud.Instance.CheckForEndVoting();
            }
            if (HudManager.Instance != null && Guesser.Role != null)
                if (PlayerControl.LocalPlayer == target)
                    HudManager.Instance.KillOverlay.ShowKillAnimation(Guesser.Role.Data, target.Data);
                else if (partner != null && PlayerControl.LocalPlayer == partner && Loverdie.getBool() == true)
                    HudManager.Instance.KillOverlay.ShowKillAnimation(partner.Data, partner.Data);
                else
                    SoundManager.Instance.PlaySound(SoulTake, false, 100f);
        }

        public static void guesserFail(byte playerId)
        {
            
            PlayerControl target = Helpers.playerById(playerId);
            if (target == null)
            {
                return;
            }

            /** - This part of the code is not open source **/

            PlayerControl partner = target.getPartner(); // Lover check
            byte partnerId = partner != null ? partner.PlayerId : playerId;
            Guesser.remainingShots = Mathf.Max(0, Guesser.remainingShots - 1);
           
            if (MeetingHud.Instance)
            {
                foreach (PlayerVoteArea pva in MeetingHud.Instance.playerStates)
                {
                    if (pva.TargetPlayerId == playerId || pva.TargetPlayerId == partnerId)
                    {
                        
                    }
                }
                
            }
            if (HudManager.Instance != null && Guesser.Role != null)

                SoundManager.Instance.PlaySound(SoulTake, false, 100f);
            GuesserNotDie = false;
        }

        public static void setPetrifyPlayer(byte petrifyId)
        {

            /** - This part of the code is not open source **/

        }
        public static void setPetrifyAndShieldPlayer(byte petrifyId)
        {

            /** - This part of the code is not open source **/

        }


        //IMPOSTORS NORMAL KILL

        public static void vectorKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void impostor1Kill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void impostor2Kill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void impostor3Kill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void morphlingKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void scramblerKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void barghestKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void ghostKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void sorcererKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void guesserKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void basiliskKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void reaperKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void saboteurKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void assassinKill(byte targetId)
        {

            /** - This part of the code is not open source **/

        }
        public static void assassinShield()
        {

            /** - This part of the code is not open source **/

        }



    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.HandleRpc))]
    class HandleRpcPatch
    {
        static void Postfix([HarmonyArgument(0)] byte callId, [HarmonyArgument(1)] MessageReader reader)
        {
            byte packetId = callId;
            switch (packetId)
            {

                // Main Controls
                case (byte)CustomRPC.VersionHandshake:
                    byte major = reader.ReadByte();
                    byte minor = reader.ReadByte();
                    byte patch = reader.ReadByte();
                    int versionOwnerId = reader.ReadPackedInt32();
                    byte revision = 0xFF;
                    Guid guid;
                    if (reader.Length - reader.Position >= 17)
                    { // enough bytes left to read
                        revision = reader.ReadByte();
                        // GUID
                        byte[] gbytes = reader.ReadBytes(16);
                        guid = new Guid(gbytes);
                    }
                    else
                    {
                        guid = new Guid(new byte[16]);
                    }
                    RPCProcedure.versionHandshake(major, minor, patch, revision == 0xFF ? -1 : revision, guid, versionOwnerId);
                    break;
                case (byte)CustomRPC.ShareOptions:
                    RPCProcedure.ShareOptions((int)reader.ReadPackedUInt32(), reader);
                    break;
                case (byte)CustomRPC.ShareReady:
                    {
                        RPCProcedure.shareReady(reader.ReadString());
                        break;
                    }
                case (byte)CustomRPC.ShareNotReady:
                    {
                        RPCProcedure.shareNotReady(reader.ReadString());
                        break;
                    }
                case (byte)CustomRPC.ShareAllRoles:
                    {
                        RPCProcedure.shareAllRoles();
                        break;
                    }
                //NUCLEAR
                case (byte)CustomRPC.SyncTimer:
                    {
                        float TimerSyncro = reader.ReadSingle();
                        RPCProcedure.syncTimer(TimerSyncro);
                        break;
                    }
                case (byte)CustomRPC.SyncDie:
                    {
                        byte Player = reader.ReadByte();
                        RPCProcedure.syncDie(Player);
                        break;
                    }
                case (byte)CustomRPC.SyncEmergency:
                    {
                        int Emergency = reader.ReadPackedInt32();
                        RPCProcedure.syncEmergency(Emergency);
                        break;
                    }
                case (byte)CustomRPC.RemoveAllBodies:
                    var buggedBodies = UnityEngine.Object.FindObjectsOfType<DeadBody>();
                    foreach (var body in buggedBodies)
                        body.gameObject.Destroy();
                    break;
                case (byte)CustomRPC.UncheckedMurderPlayer:
                    byte source = reader.ReadByte();
                    byte target = reader.ReadByte();
                    byte showAnimation = reader.ReadByte();
                    RPCProcedure.uncheckedMurderPlayer(source, target, showAnimation);
                    break;
                case (byte)CustomRPC.UncheckedCmdReportDeadBody:
                    byte reportSource = reader.ReadByte();
                    byte reportTarget = reader.ReadByte();
                    RPCProcedure.uncheckedCmdReportDeadBody(reportSource, reportTarget);
                    break;
                case (byte)CustomRPC.UseUncheckedVent:
                    int ventId = reader.ReadPackedInt32();
                    byte ventingPlayer = reader.ReadByte();
                    byte isEnter = reader.ReadByte();
                    RPCProcedure.useUncheckedVent(ventId, ventingPlayer, isEnter);
                    break;
                case (byte)CustomRPC.SetLocalPlayers:
                    localPlayers.Clear();
                    localPlayer = PlayerControl.LocalPlayer;
                    var localPlayerBytes = reader.ReadBytesAndSize();

                    foreach (byte id in localPlayerBytes)
                    {
                        foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                        {
                            if (player.PlayerId == id) { localPlayers.Add(player); }
                        }
                    }
                    break;

                case (byte)CustomRPC.SetRole:
                    byte roleId = reader.ReadByte();
                    byte playerId = reader.ReadByte();
                    RPCProcedure.setRole(roleId, playerId);
                    break;

                //WINNER
                case (byte)CustomRPC.SetWinLove:
                    {
                        RPCProcedure.setWinLove();
                        break;
                    }
                case (byte)CustomRPC.SetLooseLove:
                    {
                        RPCProcedure.setlooseLove();
                        break;
                    }
                case (byte)CustomRPC.SetWinCrewmatesByTask:
                    {
                        RPCProcedure.setWinCrewmatesByTask();
                        break;
                    }
                case (byte)CustomRPC.SetWinCrewmatesByKill:
                    {
                        RPCProcedure.setWinCrewmatesByKill();
                        break;
                    }
                case (byte)CustomRPC.SetWinImpostorsByKill:
                    {
                        RPCProcedure.setWinImpostorByKill();
                        break;
                    }
                case (byte)CustomRPC.SetWinImpostorsBySab:
                    {
                        RPCProcedure.setWinImpostorBySab();
                        break;
                    }
                case (byte)CustomRPC.SetWinJester:
                    {
                        RPCProcedure.setWinJester();
                        break;
                    }
                case (byte)CustomRPC.SetWinEater:
                    {
                        RPCProcedure.setWinEater();
                        break;
                    }
                case (byte)CustomRPC.SetWinOutlaw:
                    {
                        RPCProcedure.setWinOutlaw();
                        break;
                    }
                case (byte)CustomRPC.SetWinArsonist:
                    {
                        RPCProcedure.setWinArsonist();
                        break;
                    }
                case (byte)CustomRPC.SetWinCulte:
                    {
                        RPCProcedure.setWinCulte();
                        break;
                    }
                case (byte)CustomRPC.SetWinCursed:
                    {
                        RPCProcedure.setWinCursed();
                        break;
                    }

                //ITEMS
                case (byte)CustomRPC.SpawnItem:

                /** - This part of the code is not open source **/

                case (byte)CustomRPC.DestroyItem:

                /** - This part of the code is not open source **/



                //SHERIFF
                case (byte)CustomRPC.Sheriff1Kill:
                    {
                        RPCProcedure.sheriff1kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Sheriff2Kill:
                    {
                        RPCProcedure.sheriff2kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Sheriff3Kill:
                    {
                        RPCProcedure.sheriff3kill(reader.ReadByte());
                        break;
                    }

                //GUARDIAN
                case (byte)CustomRPC.ShieldedMurderAttempt:
                    {
                        RPCProcedure.shieldedMurderAttempt();
                        break;
                    }
                case (byte)CustomRPC.SetProtectedPlayer:
                    {
                        RPCProcedure.setProtectedPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetProtectedMystic:
                    {
                        RPCProcedure.setProtectedMystic(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetProtectedCopyMystic:
                    {
                        RPCProcedure.setProtectedCopyMystic();
                        break;
                    }
                //ENGINEER
                case (byte)CustomRPC.EngineerRepair:
                    {
                        RPCProcedure.engineerRepair();
                        break;
                    }
                case (byte)CustomRPC.EngineerFixLight:
                    {
                        RPCProcedure.engineerFixLight();
                        break;
                    }
                case (byte)CustomRPC.TimeStop_Start:
                    {
                        RPCProcedure.timeStop_Start(reader.ReadInt32());
                        break;
                    }
                case (byte)CustomRPC.TimeStop_End:
                    {
                        RPCProcedure.timeStop_End();
                        break;
                    }
                //HUNTER
                case (byte)CustomRPC.SetTrackedPlayer:
                    {
                        RPCProcedure.setTrackedPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.HunterTrackedDie:
                    {
                        RPCProcedure.hunterTrackedDie();
                        break;
                    }

                case (byte)CustomRPC.HunterTrackedKill:
                    {
                        RPCProcedure.hunterTrackedKill();
                        break;
                    }
                case (byte)CustomRPC.SetCopyTrackedPlayer:
                    {
                        RPCProcedure.setCopyTrackedPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.HunterCopyTrackedDie:
                    {
                        RPCProcedure.hunterCopyTrackedDie();
                        break;
                    }

                case (byte)CustomRPC.HunterCopyTrackedKill:
                    {
                        RPCProcedure.hunterCopyTrackedKill();
                        break;
                    }
                //MYSTIC
                case (byte)CustomRPC.MysticShieldOn:
                    {
                        RPCProcedure.mysticShieldOn();
                        break;
                    }
                case (byte)CustomRPC.MysticShieldOff:
                    {
                        RPCProcedure.mysticShieldOff();
                        break;
                    }

                //SPIRIT
                case (byte)CustomRPC.SpiritRevive:
                    {
                        RPCProcedure.spiritRevive();
                        break;
                    }
                case (byte)CustomRPC.CopyCatRevive:
                    {
                        RPCProcedure.copyCatRevive();
                        break;
                    }
                //MAYOR
                case (byte)CustomRPC.MayorBuzz:
                    {
                        RPCProcedure.mayorBuzz();
                        break;
                    }
                //DETECTIVE
                case (byte)CustomRPC.DetectiveFindFPOn:
                    {
                        RPCProcedure.detectiveFindFPOn();
                        break;
                    }
                case (byte)CustomRPC.DetectiveFindFPOff:
                    {
                        RPCProcedure.detectiveFindFPOff();
                        break;
                    }
                //NIGHTWATCH
                case (byte)CustomRPC.NightwatchLightOn:
                    {
                        RPCProcedure.nightwatchLightOn();
                        break;
                    }
                case (byte)CustomRPC.NightwatchLightOff:
                    {
                        RPCProcedure.nightwatchLightOff();
                        break;
                    }
                //SPY
                case (byte)CustomRPC.SpyOn:
                    {
                        RPCProcedure.spyOn();
                        break;
                    }
                case (byte)CustomRPC.SpyOff:
                    {
                        RPCProcedure.spyOff();
                        break;
                    }
                //INFORMANT
                case (byte)CustomRPC.SetInfoPlayer:
                    {
                        RPCProcedure.setInfoPlayer(reader.ReadByte());
                        break;
                    }
                //MENTALIST
                case (byte)CustomRPC.MentalistColorOn:
                    {
                        RPCProcedure.mentalistColorOn();
                        break;
                    }
                case (byte)CustomRPC.MentalistColorOff:
                    {
                        RPCProcedure.mentalistColorOff();
                        break;
                    }
                //BUILDER
                case (byte)CustomRPC.SealVent:
                    RPCProcedure.sealVent(reader.ReadPackedInt32());
                    break;

                //DICTATOR
                case (byte)CustomRPC.DictatorNoSkipVote:
                    {
                        RPCProcedure.dictatorNoSkipVote();
                        break;
                    }


                //SENTINEL
                case (byte)CustomRPC.SentinelScanOn:
                    {
                        RPCProcedure.sentinelScanOn();
                        break;
                    }
                case (byte)CustomRPC.SentinelScanOff:
                    {
                        RPCProcedure.sentinelScanOff();
                        break;
                    }
                //JESTER
                case (byte)CustomRPC.JesterFakeKill:
                    {
                        RPCProcedure.jesterFakeKill();
                        break;
                    }
                case (byte)CustomRPC.JesterWin:
                    {
                        RPCProcedure.jesterWin();
                        break;
                    }
                
                //EATER
                case (byte)CustomRPC.CleanBody:
                    {
                        RPCProcedure.cleanBody(reader.ReadByte());
                        break;
                    }
                //CUPID
                case (byte)CustomRPC.SetLover1:
                    {
                        RPCProcedure.setLover1(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetLover2:
                    {
                        RPCProcedure.setLover2(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.LoversExiled:
                    {
                        RPCProcedure.loversExiled();
                        break;
                    }
                case (byte)CustomRPC.KillLover1:
                    {
                        RPCProcedure.killLover1();
                        break;
                    }
                case (byte)CustomRPC.KillLover2:
                    {
                        RPCProcedure.killLover2();
                        break;
                    }
                //CULTIST
                case (byte)CustomRPC.SetCulte1Player:
                    {
                        RPCProcedure.setCulte1Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetCulte2Player:
                    {
                        RPCProcedure.setCulte2Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetCulte3Player:
                    {
                        RPCProcedure.setCulte3Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.CultistDie:
                    {
                        RPCProcedure.cultistDie();
                        break;
                    }
                //Eater
                case (byte)CustomRPC.DraggBody:
                    {
                        RPCProcedure.draggBody(reader.ReadPackedInt32());

                        break;
                    } 
                case (byte)CustomRPC.DropBody:
                    {
                        RPCProcedure.dropBody(reader.ReadPackedInt32());
                        break;
                    }


                //OUTLAW
                case (byte)CustomRPC.OutlawKill:
                    {
                        RPCProcedure.outlawKill(reader.ReadByte());
                        break;
                    }
                //ARSONIST
                case (byte)CustomRPC.ArsonistWin:
                    {
                        RPCProcedure.arsonistWin();
                        break;
                    }
                case (byte)CustomRPC.ArsonistAddOil:
                    {
                        RPCProcedure.arsonistAddOil(reader.ReadByte());
                        break;
                    }
                //CURSED
                case (byte)CustomRPC.CursedWin:
                    {
                        RPCProcedure.cursedWin();
                        break;
                    }
                case (byte)CustomRPC.CurseSync:
                    RPCProcedure.curseSync(reader.ReadPackedInt32());
                    break;

                //MERCENARY
                case (byte)CustomRPC.MercenaryKill:
                    {
                        RPCProcedure.mercenaryKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.MercenaryTryKill:
                    {
                        RPCProcedure.mercenaryTryKill();
                        break;
                    }
                //COPYCAT
                case (byte)CustomRPC.SetCopyPlayer:
                    {
                        byte copyPlayer = reader.ReadByte();
                        int copyID = reader.ReadInt32();
                        RPCProcedure.setCopyPlayer(copyPlayer, copyID);
                        break;
                    }
                case (byte)CustomRPC.CopyCatDie:
                    {
                        RPCProcedure.copyCatDie();
                        break;
                    }
                case (byte)CustomRPC.CopyCatKill:
                    {
                        RPCProcedure.copyCatKill(reader.ReadByte());
                        break;
                    }

                //REVENGER
                case (byte)CustomRPC.SetEMP1Player:
                    {
                        RPCProcedure.setEMP1Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetEMP2Player:
                    {
                        RPCProcedure.setEMP2Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetEMP3Player:
                    {
                        RPCProcedure.setEMP3Player(reader.ReadByte());
                        break;
                    }
                //SORCERER
                case (byte)CustomRPC.SetScan1Player:
                    {
                        RPCProcedure.setScan1Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetScan2Player:
                    {
                        RPCProcedure.setScan2Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetExtPlayer:
                    {
                        RPCProcedure.setExtPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SabAdmin:
                    {
                        RPCProcedure.sabAdmin();
                        break;
                    }

                //VECTOR
                case (byte)CustomRPC.SetInfectePlayer:
                    {
                        RPCProcedure.setInfectePlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.KillInfected:
                    {
                        RPCProcedure.killInfected();
                        break;
                    }
                    
                //MORPHLING
                case (byte)CustomRPC.SetMorphPlayer:
                    {
                        RPCProcedure.setMorphPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.MorphOn:
                    {
                        RPCProcedure.morphOn();
                        break;
                    }
                case (byte)CustomRPC.MorphOff:
                    {
                        RPCProcedure.morphOff();
                        break;
                    }
                //SCRAMBLER
                case (byte)CustomRPC.CamoOn:
                    {
                        RPCProcedure.camoOn();
                        break;
                    }
                case (byte)CustomRPC.CamoOff:
                    {
                        RPCProcedure.camoOff();
                        break;
                    }
                //BARGHEST
                case (byte)CustomRPC.CreateVent:
                    {
                        RPCProcedure.createVent(reader.ReadBytesAndSize());
                        break;
                    }
                case (byte)CustomRPC.ShadowOn:
                    {
                        RPCProcedure.shadowOn();
                        break;
                    }
                case (byte)CustomRPC.ShadowOff:
                    {
                        RPCProcedure.shadowOff();
                        break;
                    }
                //GHOST
                case (byte)CustomRPC.GhostOn:
                    {
                        RPCProcedure.ghostOn();
                        break;
                    }
                case (byte)CustomRPC.GhostOff:
                    {
                        RPCProcedure.ghostOff();
                        break;
                    }
                //SORCERER
                case (byte)CustomRPC.War1:
                    {
                        RPCProcedure.war1();
                        break;
                    }
                case (byte)CustomRPC.War2:
                    {
                        RPCProcedure.war2();
                        break;
                    }
                case (byte)CustomRPC.War3:
                    {
                        RPCProcedure.war3();
                        break;
                    }
                case (byte)CustomRPC.War4:
                    {
                        RPCProcedure.war4();
                        break;
                    }
                    //GUESSSER
                case (byte)CustomRPC.GuesserShoot:
                    {
                        RPCProcedure.guesserShoot(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.GuesserFail:
                    {
                        RPCProcedure.guesserFail(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetPetrifyPlayer:
                    {
                        RPCProcedure.setPetrifyPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetPetrifyAndShieldPlayer:
                    {
                        RPCProcedure.setPetrifyAndShieldPlayer(reader.ReadByte());
                        break;
                    }
                //IMPOSTORS KILL NORMAL
                case (byte)CustomRPC.VectorKill:
                    {
                        RPCProcedure.vectorKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Impostor1Kill:
                    {
                        RPCProcedure.impostor1Kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Impostor2Kill:
                    {
                        RPCProcedure.impostor2Kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Impostor3Kill:
                    {
                        RPCProcedure.impostor3Kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.MorphlingKill:
                    {
                        RPCProcedure.morphlingKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.ScramblerKill:
                    {
                        RPCProcedure.scramblerKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.BarghestKill:
                    {
                        RPCProcedure.barghestKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.GhostKill:
                    {
                        RPCProcedure.ghostKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SorcererKill:
                    {
                        RPCProcedure.sorcererKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.GuesserKill:
                    {
                        RPCProcedure.guesserKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.BasiliskKill:
                    {
                        RPCProcedure.basiliskKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.ReaperKill:
                    {
                        RPCProcedure.reaperKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SaboteurKill:
                    {
                        RPCProcedure.saboteurKill(reader.ReadByte());
                        break;
                    }
                   
                    //ASSASSIN
                case (byte)CustomRPC.AssassinKill:
                    {
                        RPCProcedure.assassinKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.AssassinShield:
                    {
                        RPCProcedure.assassinShield();
                        break;
                    }

            }
        }
    }
}

