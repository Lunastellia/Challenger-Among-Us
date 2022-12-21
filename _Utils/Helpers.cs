using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Collections;
using UnhollowerBaseLib;
using UnityEngine;
using System.Linq;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using HarmonyLib;
using Hazel;
using ChallengerMod.Patches;
using ChallengerMod.RPC;
using static ChallengerMod.Utils.Option.CustomOptionHolder;


namespace ChallengerMod.Utils {

    public enum MurderAttemptResult {
        PerformKill,
        Guardianshield,
        MysticShield,
        SuppressKill
    }
    public static class Helpers {

        

        

        public static PlayerControl playerById(byte id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == id)
                    return player;
            return null;
        }
        public static DeadBody GetDeadBody(int id)
        {
            foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance * 1000000f, Constants.PlayersOnlyMask))
            {
                if (collider2D.tag == "DeadBody")
                {
                    DeadBody body = (DeadBody)((Component)collider2D).GetComponent<DeadBody>();
                    if (id == body.ParentId)
                        return body;
                }
            }
            return null;
        }

        public static Dictionary<byte, PlayerControl> allPlayersById()
        {
            Dictionary<byte, PlayerControl> res = new Dictionary<byte, PlayerControl>();
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                res.Add(player.PlayerId, player);
            return res;
        }
        public static PlayerControl getPartner(this PlayerControl player)
        {
            if (player == null)
                return null;
            if (Cupid.Lover1 == player)
                return Cupid.Lover1;
            if (Cupid.Lover2 == player)
                return Cupid.Lover2;
            return null;
        }

        public static bool roleCanUseVents(this PlayerControl player)
        {
            bool roleCouldUse = false;


            if (Impostor1.Role != null && Impostor1.Role == player) { roleCouldUse = true; }
            else if (Impostor2.Role != null && Impostor2.Role == player) { roleCouldUse = true; }
            else if (Impostor3.Role != null && Impostor3.Role == player) { roleCouldUse = true; }
            else if (Assassin.Role != null && Assassin.Role == player && Assassin.StealVent) { roleCouldUse = true; }
            else if (Vector.Role != null && Vector.Role == player && Vector.CanVent) { roleCouldUse = true; }
            else if (Morphling.Role != null && Morphling.Role == player && Morphling.CanVent) { roleCouldUse = true; }
            else if (Scrambler.Role != null && Scrambler.Role == player && Scrambler.CanVent) { roleCouldUse = true; }
            else if (Barghest.Role != null && Barghest.Role == player && Barghest.CanVent) { roleCouldUse = true; }
            else if (Ghost.Role != null && Ghost.Role == player && Ghost.CanVent) { roleCouldUse = true; }
            else if (Sorcerer.Role != null && Sorcerer.Role == player && Sorcerer.CanVent) { roleCouldUse = true; }
            else if (Guesser.Role != null && Guesser.Role == player && Guesser.CanVent) { roleCouldUse = true; }
            else if (Mesmer.Role != null && Mesmer.Role == player && Mesmer.CanVent) { roleCouldUse = true; }
            else if (Basilisk.Role != null && Basilisk.Role == player && Basilisk.CanVent) { roleCouldUse = true; }
            else if (Reaper.Role != null && Reaper.Role == player && Reaper.CanVent) { roleCouldUse = true; }
            else if (Saboteur.Role != null && Saboteur.Role == player && Saboteur.CanVent) { roleCouldUse = true; }
            else if (Engineer.Role != null && Engineer.Role == player && Engineer.CanVent) { roleCouldUse = true; }
            else if (Bait.Role != null && Bait.Role == player && Bait.CanVent) { roleCouldUse = true; }
            else if (Fake.Role != null && Fake.Role == player && Fake.CanVent) { roleCouldUse = true; }
            else if (Eater.Role != null && Eater.Role == player && Eater.CanVent) { roleCouldUse = true; }
            else if (Mercenary.Role != null && Mercenary.Role == player && Mercenary.CanVent) { roleCouldUse = true; }
            else if (CopyCat.Role != null && CopyCat.Role == player && CopyCat.CanVent) { roleCouldUse = true; }
            else { roleCouldUse = false; }

            if (roleCouldUse)
            {
                ChallengerMod.Challenger.CanUseVent = true;
            }
            else
            {
                ChallengerMod.Challenger.CanUseVent = false;
            }

            return roleCouldUse;
        }
        public static MurderAttemptResult checkMurderAttempt(PlayerControl killer, PlayerControl target, bool blockRewind = false)
        {
            // Modified vanilla checks
            if (AmongUsClient.Instance.IsGameOver) return MurderAttemptResult.SuppressKill;
            if (killer == null || killer.Data == null || killer.Data.IsDead || killer.Data.Disconnected)
            {
                return MurderAttemptResult.SuppressKill; // Allow non Impostor kills compared to vanilla code
            } 
            if (target == null || target.Data == null || target.Data.IsDead || target.Data.Disconnected)
            {
                return MurderAttemptResult.SuppressKill; // Allow killing players in vents compared to vanilla code   
            }
            else if (Guardian.Protected != null && Guardian.Protected == target)
            {
                //RPC
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(killer.NetId, (byte)CustomRPC.ShieldedMurderAttempt, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.shieldedMurderAttempt();
                
                target = null;
                return MurderAttemptResult.Guardianshield;
            }
            else if (Mystic.Role != null && Guardian.ProtectedMystic != null && Guardian.ProtectedMystic == target && Mystic.DoubleShield)
            {
                //RPC
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(killer.NetId, (byte)CustomRPC.ShieldedMurderAttempt, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.shieldedMurderAttempt();

                target = null;
                return MurderAttemptResult.MysticShield;
            }
            else if (CopyCat.Role != null && CopyCat.copyRole == 6 && CopyCat.CopyStart && Guardian.ProtectedMystic != null && Guardian.ProtectedMystic == target && Mystic.DoubleShield)
            {
                //RPC
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(killer.NetId, (byte)CustomRPC.ShieldedMurderAttempt, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.shieldedMurderAttempt();

                target = null;
                return MurderAttemptResult.MysticShield;
            }



            else if (Mystic.Role != null && Mystic.selfShield == true && !Mystic.DoubleShield && Mystic.Role == target)
            {

                //RPC
                return MurderAttemptResult.MysticShield;
            }
            else if (CopyCat.Role != null && CopyCat.copyRole == 6 && CopyCat.CopyStart && Mystic.selfShield == true && !Mystic.DoubleShield && CopyCat.Role == target)
            {

                //RPC
                return MurderAttemptResult.MysticShield;
            }
            else
            {
                return MurderAttemptResult.PerformKill;
            }
        }

        public static MurderAttemptResult checkMurderAttemptAndKill(PlayerControl killer, PlayerControl target, bool isMeetingStart = false, bool showAnimation = true)
        {
            // The local player checks for the validity of the kill and performs it afterwards (different to vanilla, where the host performs all the checks)
            // The kill attempt will be shared using a custom RPC, hence combining modded and unmodded versions is impossible

            MurderAttemptResult murder = checkMurderAttempt(killer, target, isMeetingStart);
            if (murder == MurderAttemptResult.PerformKill)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.UncheckedMurderPlayer, Hazel.SendOption.Reliable, -1);
                writer.Write(killer.PlayerId);
                writer.Write(target.PlayerId);
                writer.Write(showAnimation ? Byte.MaxValue : 0);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.uncheckedMurderPlayer(killer.PlayerId, target.PlayerId, showAnimation ? Byte.MaxValue : (byte)0);
            }
            return murder;
        }









        //Fake tasks for neutral and rebel team
        public static bool hasFakeTasks(this PlayerControl player)
        {
            return (player == Jester.Role || player == Eater.Role || player == Cupid.Role || player == Cultist.Role || player == Arsonist.Role || player == Outlaw.Role || player == Survivor.Role || player == Cursed.Role );//|| player == GM.Player
        }

        public static void clearAllTasks(this PlayerControl player)
        {
            if (player == null) return;
            foreach (var playerTask in player.myTasks)
            {
                playerTask.OnRemove();
                UnityEngine.Object.Destroy(playerTask.gameObject);
            }
            player.myTasks.Clear();

            if (player.Data != null && player.Data.Tasks != null)
                player.Data.Tasks.Clear();
        }

        public static void setSemiTransparent(this PoolablePlayer player, bool value)
        {
            float alpha = value ? 0.25f : 1f;
            foreach (SpriteRenderer r in player.gameObject.GetComponentsInChildren<SpriteRenderer>())
                r.color = new Color(r.color.r, r.color.g, r.color.b, alpha);
            player.cosmetics.nameText.color = new Color(player.cosmetics.nameText.color.r, player.cosmetics.nameText.color.g, player.cosmetics.nameText.color.b, alpha);
        }
        public static bool hidePlayerName(PlayerControl source, PlayerControl target)
        {

            if (ComSab == true && CommsSabotageAnonymous.getSelection() == 1) //Com Sabotage enable
            {
                if (source.Data.IsDead)
                {
                    return false; // Visible
                }
                else
                {
                    if (source == target)
                    {
                        return false; // Visible
                    }
                    else
                    {
                        if (source.Data.Role.IsImpostor && (target.Data.Role.IsImpostor || target == Fake.Role))
                        {
                            return false; // Visible
                        }
                        else
                        {
                            return true; // Hide
                        }
                    }
                }
            }
            else // Com Sabotage disabled
            {
                if (source.Data.IsDead)
                {
                    return false; // Visible
                }
                else
                {
                    if (source == target)
                    {
                        return false; // Visible
                    }
                    else
                    {
                        if (source.Data.Role.IsImpostor && (target.Data.Role.IsImpostor || target == Fake.Role))
                        {
                            return false; // Visible
                        }
                        else
                        {
                            if (Scrambler.Role != null && Scrambler.Camo)
                            {
                                return true; // Hide
                            }
                            else
                            {
                                return false; // Visible
                            }
                        }
                    }
                }
            }
        }

        public static void setDefaultLook(this PlayerControl target)
        {
            target.setLook(target.Data.PlayerName, target.Data.DefaultOutfit.ColorId, target.Data.DefaultOutfit.HatId, target.Data.DefaultOutfit.VisorId, target.Data.DefaultOutfit.SkinId, target.Data.DefaultOutfit.PetId);
        }
        
        public static void setLook(this PlayerControl target, String playerName, int colorId, string hatId, string visorId, string skinId, string petId)
        {
            target.RawSetColor(colorId);
            target.RawSetVisor(visorId);
            target.RawSetHat(hatId, colorId);
            target.RawSetName(hidePlayerName(PlayerControl.LocalPlayer, target) ? cs(ChallengerMod.ColorTable.nocolor, "x") : playerName);

            SkinViewData nextSkin = DestroyableSingleton<HatManager>.Instance.GetSkinById(skinId).viewData.viewData;
            PlayerPhysics playerPhysics = target.MyPhysics;
            AnimationClip clip = null;
            var spriteAnim = playerPhysics.myPlayer.cosmetics.skin.animator;
            var currentPhysicsAnim = playerPhysics.Animator.GetCurrentAnimation();
            if (currentPhysicsAnim == playerPhysics.CurrentAnimationGroup.RunAnim) clip = nextSkin.RunAnim;
            else if (currentPhysicsAnim == playerPhysics.CurrentAnimationGroup.SpawnAnim) clip = nextSkin.SpawnAnim;
            else if (currentPhysicsAnim == playerPhysics.CurrentAnimationGroup.EnterVentAnim) clip = nextSkin.EnterVentAnim;
            else if (currentPhysicsAnim == playerPhysics.CurrentAnimationGroup.ExitVentAnim) clip = nextSkin.ExitVentAnim;
            else if (currentPhysicsAnim == playerPhysics.CurrentAnimationGroup.IdleAnim) clip = nextSkin.IdleAnim;
            else clip = nextSkin.IdleAnim;

            float progress = playerPhysics.Animator.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            playerPhysics.myPlayer.cosmetics.skin.skin = nextSkin;
            playerPhysics.myPlayer.cosmetics.skin.UpdateMaterial();
            spriteAnim.Play(clip, 1f);
            spriteAnim.m_animator.Play("a", 0, progress % 1);
            spriteAnim.m_animator.Update(0f);

            if (target.cosmetics.currentPet) UnityEngine.Object.Destroy(target.cosmetics.currentPet.gameObject);
            target.cosmetics.currentPet = UnityEngine.Object.Instantiate<PetBehaviour>(DestroyableSingleton<HatManager>.Instance.GetPetById(petId).viewData.viewData);
            target.cosmetics.currentPet.transform.position = target.transform.position;
            target.cosmetics.currentPet.Source = target;
            target.cosmetics.currentPet.Visible = target.Visible;
            target.SetPlayerMaterialColors(target.cosmetics.currentPet.rend);
        }


        public static void showFlash(Color color, float duration = 1f)
        {
            if (HudManager.Instance == null || HudManager.Instance.FullScreen == null) return;
            HudManager.Instance.FullScreen.gameObject.SetActive(true);
            HudManager.Instance.FullScreen.enabled = true;
            HudManager.Instance.StartCoroutine(Effects.Lerp(duration, new Action<float>((p) => {
                var renderer = HudManager.Instance.FullScreen;

                if (p < 0.5)
                {
                    if (renderer != null)
                        renderer.color = new Color(color.r, color.g, color.b, Mathf.Clamp01(p * 2 * 0.75f));
                }
                else
                {
                    if (renderer != null)
                        renderer.color = new Color(color.r, color.g, color.b, Mathf.Clamp01((1 - p) * 2 * 0.75f));
                }
                if (p == 1f && renderer != null) renderer.enabled = false;
            })));
        }

        public static void shareGameVersion()
        {
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.VersionHandshake, Hazel.SendOption.Reliable, -1);
            writer.Write((byte)HarmonyMain.Version.Major);
            writer.Write((byte)HarmonyMain.Version.Minor);
            writer.Write((byte)HarmonyMain.Version.Build);
            writer.WritePacked(AmongUsClient.Instance.ClientId);
            writer.Write((byte)(HarmonyMain.Version.Revision < 0 ? 0xFF : HarmonyMain.Version.Revision));
            writer.Write(Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.ToByteArray());
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            RPCProcedure.versionHandshake(HarmonyMain.Version.Major, HarmonyMain.Version.Minor, HarmonyMain.Version.Build, HarmonyMain.Version.Revision, Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId, AmongUsClient.Instance.ClientId);
        }









        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static KeyValuePair<byte, int> MaxPair(this Dictionary<byte, int> self, out bool tie)
        {
            tie = true;
            KeyValuePair<byte, int> result = new KeyValuePair<byte, int>(byte.MaxValue, int.MinValue);
            foreach (KeyValuePair<byte, int> keyValuePair in self)
            {
                if (keyValuePair.Value > result.Value)
                {
                    result = keyValuePair;
                    tie = false;
                }
                else if (keyValuePair.Value == result.Value)
                {
                    tie = true;
                }
            }
            return result;
        }




        public static object TryCast(this Il2CppObjectBase self, Type type)
        {
            return AccessTools.Method(self.GetType(), nameof(Il2CppObjectBase.TryCast)).MakeGenericMethod(type).Invoke(self, Array.Empty<object>());
        }
    }
}
