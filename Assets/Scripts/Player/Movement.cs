using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public enum PlayerMovementStatus
{
    move,
    fire
}
/// <summary>
/// Tanımlı objenin hareket etmesini sağlar. (dönme işlemi de bir harekettir.)
/// </summary>
public class Movement : PlayerController
{
    [HideInInspector]public Turn turnThis;

    private void Start()
    {
        if (useMySettingValues)
            return;
        speedSettings = GameManager.instance.speedSettings;
    }
    public override void PlayerUpdate()
    {
        base.PlayerUpdate();//Türetilen sınıftan alacağımız varsa alırız
        switch (movementStatus)
        {
            case PlayerMovementStatus.move:
                MoveCharacter();
                break;
            case PlayerMovementStatus.fire:
                TurnMuzzle();
                break;
            default:
                break;
        }
       
    }
    /// <summary>
    /// Karakter, joystick'ten aldığı bilgiler doğrultusunda hareket eder.
    /// </summary>
    public void MoveCharacter()
    {
        transform.position += new Vector3(variableJoystick.Horizontal* speedSettings.speedXAxis * Time.fixedDeltaTime,0, speedSettings.speedZAxis * Time.fixedDeltaTime);
    }
    public void TurnMuzzle()
    {
        turnThis.TurnThis(speedSettings.speedTurn * variableJoystick.Horizontal * Time.fixedDeltaTime);
    }

   
}
