using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (Player.instance.movement.GetMoveStatus)
        {
            case PlayerMovementStatus.move:
                if (other.CompareTag("ShootArea"))
                {
                    Player.instance.movement.SetMoveStatus(PlayerMovementStatus.fire);
                    Player.instance.shootController.shoot.LookAtTarget();
                }
                if (other.CompareTag("Bullet"))
                {
                    //cephane ekle
                    Debug.Log("Cephane ekle");
                    Player.instance.inventoryBullet.AddInventory(other.GetComponent<Rigidbody>());
                }
                break;
            case PlayerMovementStatus.fire:
                break;
            default:
                break;
        }
        if (other.CompareTag("ShootArea"))
        {
            Player.instance.movement.SetMoveStatus(PlayerMovementStatus.fire);
        }
       
    }
}
