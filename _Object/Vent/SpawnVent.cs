using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;


namespace ChallengerMod._Object
{

    public class BarghestVentObject
    {
        public static System.Collections.Generic.List<BarghestVentObject> AllBarghestVentes = new System.Collections.Generic.List<BarghestVentObject>();
        public static int BarghestVentLimit = 5;

        private GameObject gameObject;
        public Vent vent;
        private SpriteRenderer boxRenderer;

        public BarghestVentObject(Vector2 p)
        {
            gameObject = new GameObject("BarghestVent") { layer = 11 };
            Vector3 position = new Vector3(p.x, p.y, p.y / 1000f + 0.01f);
            position += (Vector3)PlayerControl.LocalPlayer.Collider.offset; 
            gameObject.transform.position = position;
            boxRenderer = gameObject.AddComponent<SpriteRenderer>();
            boxRenderer.sprite = ventmapIco;


            var referenceVent = UnityEngine.Object.FindObjectOfType<Vent>();
            vent = UnityEngine.Object.Instantiate<Vent>(referenceVent);
            vent.transform.position = gameObject.transform.position;
            vent.Left = null;
            vent.Right = null;
            vent.Center = null;
            vent.EnterVentAnim = null;
            vent.ExitVentAnim = null;
            vent.Offset = new Vector3(0f, 0.25f, 0f);
            vent.GetComponent<PowerTools.SpriteAnim>()?.Stop();
            vent.Id = ShipStatus.Instance.AllVents.Select(x => x.Id).Max() + 1; 
            var ventRenderer = vent.GetComponent<SpriteRenderer>();
            ventRenderer.sprite = ventmapIco;  
            vent.myRend = ventRenderer;
            var allVentsList = ShipStatus.Instance.AllVents.ToList();
            allVentsList.Add(vent);
            ShipStatus.Instance.AllVents = allVentsList.ToArray();
            vent.gameObject.SetActive(false);
            vent.name = "BarghestVentVent_" + vent.Id;

            var playerIsBarghest = PlayerControl.LocalPlayer == Barghest.Role;
            gameObject.SetActive(true);

            AllBarghestVentes.Add(this);
            gameObject.SetActive(true);
            vent.gameObject.SetActive(true);
            connectVents();
        }

       

        private static void connectVents()
        {
            for (var i = 0; i < AllBarghestVentes.Count - 1; i++)
            {
                var a = AllBarghestVentes[i];
                var b = AllBarghestVentes[i + 1];
                a.vent.Right = b.vent;
                b.vent.Left = a.vent;
            }
            AllBarghestVentes.First().vent.Left = AllBarghestVentes.Last().vent;
            AllBarghestVentes.Last().vent.Right = AllBarghestVentes.First().vent;
        }

    }

}