using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Parts.SphereMan;
using Level.Action;
using KeyInput;
using DG.Tweening;

namespace Level.Parts {
    public class SphereWall : ActiveFieldParts {

        [SerializeField] float appearDuration;
        [SerializeField] Ease appearEase;
        [SerializeField] float waitDuration;


        protected override void Init() {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }

        public FieldAnimationParts Appear() {
            var sp = GetComponent<SpriteRenderer>();
            var seqence = DOTween.Sequence();
            seqence.Append(DOTween.ToAlpha(() => sp.color, color => sp.color = color, 1, appearDuration)
                .SetEase(appearEase));
            return new FieldAnimationParts(seqence, appearDuration + waitDuration);
        }

    }
}


