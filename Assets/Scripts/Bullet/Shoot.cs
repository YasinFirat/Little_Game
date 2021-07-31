using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shoot
{
    public Transform muzzle;
    public float powerShoot;
    
    /// <summary>
    /// Atış işlemi yapılır.
    /// </summary>
    /// <param name="muzzle"> namlu yani merminin oluşacağı bölge</param>
    /// <param name="bulletRb"></param>
    public void ShootThis(Transform muzzle,Rigidbody bulletRb)
    {
        bulletRb.transform.position = muzzle.position;
        bulletRb.isKinematic = false;
        bulletRb.AddForce(muzzle.forward*powerShoot,ForceMode.VelocityChange);
    }
    public void LookAtTarget()
    {
        Vector3 direction = GameManager.instance.target.position;
        direction.x = muzzle.position.x;
        muzzle.LookAt(direction,Vector3.right);
        
    }
}
