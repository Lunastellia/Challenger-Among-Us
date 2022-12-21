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
using ChallengerMod.RPC;
//using ChallengerMod.Arrow;

namespace ChallengerMod
{




    [HarmonyPatch]
    public static class GameEvent
    {
        //SetTask


        public static void ChangeVentSprite(bool flag)
        {
            if (flag)
            {
                if (PlayerControl.GameOptions.MapId == 0) //Skeld
                {

                    foreach (Vent vent in ShipStatus.Instance.AllVents)
                    {
                        PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                        animator?.Stop();
                        vent.EnterVentAnim = vent.ExitVentAnim = null;
                        vent.myRend.sprite = NewVent;
                        vent.myRend.color = Color.white;
                    }
                    VentSpriteEdited = true;
                }
                if (PlayerControl.GameOptions.MapId == 1) //Mirah
                {

                    foreach (Vent vent in ShipStatus.Instance.AllVents)
                    {
                        PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                        animator?.Stop();
                        vent.EnterVentAnim = vent.ExitVentAnim = null;
                        vent.myRend.sprite = NewVent;
                        vent.myRend.color = Color.white;
                    }
                    VentSpriteEdited = true;
                }
                if (PlayerControl.GameOptions.MapId == 4) //Airship
                {

                    foreach (Vent vent in ShipStatus.Instance.AllVents)
                    {
                        PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                        animator?.Stop();
                        vent.EnterVentAnim = vent.ExitVentAnim = null;
                        vent.myRend.sprite = NewVent;
                        vent.myRend.color = Color.white;
                    }
                    VentSpriteEdited = true;
                }
            }
        }

        /** - This part of the code is not open source **/
    }
}