using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;
using DG.Tweening;

namespace Level.Parts.SphereMan {

    public class ShotAnimation : MonoBehaviour {

        GameObject g_shot;
        SpriteRenderer sp_shot;

        [SerializeField] float shotMoveDuration;
        [SerializeField] Ease shotMoveEase;
        [SerializeField] float shotFadeOutDuration;
        [SerializeField] Ease shotFadeOutEase;
        void Awake() {
            g_shot = GameObject.Find("shot");
            sp_shot = g_shot.GetComponent<SpriteRenderer>();
            sp_shot.color = new Color(1, 1, 1, 0);
        }

        public FieldAnimationParts Shot(Vector2 fromPos, Vector2 toPos) {
            g_shot.transform.localPosition = FieldMapUtility.I.CalcMapPos(fromPos);
            sp_shot.color = new Color(1, 1, 1, 1);
            var seqence = DOTween.Sequence();
            var dist = (int)Mathf.Abs((fromPos - toPos).magnitude);
            seqence.Append(g_shot.transform.DOLocalMove(FieldMapUtility.I.CalcMapPos(toPos), shotMoveDuration * dist)
                .SetEase(shotMoveEase));
            seqence.Append(DOTween.ToAlpha(() => sp_shot.color, color => sp_shot.color = color, 0, shotFadeOutDuration)
                .SetEase(shotFadeOutEase));
            return new FieldAnimationParts(seqence, shotMoveDuration + shotFadeOutDuration);
        }


    }

}

