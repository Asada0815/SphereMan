using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Build {
    public class FieldInitalizer : MonoBehaviour {

        [SerializeField] int partsSize;

        public void SetContainerPos(Transform container, Vector2 mapSize) {
            container.localPosition = new Vector3(-mapSize.x, mapSize.y, 0) * 0.01f * partsSize * 0.5f;
        }

        public void PutField(Parts.FieldPartsSet parts, int x, int y) {
            var posX = 0.01f * partsSize * x;
            var posY = 0.01f * partsSize * -y;

            if(parts.fixedParts != null) parts.fixedParts.transform.localPosition = new Vector3(posX, posY, 0);
            if(parts.activeParts != null) parts.activeParts.transform.localPosition = new Vector3(posX, posY, 0);
        }

    }

}

