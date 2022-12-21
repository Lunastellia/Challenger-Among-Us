using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using ChallengerMod.Utility.Utils;
using Object = UnityEngine.Object;
using static ChallengerMod.Challenger;

namespace ChallengerMod.UI
{
    public static class ChallengerUI_MMO
    {
        

        public static void Initialize()
        {
           
                
                SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, loadSceneMode) =>
            
            {
                if (!scene.name.Equals("MMOnline")) return;
                if (!TryMoveObjects()) return;

                var editName = DestroyableSingleton<AccountManager>.Instance.accountTab.editNameScreen;
                var nameText = Object.Instantiate(editName.nameText.gameObject);
                nameText.transform.localScale = new Vector3(0f, 0f, 0f);
                nameText.transform.localPosition = new Vector3(0f, 0f, 0f);
                nameText.name = "DestroyedText";

                var textBox = nameText.GetComponent<TextBoxTMP>();
                textBox.outputText.alignment = TextAlignmentOptions.CenterGeoAligned;
                textBox.outputText.transform.position = nameText.transform.position;
                textBox.outputText.fontSize = 4f;

                textBox.OnChange.AddListener((Action)(() => {
                    SaveManager.PlayerName = textBox.text;
                }));
                textBox.OnEnter = textBox.OnFocusLost = textBox.OnChange;
                textBox.Pipe.GetComponent<TextMeshPro>().fontSize = 4f;

                

            }));
        }

        private static bool TryMoveObjects()
        {
            var toMove = new List<string>
            {
                "HostGameButton",
                "FindGameButton",
                "JoinGameButton",
                "HelpButton"
            };

           
            var yStart = Vector3.up;
            var yOffset = Vector3.down * 1.5f;

            var gameObjects = toMove.Select(x => GameObject.Find("NormalMenu/" + x)).ToList();
            if (gameObjects.Any(x => x == null)) return false;

            for (var i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].transform.position = new Vector3(-100f, 0f, 0f);
            }

            

            return true;
        }
    }
}