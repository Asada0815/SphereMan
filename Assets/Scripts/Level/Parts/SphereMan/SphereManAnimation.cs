using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;
using DG.Tweening;

namespace Level.Parts.SphereMan {
    public class SphereManAnimation : MonoBehaviour {

        [SerializeField] float moveSpeed;
        [SerializeField] Ease moveEase;

        public FieldAnimationParts Move(Vector2 toPos) {
            var seqence = DOTween.Sequence();
            seqence.Append(transform.DOLocalMove(FieldMapUtility.I.CalcMapPos(toPos), moveSpeed)
                .SetEase(moveEase));
            return new FieldAnimationParts(seqence, moveSpeed);
        }

    }

}

