using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;
using DG.Tweening;

namespace Level.Parts.SphereMan {
    public class SphereManAnimation : MonoBehaviour {

        [SerializeField] float moveDuration;
        [SerializeField] Ease moveEase;

        [SerializeField] float fallDuration;
        [SerializeField] Ease fallEase;

        [SerializeField] float jumpDuration;
        [SerializeField] Ease jumpEase;

        [SerializeField] float ascendDuration;
        [SerializeField] Ease ascendEase;


        public FieldAnimationParts Move(Vector2 toPos) {
            var seqence = DOTween.Sequence();
            seqence.Append(transform.DOLocalMove(FieldMapUtility.I.CalcMapPos(toPos), moveDuration)
                .SetEase(moveEase));
            return new FieldAnimationParts(seqence, moveDuration);
        }

        public FieldAnimationParts Fall(Vector2 toPos, int dist) {
            var seqence = DOTween.Sequence();
            var totalDuration = fallDuration * dist;
            seqence.Append(transform.DOLocalMove(FieldMapUtility.I.CalcMapPos(toPos), totalDuration)
                .SetEase(fallEase));
            return new FieldAnimationParts(seqence, totalDuration);
        }

        public FieldAnimationParts Jump(Vector2 toPos) {
            var seqence = DOTween.Sequence();
            seqence
                .Append(transform.DOLocalJump(FieldMapUtility.I.CalcMapPos(toPos), 0.5f, 1, jumpDuration))
                .SetEase(jumpEase);

            return new FieldAnimationParts(seqence, moveDuration);
        }

        public FieldAnimationParts Ascend(Vector2 toPos) {
            var seqence = DOTween.Sequence();
            seqence.Append(transform.DOLocalMove(FieldMapUtility.I.CalcMapPos(toPos), ascendDuration)
                .SetEase(ascendEase));
            return new FieldAnimationParts(seqence, ascendDuration);
        }

    }

}

