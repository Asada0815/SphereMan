using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Build {
    public class FieldInitalizer : MonoBehaviour {

        public void SetContainerPos(Transform container, Vector2 mapSize) {
            var mapChipSize = FieldMapUtility.I.mapChipSize;
            container.localPosition = new Vector3(-mapSize.x, mapSize.y, 0) * 0.01f * mapChipSize * 0.5f;
        }

        public void PutField(Parts.FieldPartsSet parts, int x, int y) {
            var mapPos = FieldMapUtility.I.CalcMapPos(new Vector2(x, y));
            parts.fixedParts.transform.localPosition = mapPos;
            parts.activeParts.transform.localPosition = mapPos;
        }

    }

}

