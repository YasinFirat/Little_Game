using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public PlaceRandomly placeRandomly;
    private float speed;
    public int totalDamage;
    private int damageCounter;
    private Rigidbody rb;
    
    private void Start()
    {
        placeRandomly.orgin = transform.position;
        transform.position = placeRandomly.GetRandomPosition;
        speed = GameManager.instance.powerForceTarget;
        totalDamage = GameManager.instance.totalDamageForFinish;
        rb = GetComponent<Rigidbody>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        damageCounter++;
        collision.gameObject.SetActive(false);
        if (damageCounter >= totalDamage)
        {
            GameManager.instance.whenFinish?.Invoke();
            rb.useGravity = true;
            rb.AddForce(-transform.forward*speed,ForceMode.VelocityChange);
        }
    }

    
}

