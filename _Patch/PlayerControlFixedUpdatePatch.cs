using HarmonyLib;
using Hazel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using ChallengerMod.RPC;

namespace ChallengerMod.Patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public static class PlayerControlFixedUpdatePatch
    {

        static PlayerControl setTarget(bool onlyCrewmates = false, bool targetPlayersInVents = false, List<PlayerControl> untargetablePlayers = null, PlayerControl targetingPlayer = null)
        {
            PlayerControl result = null;
            float num = GameOptionsData.KillDistances[Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)];
            if (Sheriff1.Role != null && PlayerControl.LocalPlayer == Sheriff1.Role && (SherifKillRange.getSelection() == 1))
            {
               num = (GameOptionsData.KillDistances[Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)]) * 1.20f;
            }
            else if (Sheriff2.Role != null && PlayerControl.LocalPlayer == Sheriff2.Role && (SherifKillRange.getSelection() == 1))
            {
                num = (GameOptionsData.KillDistances[Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)]) * 1.20f;
            }
            else if (Sheriff3.Role != null && PlayerControl.LocalPlayer == Sheriff3.Role && (SherifKillRange.getSelection() == 1))
            {
                num = (GameOptionsData.KillDistances[Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)]) * 1.20f;
            }
            else if (Outlaw.Role != null && PlayerControl.LocalPlayer == Outlaw.Role && (OutlawKillRange.getSelection() == 1))
            {
                num = (GameOptionsData.KillDistances[Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)]) * 1.20f;
            }
            /** - This part of the code is not open source **/

            if (!ShipStatus.Instance) return result;
            if (targetingPlayer == null) targetingPlayer = PlayerControl.LocalPlayer;
            if (targetingPlayer.Data.IsDead) return result;

            Vector2 truePosition = targetingPlayer.GetTruePosition();
            Il2CppSystem.Collections.Generic.List<GameData.PlayerInfo> allPlayers = GameData.Instance.AllPlayers;
            for (int i = 0; i < allPlayers.Count; i++)
            {
                GameData.PlayerInfo playerInfo = allPlayers[i];
                if (!playerInfo.Disconnected && playerInfo.PlayerId != targetingPlayer.PlayerId && !playerInfo.IsDead && (!onlyCrewmates || !playerInfo.Role.IsImpostor))
                {
                    PlayerControl @object = playerInfo.Object;
                    if (untargetablePlayers != null && untargetablePlayers.Any(x => x == @object))
                    {
                        continue;
                    }

                    if (@object && (!@object.inVent || targetPlayersInVents))
                    {
                        Vector2 vector = @object.GetTruePosition() - truePosition;
                        float magnitude = vector.magnitude;
                        if (magnitude <= num && !PhysicsHelpers.AnyNonTriggersBetween(truePosition, vector.normalized, magnitude, Constants.ShipAndObjectsMask))
                        {
                            result = @object;
                            num = magnitude;
                        }
                    }
                }
            }
            return result;
        }

        static void setPlayerOutline(PlayerControl target, Color color)
        {
            if (target == null || target.cosmetics.currentBodySprite.BodySprite == null)
            {
                target.cosmetics.currentBodySprite.BodySprite.material.SetFloat("_Outline", 0f);
            }
            else
            {
                target.cosmetics.currentBodySprite.BodySprite.material.SetFloat("_Outline", 1f);
                target.cosmetics.currentBodySprite.BodySprite.material.SetColor("_OutlineColor", color);
            }
        }
        static void setBasePlayerOutlines()
        {
            foreach (PlayerControl target in PlayerControl.AllPlayerControls)
            {
                if (target == null || target.cosmetics.currentBodySprite.BodySprite == null) continue;

                bool hasVisibleShield = false;
                bool hasVisibleMorph = false;

                if (target == Guardian.Protected || target == Guardian.ProtectedMystic)
                {
                    hasVisibleShield = (Mystic.Role == null || Mystic.Role != null && Mystic.Role != PlayerControl.LocalPlayer) &&
                        ((PlayerControl.LocalPlayer == Guardian.Role) 
                        || (GuardianShieldVisibility.getBool() == true && (PlayerControl.LocalPlayer == Guardian.Protected || PlayerControl.LocalPlayer == Guardian.Role))
                        || (GuardianShieldVisibilitytry.getSelection() == 0 && (Guardian.shieldattempt == true))
                        || (GuardianShieldVisibility.getBool() == false && GuardianShieldVisibilitytry.getSelection() == 1 && (Guardian.shieldattempt == true) && (PlayerControl.LocalPlayer == Guardian.Protected || PlayerControl.LocalPlayer == Guardian.Role))
                        ); 
                }
                if (target == Morphling.Morph)
                {
                    hasVisibleMorph = (PlayerControl.LocalPlayer == Morphling.Role);
                }
                if (hasVisibleShield)
                {
                    target.cosmetics.currentBodySprite.BodySprite.material.SetFloat("_Outline", 1f);
                    target.cosmetics.currentBodySprite.BodySprite.material.SetColor("_OutlineColor", ChallengerMod.ColorTable.GuardianColor);
                }
                else if (hasVisibleMorph)
                {
                    target.cosmetics.currentBodySprite.BodySprite.material.SetFloat("_Outline", 1f);
                    target.cosmetics.currentBodySprite.BodySprite.material.SetColor("_OutlineColor", ChallengerMod.ColorTable.MorphlingColor);
                }
                else
                {
                    target.cosmetics.currentBodySprite.BodySprite.material.SetFloat("_Outline", 0f);
                }
            }
        }
       
        

        static void ventColorUpdate()
        {
            if (ChallengerMod.Challenger.CanUseVent && ShipStatus.Instance?.AllVents != null)
            {
                foreach (Vent vent in ShipStatus.Instance.AllVents)
                {
                    try
                    {
                        if (vent?.myRend?.material != null)
                        {
                            if (Engineer.Role != null && Engineer.Role.inVent || Bait.Role != null && Bait.Role.inVent)
                            {
                                vent.myRend.material.SetFloat("_Outline", 1f);
                                vent.myRend.material.SetColor("_OutlineColor", CrewmateColor);
                            }
                            else if (Fake.Role != null && Fake.Role.inVent)
                            {
                                vent.myRend.material.SetFloat("_Outline", 1f);
                                vent.myRend.material.SetColor("_OutlineColor", ImpostorColor);
                            }
                            else if (Eater.Role != null && Eater.Role.inVent)
                            {
                                vent.myRend.material.SetFloat("_Outline", 1f);
                                vent.myRend.material.SetColor("_OutlineColor", EaterColor);
                            }
                            
                            else if (vent.myRend.material.GetColor("_AddColor") != Color.red)
                            {
                                vent.myRend.material.SetFloat("_Outline", 0);
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        static void detectiveUpdateFootPrints()
        {
            if ((Detective.Role != null && Detective.Role == PlayerControl.LocalPlayer && !Detective.Role.Data.IsDead) || (CopyCat.Role != null && CopyCat.Role == PlayerControl.LocalPlayer) && CopyCat.copyRole == 9 && CopyCat.CopyStart == true && !CopyCat.Role.Data.IsDead)
            {
                Detective.timer -= Time.fixedDeltaTime;
                if (Detective.timer <= 0f && Detective.FindFP == true)
                {
                    Detective.timer = Detective.footprintIntervall;
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        if (player != null && player != PlayerControl.LocalPlayer && !player.Data.IsDead && !player.inVent)
                        {
                            new Footprint(Detective.footprintDuration, Detective.anonymousFootprints, player);
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        static void assassinFootPrints()
        {
            if (Assassin.Role != null && Assassin.Role == PlayerControl.LocalPlayer && !Assassin.Role.Data.IsDead)
            {
                Detective.timer -= Time.fixedDeltaTime;
                if (Detective.timer <= 0f && Assassin.StealFootPrint == true)
                {
                    Detective.timer = Detective.footprintIntervall;
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        if (player != null && player != PlayerControl.LocalPlayer && !player.Data.IsDead && !player.inVent)
                        {
                            new Footprint(Detective.footprintDuration, Detective.anonymousFootprints, player);
                        }
                    }
                }

            }
            else
            {
                return;
            }
        }

        static void trackerSetTarget()
        {
            if (Hunter.Role != null && Hunter.Tracked != null && Hunter.Role == PlayerControl.LocalPlayer && !Hunter.Role.Data.IsDead)
            {


                Hunter.timer -= Time.fixedDeltaTime;
                if (Hunter.timer <= 0f && Followtrack.getBool() == true)
                {
                    Hunter.timer = Hunter.footprintIntervall;
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        if (player != null && player == Hunter.Tracked && !player.inVent)
                        {
                            new HunterFootprint(Hunter.footprintDuration, true, player);
                        }
                    }
                }
            }
            else if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && Hunter.CopyTracked != null && CopyCat.Role == PlayerControl.LocalPlayer && !CopyCat.Role.Data.IsDead)
            {
                Hunter.timer -= Time.fixedDeltaTime;
                if (Hunter.timer <= 0f && Followtrack.getBool() == true)
                {
                    Hunter.timer = Hunter.footprintIntervall;
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        if (player != null && player == Hunter.CopyTracked && !player.inVent)
                        {
                            new HunterFootprint(Hunter.footprintDuration, true, player);
                        }
                    }
                }

            }
            else
            {
                return;
            }
        }
        static void baitUpdate()
        {
            if (!Bait.active.Any()) return;

            // Bait report
            foreach (KeyValuePair<DeadPlayer, float> entry in new Dictionary<DeadPlayer, float>(Bait.active))
            {
                Bait.active[entry.Key] = entry.Value - Time.fixedDeltaTime;
                if (entry.Value <= 0)
                {
                    Bait.active.Remove(entry.Key);
                    if (entry.Key.killerIfExisting != null && entry.Key.killerIfExisting.PlayerId == PlayerControl.LocalPlayer.PlayerId)
                    {
                        //Helpers.handleVampireBiteOnBodyReport();
                        RPCProcedure.uncheckedCmdReportDeadBody(entry.Key.killerIfExisting.PlayerId, entry.Key.player.PlayerId);
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.UncheckedCmdReportDeadBody, Hazel.SendOption.Reliable, -1);
                        writer.Write(entry.Key.killerIfExisting.PlayerId);
                        writer.Write(entry.Key.player.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                    }
                }
            }
        }
        static void CursedSetTarget()
        {
            if (Cursed.Role == null || Cursed.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Cursed.currentTarget = setTarget();
            if (Cursed.CurseStart == false || Cursed.NoCurse == true || Challenger.LobbyTimeStop == true)
            {
                setPlayerOutline(Cursed.Role, ChallengerMod.ColorTable.GuardianColor);
            }
            else
            {
                if (Cursed.currentTarget != null)
                    setPlayerOutline(Cursed.Role, ChallengerMod.ColorTable.RedColor);
                else
                    setPlayerOutline(Cursed.Role, ChallengerMod.ColorTable.GreenColor);
                
            }
                
        }
        static void Sheriff1SetTarget()
        {
            if (Sheriff1.Role == null || Sheriff1.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Sheriff1.currentTarget = setTarget();
            if (Sheriff1.currentTarget != null)
            setPlayerOutline(Sheriff1.currentTarget, ChallengerMod.ColorTable.SheriffColor);
        }
        static void Sheriff2SetTarget()
        {
            if (Sheriff2.Role == null || Sheriff2.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Sheriff2.currentTarget = setTarget();
            if (Sheriff2.currentTarget != null)
                setPlayerOutline(Sheriff2.currentTarget, ChallengerMod.ColorTable.SheriffColor);
        }
        static void Sheriff3SetTarget()
        {
            if (Sheriff3.Role == null || Sheriff3.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Sheriff3.currentTarget = setTarget();
            if (Sheriff3.currentTarget != null)
                setPlayerOutline(Sheriff3.currentTarget, ChallengerMod.ColorTable.SheriffColor);
        }
        static void GuardianSetTarget()
        {
            if (Guardian.Role == null || Guardian.Role != PlayerControl.LocalPlayer || Guardian.Role == PlayerControl.LocalPlayer && Guardian.ShieldUsed || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Guardian.currentTarget = setTarget();
            if (Guardian.currentTarget != null)
                setPlayerOutline(Guardian.currentTarget, ChallengerMod.ColorTable.GuardianColor);
        }
        static void HunterSetTarget()
        {
            if (Hunter.Role == null || Hunter.Role != PlayerControl.LocalPlayer || Hunter.Role == PlayerControl.LocalPlayer && Hunter.TrackUsed || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Hunter.currentTarget = setTarget();
            if (Hunter.currentTarget != null)
                setPlayerOutline(Hunter.currentTarget, ChallengerMod.ColorTable.HunterColor);
        }
        static void InformantSetTarget()
        {
            if (Informant.Role == null || Informant.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Informant.currentTarget = setTarget();
            if (Informant.currentTarget != null)
                setPlayerOutline(Informant.currentTarget, ChallengerMod.ColorTable.InformantColor);
        }
        public static void BuilderSetTarget()
        {
            if (Builder.Role == null || Builder.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;

            Vent target = null;
            Vector2 truePosition = PlayerControl.LocalPlayer.GetTruePosition();
            float closestDistance = float.MaxValue;
            for (int i = 0; i < ShipStatus.Instance.AllVents.Length; i++)
            {
                Vent vent = ShipStatus.Instance.AllVents[i];
                if (vent.gameObject.name.Contains("SealedVent_") || vent.gameObject.name.Contains("LockedVent_") || vent.gameObject.name.Contains("BarghestVent_")) continue;
                //if (SubmergedCompatibility.IsSubmerged && vent.Id == 9) continue; // cannot seal submergeds exit only vent!
                float distance = Vector2.Distance(vent.transform.position, truePosition);
                if (distance <= vent.UsableDistance && distance < closestDistance)
                {
                    closestDistance = distance;
                    target = vent;
                }
            }
            Builder.ventTarget = target;
        }
        public static void CopyBuilderSetTarget()
        {
            if (CopyCat.Role == null || CopyCat.Role != PlayerControl.LocalPlayer  && CopyCat.copyRole != 15 && !CopyCat.CopyStart || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;

            Vent target = null;
            Vector2 truePosition = PlayerControl.LocalPlayer.GetTruePosition();
            float closestDistance = float.MaxValue;
            for (int i = 0; i < ShipStatus.Instance.AllVents.Length; i++)
            {
                Vent vent = ShipStatus.Instance.AllVents[i];
                if (vent.gameObject.name.Contains("SealedVent_") || vent.gameObject.name.Contains("LockedVent_") || vent.gameObject.name.Contains("BarghestVent_")) continue;
                //if (SubmergedCompatibility.IsSubmerged && vent.Id == 9) continue; // cannot seal submergeds exit only vent!
                float distance = Vector2.Distance(vent.transform.position, truePosition);
                if (distance <= vent.UsableDistance && distance < closestDistance)
                {
                    closestDistance = distance;
                    target = vent;
                }
            }
            CopyCat.ventTarget = target;
        }

        public static void EaterSetTarget()
        {
            if (Eater.Role == null || Eater.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;

            foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance - 2.5f, Constants.PlayersOnlyMask))
            {
                if (collider2D.tag == "DeadBody")
                {
                    DeadBody body = (DeadBody)((Component)collider2D).GetComponent<DeadBody>();
                    Eater.deadbodyTarget = body;
                }
                else { Eater.deadbodyTarget = null; }
            }
            
                
            

        }
        static void DoctorSetTarget()
        {
            if (Doctor.Role == null || Doctor.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Doctor.currentTarget = setTarget();
            if (Doctor.currentTarget != null)
                setPlayerOutline(Doctor.currentTarget, ChallengerMod.ColorTable.DoctorColor);
        }
        static void CupidSetTarget()
        {
            if (Cupid.Role == null || Cupid.Role != PlayerControl.LocalPlayer || Cupid.Role == PlayerControl.LocalPlayer && Cupid.LoveUsed || Cupid.Role == PlayerControl.LocalPlayer && Cupid.Fail || PlayerControl.LocalPlayer.Data.IsDead) return;
            Cupid.currentTarget = setTarget();
            if (Cupid.currentTarget != null)
                setPlayerOutline(Cupid.currentTarget, ChallengerMod.ColorTable.CupidColor);
        }
        static void CultistSetTarget()
        {
            if (Cultist.Role == null || Cultist.Role != PlayerControl.LocalPlayer || Cultist.Role == PlayerControl.LocalPlayer && Cultist.CulteUsed || PlayerControl.LocalPlayer.Data.IsDead) return;
            Cultist.currentTarget = setTarget();
            if (Cultist.currentTarget != null)
                setPlayerOutline(Cultist.currentTarget, ChallengerMod.ColorTable.CulteColor);
        }
        static void OutlawSetTarget()
        {
            if (Outlaw.Role == null || Outlaw.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Outlaw.currentTarget = setTarget();
            if (Outlaw.currentTarget != null)
                setPlayerOutline(Outlaw.currentTarget, ChallengerMod.ColorTable.OutlawColor);
        }
       
        static void ArsonistSetTarget()
        {
            if (Arsonist.Role == null || Arsonist.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Arsonist.currentTarget = setTarget();
            if (Arsonist.currentTarget != null)
                setPlayerOutline(Arsonist.currentTarget, ChallengerMod.ColorTable.ArsonistColor);
        }
        static void MercenarySetTarget()
        {
            if (Mercenary.Role == null || Mercenary.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            Mercenary.currentTarget = setTarget();
            if (Mercenary.currentTarget != null)
                setPlayerOutline(Mercenary.currentTarget, ChallengerMod.ColorTable.MercenaryColor);
        }
        static void CopyCatSetTarget()
        {
            if (CopyCat.Role == null || CopyCat.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead || AbilityDisabled) return;
            CopyCat.currentTarget = setTarget();
            if (CopyCat.currentTarget != null && !CopyCat.CopyUsed)
                setPlayerOutline(CopyCat.currentTarget, ChallengerMod.ColorTable.CopyCatColor);
            if (CopyCat.currentTarget != null && CopyCat.CopyStart && CopyCat.copyRole == 25)
                setPlayerOutline(CopyCat.currentTarget, ChallengerMod.ColorTable.RedColor);
            if (CopyCat.currentTarget != null && CopyCat.CopyStart && CopyCat.copyRole == 1)
                setPlayerOutline(CopyCat.currentTarget, ChallengerMod.ColorTable.SheriffColor);
            if (CopyCat.currentTarget != null && CopyCat.CopyStart && CopyCat.copyRole == 2)
                setPlayerOutline(CopyCat.currentTarget, ChallengerMod.ColorTable.GuardianColor);
            if (CopyCat.currentTarget != null && CopyCat.CopyStart && CopyCat.copyRole == 5)
                setPlayerOutline(CopyCat.currentTarget, ChallengerMod.ColorTable.HunterColor);
            if (CopyCat.currentTarget != null && CopyCat.CopyStart && CopyCat.copyRole == 12)
                setPlayerOutline(CopyCat.currentTarget, ChallengerMod.ColorTable.InformantColor);
        }
        static void RevengerSetTarget()
        {
            if (Revenger.Role == null || Revenger.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Revenger.currentTarget = setTarget();
            if (Revenger.currentTarget != null && !Revenger.EMP3_Used)
                setPlayerOutline(Revenger.currentTarget, ChallengerMod.ColorTable.RevengerColor);
        }
        static void AssassinSetTarget()
        {
            if (Assassin.Role == null || Assassin.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Assassin.currentTarget = setTarget();
            if (Assassin.currentTarget != null)
                setPlayerOutline(Assassin.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void VectorSetTarget()
        {
            if (Vector.Role == null || Vector.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Vector.currentTarget = setTarget();
            if (Vector.currentTarget != null)
                setPlayerOutline(Vector.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void MorphlingSetTarget()
        {
            if (Morphling.Role == null || Morphling.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Morphling.currentTarget = setTarget();
            if (Morphling.currentTarget != null && Morphling.Morph == null)
                setPlayerOutline(Morphling.currentTarget, ChallengerMod.ColorTable.MorphlingColor);
            if (Morphling.currentTarget != null && Morphling.Morph != null)
                setPlayerOutline(Morphling.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void ScramblerSetTarget()
        {
            if (Scrambler.Role == null || Scrambler.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Scrambler.currentTarget = setTarget();
            if (Scrambler.currentTarget != null)
                setPlayerOutline(Scrambler.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void BarghestSetTarget()
        {
            if (Barghest.Role == null || Barghest.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Barghest.currentTarget = setTarget();
            if (Barghest.currentTarget != null)
                setPlayerOutline(Barghest.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void GhostSetTarget()
        {
            if (Ghost.Role == null || Ghost.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Ghost.currentTarget = setTarget();
            if (Ghost.currentTarget != null)
                setPlayerOutline(Ghost.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void SorcererSetTarget()
        {
            if (Sorcerer.Role == null || Sorcerer.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Sorcerer.currentTarget = setTarget();
            if (Sorcerer.currentTarget != null)
                setPlayerOutline(Sorcerer.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void GuesserSetTarget()
        {
            if (Guesser.Role == null || Guesser.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Guesser.currentTarget = setTarget();
            if (Guesser.currentTarget != null)
                setPlayerOutline(Guesser.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void MesmerSetTarget()
        {
            if (Mesmer.Role == null || Mesmer.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Mesmer.currentTarget = setTarget();
            if (Mesmer.currentTarget != null)
                setPlayerOutline(Mesmer.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void BasiliskSetTarget()
        {
            if (Basilisk.Role == null || Basilisk.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Basilisk.currentTarget = setTarget();
            if (Basilisk.currentTarget != null)
                setPlayerOutline(Basilisk.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void ReaperSetTarget()
        {
            if (Reaper.Role == null || Reaper.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Reaper.currentTarget = setTarget();
            if (Reaper.currentTarget != null)
                setPlayerOutline(Reaper.currentTarget, ChallengerMod.ColorTable.ReaperColor);
        }
        static void SaboteurSetTarget()
        {
            if (Saboteur.Role == null || Saboteur.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Saboteur.currentTarget = setTarget();
            if (Saboteur.currentTarget != null)
                setPlayerOutline(Saboteur.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void Impostor1SetTarget()
        {
            if (Impostor1.Role == null || Impostor1.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Impostor1.currentTarget = setTarget();
            if (Impostor1.currentTarget != null)
                setPlayerOutline(Impostor1.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void Impostor2SetTarget()
        {
            if (Impostor2.Role == null || Impostor2.Role != PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) return;
            Impostor2.currentTarget = setTarget();
            if (Impostor2.currentTarget != null)
                setPlayerOutline(Impostor2.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }
        static void Impostor3SetTarget()
        {
            if (Impostor3.Role == null || Impostor3.Role != PlayerControl.LocalPlayer|| PlayerControl.LocalPlayer.Data.IsDead) return;
            Impostor3.currentTarget = setTarget();
            if (Impostor3.currentTarget != null)
                setPlayerOutline(Impostor3.currentTarget, ChallengerMod.ColorTable.ImpostorColor);
        }

        
        public static void Prefix(PlayerControl __instance)
        {
            if (Eater.Role != null && !Eater.Role.Data.IsDead)
            {
                if (draggers.Contains(Eater.Role.PlayerId))
                {
                    RPC.RPCProcedure.MoveBody(corpse[draggers.IndexOf(Eater.Role.PlayerId)]);
                }
            }

        }

        public static void Postfix(PlayerControl __instance)
        {
            if (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started) return;

            if (PlayerControl.LocalPlayer == __instance)
            {
                
                detectiveUpdateFootPrints();
                assassinFootPrints();
                trackerSetTarget();
                baitUpdate();

                setBasePlayerOutlines();
                ventColorUpdate();
                CursedSetTarget();
                Sheriff1SetTarget();
                Sheriff2SetTarget();
                Sheriff3SetTarget();
                GuardianSetTarget();
                HunterSetTarget();
                InformantSetTarget();
                BuilderSetTarget();
                CopyBuilderSetTarget();
                DoctorSetTarget();
                CupidSetTarget();
                CultistSetTarget();
                OutlawSetTarget();
                EaterSetTarget();
                ArsonistSetTarget();
                MercenarySetTarget();
                CopyCatSetTarget();
                RevengerSetTarget();
                
                AssassinSetTarget();
                VectorSetTarget();
                MorphlingSetTarget();
                ScramblerSetTarget();
                BarghestSetTarget();
                GhostSetTarget();
                GuesserSetTarget();
                MesmerSetTarget();
                SaboteurSetTarget();
                SorcererSetTarget();
                BasiliskSetTarget();
                ReaperSetTarget();
                Impostor1SetTarget();
                Impostor2SetTarget();
                Impostor3SetTarget();

                
            }
        }
    }

    [HarmonyPatch(typeof(KillAnimation), nameof(KillAnimation.CoPerformKill))]
    class KillAnimationCoPerformKillPatch
    {
        public static bool hideNextAnimation = true;
        public static void Prefix(KillAnimation __instance, [HarmonyArgument(0)] ref PlayerControl source, [HarmonyArgument(1)] ref PlayerControl target)
        {
            if (hideNextAnimation)
                source = target;
            hideNextAnimation = false;
        }
    }

    [HarmonyPatch(typeof(KillAnimation), nameof(KillAnimation.SetMovement))]
    class KillAnimationSetMovementPatch
    {
        private static int? colorId = null;
        public static void Prefix(PlayerControl source, bool canMove)
        {
            Color color = source.cosmetics.currentBodySprite.BodySprite.material.GetColor("_BodyColor");
            if (color != null && Morphling.Role != null && source.Data.PlayerId == Morphling.Role.PlayerId)
            {
                var index = Palette.PlayerColors.IndexOf(color);
                if (index != -1) colorId = index;
            }
        }

        public static void Postfix(PlayerControl source, bool canMove)
        {
            if (colorId.HasValue) source.RawSetColor(colorId.Value);
            colorId = null;
        }
    }
}
