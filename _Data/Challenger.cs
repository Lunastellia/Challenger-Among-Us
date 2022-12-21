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
//using ChallengerMod.Arrow;

namespace ChallengerMod
{

    public class DeadPlayer
    {
        public PlayerControl player;
        public DateTime timeOfDeath;
        public DeathReason deathReason;
        public PlayerControl killerIfExisting;

        public DeadPlayer(PlayerControl player, DateTime timeOfDeath, DeathReason deathReason, PlayerControl killerIfExisting)
        {
            this.player = player;
            this.timeOfDeath = timeOfDeath;
            this.deathReason = deathReason;
            this.killerIfExisting = killerIfExisting;
        }
    }

    static class GameHistory
    {
        public static List<Tuple<Vector3, DateTime>> localPlayerPositions = new List<Tuple<Vector3, DateTime>>();
        public static List<DeadPlayer> deadPlayers = new List<DeadPlayer>();

        public static void clearGameHistory()
        {
            localPlayerPositions = new List<Tuple<Vector3, DateTime>>();
            deadPlayers = new List<DeadPlayer>();
        }
    }


    [HarmonyPatch]
    public static class Challenger
    {
        //NEVER CLEAR THIS !! 

        /** - This part of the code is not open source **/
        public static List<DeadPlayer> killedPlayers = new List<DeadPlayer>();
       
        public static List<PlayerControl> localPlayers = new List<PlayerControl>();
        /** - This part of the code is not open source **/

    }

}