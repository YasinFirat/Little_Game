using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Movement movement;
    [Tooltip("Mermilerin stack'lenme işlemi için gerekli")]
    public InventoryStack inventoryBullet;
    [Tooltip("Atış kontrolü için gerekli")]
    public ShootController shootController;
    public Transform muzzle;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        movement.turnThis.muzzle = muzzle;
        shootController.shoot.muzzle = muzzle;
    }

    private void FixedUpdate()
    {
        movement.PlayerUpdate();
    }
    /// <summary>
    /// Atış yapmaya başlar
    /// </summary>
    public void StartShoot()
    {
        shootController.StartShoot(movement.GetMoveStatus,inventoryBullet.inventoryObject);
    }
    /// <summary>
    /// Atışı durdurur
    /// </summary>
    public void StopShoot()
    {
        shootController.StopShoot();
    }
   
}
