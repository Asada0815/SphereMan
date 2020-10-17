using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using DG.Tweening;

namespace Level.Action {
    public class FieldAnimationPlayer : MonoBehaviour {

        public IObservable<Unit> onFinish {
            get {
                return onFinishSub;
            }
        }

        Subject<Unit> onFinishSub;

        void Awake() {
            onFinishSub = new Subject<Unit>();
        }

        public void Play(List<FieldAnimationParts> stream) {
            var seqence = DOTween.Sequence();
            var endTime = 0f;
            foreach(var animation in stream) {
                seqence.Insert(endTime, animation.sequence);
                endTime += animation.endTime;
            }
            seqence.Play().OnComplete(() => onFinishSub.OnNext(Unit.Default));
        }

    }



    public class FieldAnimationParts {
        public Sequence sequence;
        public float endTime;
        public FieldAnimationParts(Sequence sequence, float endTime) {
            this.sequence = sequence;
            this.endTime = endTime;
        }

        public FieldAnimationParts Join(FieldAnimationParts target) {
            sequence.Insert(endTime, target.sequence);
            endTime += target.endTime;
            return this;
        }
    }
}


