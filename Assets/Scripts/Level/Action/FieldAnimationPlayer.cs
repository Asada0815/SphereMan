using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Level.Action {
    public class FieldAnimationPlayer : MonoBehaviour {

        public void Play(List<FieldAnimationParts> stream) {
            var seqence = DOTween.Sequence();
            var endTime = 0f;
            foreach(var animation in stream) {
                seqence.Insert(endTime, animation.sequence);
                endTime += animation.endTime;
            }
            seqence.Play();
        }

    }



    public class FieldAnimationParts {
        public Sequence sequence;
        public float endTime;
        public FieldAnimationParts(Sequence sequence, float endTime) {
            this.sequence = sequence;
            this.endTime = endTime;
        }
    }
}


