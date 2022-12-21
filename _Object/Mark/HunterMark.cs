using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Roles;
using static ChallengerMod.Unity;


namespace ChallengerMod
{
    class HunterFootprint
    {
        private static List<HunterFootprint> Marks = new List<HunterFootprint>();
        private static Sprite sprite;
        private Color color;
        private GameObject Mark;
        private SpriteRenderer spriteRenderer;
        private PlayerControl owner;
        private bool anonymousHunterFootprints;

        public static Sprite getHunterFootprintSprite()
        {
            if (sprite) return sprite;
            sprite = HPrint;
            return sprite;
        }

        public HunterFootprint(float MarkDuration, bool anonymousHunterFootprints, PlayerControl player)
        {
            this.owner = player;
            this.anonymousHunterFootprints = anonymousHunterFootprints;
            if (anonymousHunterFootprints)
                this.color = Palette.PlayerColors[11];
            else
                this.color = Palette.PlayerColors[(int)player.CurrentOutfit.ColorId];

            Mark = new GameObject("HunterFootprint");
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);
            Mark.transform.position = position;
            Mark.transform.localPosition = position;
            Mark.transform.SetParent(player.transform.parent);
            Mark.layer = 5;
            

            Mark.transform.Rotate(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f));


            spriteRenderer = Mark.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = getHunterFootprintSprite();
            spriteRenderer.color = color;

            Mark.SetActive(true);
            Marks.Add(this);

            HudManager.Instance.StartCoroutine(Effects.Lerp(MarkDuration, new Action<float>((p) => {
                Color c = color;
                

                if (spriteRenderer) spriteRenderer.color = new Color(c.r, c.g, c.b, Mathf.Clamp01(1 - p));

                if (p == 1f && Mark != null)
                {
                    UnityEngine.Object.Destroy(Mark);
                    Marks.Remove(this);
                }
            })));
        }
    }
}