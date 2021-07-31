using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootController : MonoBehaviour
{
    [HideInInspector]public Shoot shoot;
    private float shootLoopTimes;
    private bool shootContinue;

    private void Start()
    {
        shoot.powerShoot = GameManager.instance.powerForceBullet;
        shootLoopTimes = GameManager.instance.shootLoopTimes;
    }
    /// <summary>
    /// Zamana göre atış yapar.
    /// </summary>
    /// <param name="playerMovement"></param>
    /// <param name="bullets"></param>
    public void StartShoot(PlayerMovementStatus playerMovement, Stack<Rigidbody> bullets)
    {
        switch (playerMovement)
        {
            case PlayerMovementStatus.move:
                break;
            case PlayerMovementStatus.fire:
                shootContinue = true;
                StartCoroutine(ShootEnumerator(bullets));
                break;
            default:
                break;
        }

        
    }
    /// <summary>
    /// Atışı durdurur
    /// </summary>
    public void StopShoot()
    {
        shootContinue = false;
    }

    IEnumerator ShootEnumerator(Stack<Rigidbody> bullets)
    {
        
        float timeKeeper = 0;

        while (shootContinue)
        {
            if (timeKeeper > shootLoopTimes)
            {
                if (bullets.Count == 0)
                {
                    Debug.Log("Mermi bitti");
                    break;
                }
                shoot.ShootThis(shoot.muzzle, bullets.Pop());
               
                timeKeeper = 0;
            }
            timeKeeper += Time.fixedDeltaTime;
            Debug.Log("timer " + timeKeeper);
            yield return new WaitForFixedUpdate();
        }

        

    }
}
