using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Speed ayarlamaları yapılır
/// </summary>
[System.Serializable]
public struct SpeedSettings
{
    [Range(0, 3)]
    [Tooltip("X ekseninde Hız")]
    public float speedXAxis;
    [Range(0, 3)]
    [Tooltip("Z ekseninde Hız")]
    public float speedZAxis;
    [Tooltip("Dönme Hızı")]
    [Range(0, 10)]
    public float speedTurn;
}
