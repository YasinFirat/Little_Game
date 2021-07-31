using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController :MonoBehaviour
{
    [Tooltip("Joystick sürüklemelisin. (Canvas objesinde child olarak eklenmiş olabilir.))")]
    public VariableJoystick variableJoystick;
    public SpeedSettings speedSettings;
    public bool useMySettingValues;
    [HideInInspector]public PlayerMovementStatus movementStatus;

    public void Awake()
    {
        SetMoveStatus(PlayerMovementStatus.move);
    }
  
    public virtual void PlayerUpdate()
    {
        
    }
    /// <summary>
    /// Hareket durumu belirlenir.
    /// </summary>
    /// <param name="movementStatus"></param>
    /// <returns></returns>
    public PlayerController SetMoveStatus(PlayerMovementStatus movementStatus)
    {
        this.movementStatus = movementStatus;
        return this;
    }
    public PlayerMovementStatus GetMoveStatus
    {
        get
        {
            return movementStatus;
        }
    }
}
