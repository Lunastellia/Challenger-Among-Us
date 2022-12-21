using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using System.Reflection;
using System.Text;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using ChallengerMod.RPC;

namespace ChallengerMod.Utils.Option {
    public class CustomOption {
        public enum CustomOptionType {
            P1,
            P2,
            P3,
            P4,
            P5,
            P6
        }

        public static List<CustomOption> options = new List<CustomOption>();
        public static int preset = 0;

        public int id;
        public string name;
        public System.Object[] selections;

        public int defaultSelection;
        public ConfigEntry<int> entry;
        public int selection;
        public OptionBehaviour optionBehaviour;
        public CustomOption parent;
        public bool isHeader;
        public CustomOptionType type;

        // Option creation

        public CustomOption(int id, CustomOptionType type, string name,  System.Object[] selections, System.Object defaultValue, CustomOption parent, bool isHeader) {
            this.id = id;
            this.name = parent == null ? name : "" + name;
            this.selections = selections;
            int index = Array.IndexOf(selections, defaultValue);
            this.defaultSelection = index >= 0 ? index : 0;
            this.parent = parent;
            this.isHeader = isHeader;
            this.type = type;
            selection = 0;
            if (id != 0) {
                entry = HarmonyMain.Instance.Config.Bind($"Preset{preset}", id.ToString(), defaultSelection);
                selection = Mathf.Clamp(entry.Value, 0, selections.Length - 1);
            }
            
            options.Add(this);
        }




        public static CustomOption Create(int id, CustomOptionType type, string name, string[] selections, CustomOption parent = null, bool isHeader = false) {
            return new CustomOption(id, type, name, selections, "", parent, isHeader);
        }

        public static CustomOption Create(int id, CustomOptionType type, string name, float defaultValue, float min, float max, float step, CustomOption parent = null, bool isHeader = false) {
            List<float> selections = new List<float>();
            for (float s = min; s <= max; s += step)
                selections.Add(s);
            return new CustomOption(id, type, name, selections.Cast<object>().ToArray(), defaultValue, parent, isHeader);
        }

       

        public static CustomOption Create(int id, CustomOptionType type, string name, bool defaultValue, CustomOption parent = null, bool isHeader = false) {
            return new CustomOption(id, type, name, new string[]{"Off", "On"}, defaultValue ? "On" : "Off", parent, isHeader);
        }



        // Static behaviour

            public static void switchPreset(int newPreset) {
            CustomOption.preset = newPreset;
            foreach (CustomOption option in CustomOption.options) {
                if (option.id == 0) continue;

                option.entry = HarmonyMain.Instance.Config.Bind($"Preset{preset}", option.id.ToString(), option.defaultSelection);
                option.selection = Mathf.Clamp(option.entry.Value, 0, option.selections.Length - 1);
                if (option.optionBehaviour != null && option.optionBehaviour is StringOption stringOption) {
                    stringOption.oldValue = stringOption.Value = option.selection;
                    stringOption.ValueText.text = option.selections[option.selection].ToString();
                }
            }
        }

        public static void ShareOptionSelections() {
            if (PlayerControl.AllPlayerControls.Count <= 1 || AmongUsClient.Instance!.AmHost == false && PlayerControl.LocalPlayer == null) return;

            var optionsList = new List<CustomOption>(CustomOption.options);
            while (optionsList.Any())
            {
                byte amount = (byte)Math.Min(optionsList.Count, 20);
                var writer = AmongUsClient.Instance!.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareOptions, SendOption.Reliable, -1);
                writer.Write(amount);
                for (int i = 0; i < amount; i++)
                {
                    var option = optionsList[0];
                    optionsList.RemoveAt(0);
                    writer.WritePacked((uint)option.id);
                    writer.WritePacked(Convert.ToUInt32(option.selection));
                }
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }
        }

        // Getter

        public int getSelection() {
            return selection;
        }

        public bool getBool() {
            return selection > 0;
        }

        public float getFloat() {
            return (float)selections[selection];
        }

        public int getQuantity() {
            return selection + 1;
        }

        // Option changes

        public void updateSelection(int newSelection) {
            selection = Mathf.Clamp((newSelection + selections.Length) % selections.Length, 0, selections.Length - 1);
            if (optionBehaviour != null && optionBehaviour is StringOption stringOption) {
                stringOption.oldValue = stringOption.Value = selection;
                stringOption.ValueText.text = selections[selection].ToString();

                if (AmongUsClient.Instance?.AmHost == true && PlayerControl.LocalPlayer) {
                    if (id == 0) switchPreset(selection); // Switch presets
                    else if (entry != null) entry.Value = selection; // Save selection to config

                    ShareOptionSelections();// Share all selections
                }
           }
        }
    }

    [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Start))]
    class GameOptionsMenuStartPatch {
        public static void Postfix(GameOptionsMenu __instance) {
            if (GameObject.Find("Settings_P1") != null) { // Settings setup has already been performed, fixing the title of the tab and returning
                GameObject.Find("Settings_P1").transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText("Lobby Setting");
                return;
            }
            if (GameObject.Find("Settings_P2") != null) {
                GameObject.Find("Settings_P2").transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText("Role Setting");
                return;
            }
            if (GameObject.Find("Settings_P3") != null) {
                GameObject.Find("Settings_P3").transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText("Crewmate Setting");
                return;
            }
            if (GameObject.Find("Settings_P4") != null) {
                GameObject.Find("Settings_P4").transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText("Special & Hybrid Setting");
                return;
            }
            if (GameObject.Find("Settings_P5") != null) {
                GameObject.Find("Settings_P5").transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText("Impostor Setting");
                return;
            }
            if (GameObject.Find("Settings_P6") != null)
            {
                GameObject.Find("Settings_P6").transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText("Ranked Setting");
                return;
            }

            // Setup TOR tab
            var template = UnityEngine.Object.FindObjectsOfType<StringOption>().FirstOrDefault();
            if (template == null) return;
            var gameSettings = GameObject.Find("Game Settings");
            var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();
            
            var Settings_p1 = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var Settings_m1 = Settings_p1.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            Settings_p1.name = "Settings_P1";

            var Settings_p2 = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var Settings_m2 = Settings_p2.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            Settings_p2.name = "Settings_P2";

            var Settings_p3 = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var Settings_m3 = Settings_p3.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            Settings_p3.name = "Settings_P3";

            var Settings_p4 = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var Settings_m4 = Settings_p4.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            Settings_p4.name = "Settings_P4";

            var Settings_p5 = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var Settings_m5 = Settings_p5.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            Settings_p5.name = "Settings_P5";
            
            var Settings_p6 = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var Settings_m6 = Settings_p6.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            Settings_p6.name = "Settings_P6";

            var roleTab = GameObject.Find("RoleTab");
            var gameTab = GameObject.Find("GameTab");

            var Tab_1 = UnityEngine.Object.Instantiate(roleTab, roleTab.transform.parent);
            var Tab_1Highlight = Tab_1.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            Tab_1.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Set_P1;

            var Tab_2 = UnityEngine.Object.Instantiate(roleTab, Tab_1.transform);
            var Tab_2Highlight = Tab_2.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            Tab_2.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Set_P2;
            Tab_2.name = "ImposTab_1";

            var Tab_3 = UnityEngine.Object.Instantiate(roleTab, Tab_2.transform);
            var Tab_3Highlight = Tab_3.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            Tab_3.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Set_P3;
            Tab_3.name = "NeutralTab";

            var Tab_4 = UnityEngine.Object.Instantiate(roleTab, Tab_3.transform);
            var Tab_4Highlight = Tab_4.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            Tab_4.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Set_P4;
            Tab_4.name = "CrewmateTab";

            var Tab_5 = UnityEngine.Object.Instantiate(roleTab, Tab_4.transform);
            var Tab_5Highlight = Tab_5.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            Tab_5.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Set_P5;
            Tab_5.name = "ModifierTab";

            var Tab_6 = UnityEngine.Object.Instantiate(roleTab, Tab_5.transform);
            var Tab_6Highlight = Tab_6.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            Tab_6.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Set_P1;
            Tab_6.name = "ModifierTab";

            // Position of Tab Icons
            gameTab.transform.position += Vector3.left * 3f;
            roleTab.transform.position += Vector3.left * 10f;
            Tab_1.transform.position += Vector3.left * 2f;
            Tab_2.transform.localPosition = Vector3.right * 1f;
            Tab_3.transform.localPosition = Vector3.right * 1f;
            Tab_4.transform.localPosition = Vector3.right * 1f;
            Tab_5.transform.localPosition = Vector3.right * 1f;
            Tab_6.transform.localPosition = Vector3.right * 10f;

            var tabs = new GameObject[] { gameTab, roleTab, Tab_1, Tab_2, Tab_3, Tab_4, Tab_5, Tab_6};
            for (int i = 0; i < tabs.Length; i++) {
                var button = tabs[i].GetComponentInChildren<PassiveButton>();
                if (button == null) continue;
                int copiedIndex = i;
                button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                button.OnClick.AddListener((System.Action)(() => {
                    gameSettingMenu.RegularGameSettings.SetActive(false);
                    gameSettingMenu.RolesSettings.gameObject.SetActive(false);
                    Settings_p1.gameObject.SetActive(false);
                    Settings_p2.gameObject.SetActive(false);
                    Settings_p3.gameObject.SetActive(false);
                    Settings_p4.gameObject.SetActive(false);
                    Settings_p5.gameObject.SetActive(false);
                    Settings_p6.gameObject.SetActive(false);
                    gameSettingMenu.GameSettingsHightlight.enabled = false;
                    gameSettingMenu.RolesSettingsHightlight.enabled = false;
                    Tab_1Highlight.enabled = false;
                    Tab_2Highlight.enabled = false;
                    Tab_3Highlight.enabled = false;
                    Tab_4Highlight.enabled = false;
                    Tab_5Highlight.enabled = false;
                    Tab_6Highlight.enabled = false;
                    if (copiedIndex == 0) {
                        gameSettingMenu.RegularGameSettings.SetActive(true);
                        gameSettingMenu.GameSettingsHightlight.enabled = true;  
                    } else if (copiedIndex == 1) {
                        gameSettingMenu.RolesSettings.gameObject.SetActive(true);
                        gameSettingMenu.RolesSettingsHightlight.enabled = true;
                    } else if (copiedIndex == 2) {
                        Settings_p1.gameObject.SetActive(true);
                        Tab_1Highlight.enabled = true;
                    } else if (copiedIndex == 3) {
                        Settings_p2.gameObject.SetActive(true);
                        Tab_2Highlight.enabled = true;
                    } else if (copiedIndex == 4) {
                        Settings_p3.gameObject.SetActive(true);
                        Tab_3Highlight.enabled = true;
                    } else if (copiedIndex == 5) {
                        Settings_p4.gameObject.SetActive(true);
                        Tab_4Highlight.enabled = true;
                    } else if (copiedIndex == 6) {
                        Settings_p5.gameObject.SetActive(true);
                        Tab_5Highlight.enabled = true;
                    } else if (copiedIndex == 7) {
                        Settings_p6.gameObject.SetActive(true);
                        Tab_6Highlight.enabled = true;
                    }
                }));
            }

            foreach (OptionBehaviour option in Settings_m1.GetComponentsInChildren<OptionBehaviour>())
                UnityEngine.Object.Destroy(option.gameObject);
            List<OptionBehaviour> Option_1 = new List<OptionBehaviour>();          

            foreach (OptionBehaviour option in Settings_m2.GetComponentsInChildren<OptionBehaviour>())
                UnityEngine.Object.Destroy(option.gameObject);
            List<OptionBehaviour> Option_2 = new List<OptionBehaviour>();

            foreach (OptionBehaviour option in Settings_m3.GetComponentsInChildren<OptionBehaviour>())
                UnityEngine.Object.Destroy(option.gameObject);
            List<OptionBehaviour> Option_3 = new List<OptionBehaviour>();

            foreach (OptionBehaviour option in Settings_m4.GetComponentsInChildren<OptionBehaviour>())
                UnityEngine.Object.Destroy(option.gameObject);
            List<OptionBehaviour> Option_4 = new List<OptionBehaviour>();

            foreach (OptionBehaviour option in Settings_m5.GetComponentsInChildren<OptionBehaviour>())
                UnityEngine.Object.Destroy(option.gameObject);
            List<OptionBehaviour> Option_5 = new List<OptionBehaviour>();

            foreach (OptionBehaviour option in Settings_m6.GetComponentsInChildren<OptionBehaviour>())
                UnityEngine.Object.Destroy(option.gameObject);
            List<OptionBehaviour> Option_6 = new List<OptionBehaviour>();


            List<Transform> menus = new List<Transform>() {Settings_m1.transform, Settings_m2.transform, Settings_m3.transform, Settings_m4.transform, Settings_m5.transform, Settings_m6.transform };
            List<List<OptionBehaviour>> optionBehaviours = new List<List<OptionBehaviour>>() { Option_1, Option_2, Option_3, Option_4, Option_5, Option_6 };

            for (int i = 0; i < CustomOption.options.Count; i++) {
                CustomOption option = CustomOption.options[i];
                if (option.optionBehaviour == null) {
                    StringOption stringOption = UnityEngine.Object.Instantiate(template, menus[(int)option.type]);
                    optionBehaviours[(int)option.type].Add(stringOption);
                    stringOption.OnValueChanged = new Action<OptionBehaviour>((o) => { });
                    stringOption.TitleText.text = option.name;
                    stringOption.Value = stringOption.oldValue = option.selection;
                    stringOption.ValueText.text = option.selections[option.selection].ToString();

                    option.optionBehaviour = stringOption;
                }
                option.optionBehaviour.gameObject.SetActive(true);
            }

            Settings_m1.Children = Option_1.ToArray();
            Settings_p1.gameObject.SetActive(false);

            Settings_m2.Children = Option_2.ToArray();
            Settings_p2.gameObject.SetActive(false);

            Settings_m3.Children = Option_3.ToArray();
            Settings_p3.gameObject.SetActive(false);

            Settings_m4.Children = Option_4.ToArray();
            Settings_p4.gameObject.SetActive(false);

            Settings_m5.Children = Option_5.ToArray();
            Settings_p5.gameObject.SetActive(false);

            Settings_m6.Children = Option_5.ToArray();
            Settings_p6.gameObject.SetActive(false);

            
        }
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.OnEnable))]
    public class StringOptionEnablePatch {
        public static bool Prefix(StringOption __instance) {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;

            __instance.OnValueChanged = new Action<OptionBehaviour>((o) => {});
            __instance.TitleText.text = option.name;
            __instance.Value = __instance.oldValue = option.selection;
            __instance.ValueText.text = option.selections[option.selection].ToString();
            
            return false;
        }
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.Increase))]
    public class StringOptionIncreasePatch
    {
        public static bool Prefix(StringOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            option.updateSelection(option.selection + 1);
            return false;
        }
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.Decrease))]
    public class StringOptionDecreasePatch
    {
        public static bool Prefix(StringOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            option.updateSelection(option.selection - 1);
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.RpcSyncSettings))]
    public class RpcSyncSettingsPatch
    {
        public static void Postfix()
        {
            CustomOption.ShareOptionSelections();
        }
    }


    [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Update))]
    class GameOptionsMenuUpdatePatch
    {
        private static float timer = 1f;
        public static void Postfix(GameOptionsMenu __instance) {
            // Return Menu Update if in normal among us settings 
            var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();
            if (gameSettingMenu.RegularGameSettings.active || gameSettingMenu.RolesSettings.gameObject.active) return;

            __instance.GetComponentInParent<Scroller>().ContentYBounds.max = -0.5F + __instance.Children.Length * 0.55F;
            timer += Time.deltaTime;
            if (timer < 0.1f) return;
            timer = 0f;

            float offset = 2.75f;
            foreach (CustomOption option in CustomOption.options) {
                if (GameObject.Find("Settings_P1") && option.type != CustomOption.CustomOptionType.P1)
                    continue;
                if (GameObject.Find("Settings_P2") && option.type != CustomOption.CustomOptionType.P2)
                    continue;
                if (GameObject.Find("Settings_P3") && option.type != CustomOption.CustomOptionType.P3)
                    continue;
                if (GameObject.Find("Settings_P4") && option.type != CustomOption.CustomOptionType.P4)
                    continue;
                if (GameObject.Find("Settings_P5") && option.type != CustomOption.CustomOptionType.P5)
                    continue;
                if (GameObject.Find("Settings_P6") && option.type != CustomOption.CustomOptionType.P6)
                    continue;
                if (option?.optionBehaviour != null && option.optionBehaviour.gameObject != null) {
                    bool enabled = true;
                    var parent = option.parent;
                    while (parent != null && enabled) {
                        enabled = parent.selection != 0;
                        parent = parent.parent;
                    }
                    option.optionBehaviour.gameObject.SetActive(enabled);
                    if (enabled) {
                        offset -= option.isHeader ? 0.75f : 0.5f;
                        option.optionBehaviour.transform.localPosition = new Vector3(option.optionBehaviour.transform.localPosition.x, offset, option.optionBehaviour.transform.localPosition.z);
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(GameSettingMenu), nameof(GameSettingMenu.Start))]
    class GameSettingMenuStartPatch {
        public static void Prefix(GameSettingMenu __instance) {
            __instance.HideForOnline = new Transform[]{};
        }

        public static void Postfix(GameSettingMenu __instance) {
            // Setup mapNameTransform
            var mapNameTransform = __instance.AllItems.FirstOrDefault(x => x.name.Equals("MapName", StringComparison.OrdinalIgnoreCase));
            if (mapNameTransform == null) return;
            var options = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Collections.Generic.KeyValuePair<string, int>>();
            for (int i = 0; i < Constants.MapNames.Length; i++) {
                if (i == 3) continue; // Ignore dlekS
                var kvp = new Il2CppSystem.Collections.Generic.KeyValuePair<string, int>();
                kvp.key = Constants.MapNames[i];
                kvp.value = i;
                options.Add(kvp);
            }
            mapNameTransform.GetComponent<KeyValueOption>().Values = options;
            mapNameTransform.gameObject.active = true;

            


                foreach (Transform i in __instance.AllItems.ToList()) {
                float num = -0.5f;
                if (i.name.Equals("MapName", StringComparison.OrdinalIgnoreCase)) num = -0.25f;
                if (i.name.Equals("NumImpostors", StringComparison.OrdinalIgnoreCase) || i.name.Equals("ResetToDefault", StringComparison.OrdinalIgnoreCase)) num = 0f;
                i.position += new Vector3(0, num, 0);
            }
            __instance.Scroller.ContentYBounds.max += 0.5F;
        }
    }

    [HarmonyPatch] 
    class GameOptionsDataPatch
    {
        private static IEnumerable<MethodBase> TargetMethods() {
            return typeof(GameOptionsData).GetMethods().Where(x => x.ReturnType == typeof(string) && x.GetParameters().Length == 1 && x.GetParameters()[0].ParameterType == typeof(int));
        }

        private static string buildRoleOptions() {
            var impRoles = buildOptionsOfType(CustomOption.CustomOptionType.P2, true) + "\n";
            var neutralRoles = buildOptionsOfType(CustomOption.CustomOptionType.P3, true) + "\n";
            var crewRoles = buildOptionsOfType(CustomOption.CustomOptionType.P4, true) + "\n";
            var modifiers = buildOptionsOfType(CustomOption.CustomOptionType.P5, true) + "\n";
            var rankedgame = buildOptionsOfType(CustomOption.CustomOptionType.P6, true);
            return impRoles + neutralRoles + crewRoles + modifiers + rankedgame;
        }

        private static string buildOptionsOfType(CustomOption.CustomOptionType type, bool headerOnly) {
            StringBuilder sb = new StringBuilder("\n");
            var options = CustomOption.options.Where(o => o.type == type);
            foreach (var option in options) {
                if (option.parent == null) {
                    sb.AppendLine($"{option.name}: {option.selections[option.selection].ToString()}");
                }
            }
            if (headerOnly) return sb.ToString();
            else sb = new StringBuilder();

            foreach (CustomOption option in options) {
                if (option.parent != null) {
                    bool isIrrelevant = option.parent.getSelection() == 0 || (option.parent.parent != null && option.parent.parent.getSelection() == 0);
                    
                    Color c = isIrrelevant ? Color.grey : Color.white;
                    if (isIrrelevant) continue;
                    sb.AppendLine(Helpers.cs(c, $"{option.name}: {option.selections[option.selection].ToString()}"));


                } 
                else 
                {

                        sb.AppendLine($"\n{option.name}: {option.selections[option.selection].ToString()}");
                                        
                }
            }
            return sb.ToString();
        }

        
    }


    // This class is taken from Town of Us Reactivated, https://github.com/eDonnes124/Town-Of-Us-R/blob/master/source/Patches/CustomOption/Patches.cs, Licensed under GPLv3
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate {
        public static float
            MinX,
            OriginalY = 2.9F,
            MinY = 2.9F;


        public static Scroller Scroller;
        private static Vector3 LastPosition;
        private static float lastAspect;
        private static bool setLastPosition = false;

        public static void Prefix(HudManager __instance) {
            if (__instance.GameSettings?.transform == null) return;

            
            Rect safeArea = Screen.safeArea;
            float aspect = Mathf.Min((Camera.main).aspect, safeArea.width / safeArea.height);
            float safeOrthographicSize = CameraSafeArea.GetSafeOrthographicSize(Camera.main);
            MinX = 0.1f - safeOrthographicSize * aspect;

            if (!setLastPosition || aspect != lastAspect) {
                LastPosition = new Vector3(MinX, MinY);
                lastAspect = aspect;
                setLastPosition = true;
            }

            CreateScroller(__instance);

            Scroller.gameObject.SetActive(__instance.GameSettings.gameObject.activeSelf);

            if (!Scroller.gameObject.active) return;

            var rows = __instance.GameSettings.text.Count(c => c == '\n');
            float LobbyTextRowHeight = 0.06F;
            var maxY = Mathf.Max(MinY, rows * LobbyTextRowHeight + (rows - 38) * LobbyTextRowHeight);

            Scroller.ContentYBounds = new FloatRange(MinY, maxY);

            if (PlayerControl.LocalPlayer?.CanMove != true) {
                __instance.GameSettings.transform.localPosition = LastPosition;

                return;
            }

            if (__instance.GameSettings.transform.localPosition.x != MinX ||
                __instance.GameSettings.transform.localPosition.y < MinY) return;

            LastPosition = __instance.GameSettings.transform.localPosition;
        }

        private static void CreateScroller(HudManager __instance) {
            if (Scroller != null) return;

            Scroller = new GameObject("SettingsScroller").AddComponent<Scroller>();
            Scroller.transform.SetParent(__instance.GameSettings.transform.parent);
            Scroller.gameObject.layer = 5;

            Scroller.transform.localScale = Vector3.one;
            Scroller.allowX = false;
            Scroller.allowY = true;
            Scroller.active = true;
            Scroller.velocity = new Vector2(0, 0);
            Scroller.ScrollbarYBounds = new FloatRange(0, 0);
            Scroller.ContentXBounds = new FloatRange(MinX, MinX);
            Scroller.enabled = true;

            Scroller.Inner = __instance.GameSettings.transform;
            __instance.GameSettings.transform.SetParent(Scroller.transform);
        }
    }
}
