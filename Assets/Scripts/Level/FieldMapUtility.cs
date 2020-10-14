using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMapUtility : SingletonMonoBehaviour<FieldMapUtility> {

    public int mapChipSize;

    public Vector3 CalcMapPos(Vector2 pos) {
        var posX = 0.01f * mapChipSize * pos.x;
        var posY = 0.01f * mapChipSize * -pos.y;
        return new Vector3(posX, posY, 0);
    }

}
