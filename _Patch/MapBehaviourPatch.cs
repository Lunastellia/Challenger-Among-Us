using HarmonyLib;
using Hazel;
using System;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using InnerNet;
using System.Collections.Generic;

using System.IO;
using System.Net.Http;
using System.Linq;
using ChallengerMod.Utility.Utils;
using Object = UnityEngine.Object;
using static ChallengerMod.HarmonyMain;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using Il2CppSystem.Collections;
using Twitch;
using System.Threading.Tasks;
using GLMod;
using TMPro;
using System.Threading;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Utils.Helpers;
using static ChallengerMod.GameEvent;

namespace ChallengerMod
{

    [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.ShowSabotageMap))]
    class MapOverlay
    {
        /** - This part of the code is not open source **/

    }




