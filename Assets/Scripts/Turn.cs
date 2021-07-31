using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Turn
{
    public Transform muzzle;
    public void TurnThis(float angle)
    {
        muzzle.RotateAround(muzzle.position, Vector3.up,angle);
    }
}
