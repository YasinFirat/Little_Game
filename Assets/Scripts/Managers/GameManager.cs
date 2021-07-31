using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]public PlaceRandomly placeRandomly;
    [Header("Place Random")]
    [Tooltip("Mermilerin rastgele bir şekilde dizileceği platformu sürükleyin.")]
    public Transform platform;
    public Vector3 offset;
    public Axis ignoreAxis;
    [Header("Target")]
    public Transform target;
    public float powerForceTarget;
    [Tooltip("Oyunun bitmesi için toplamda isabet edecek mermi sayısı")]
    public int totalDamageForFinish;

    [Header("Bullet")]
    public GameObject bullet;
    [Tooltip("Merminin gideceği hız")]
    public float powerForceBullet;
    [Tooltip("Belli aralıklarla yapılacak atış zamanlaması")]
    public float shootLoopTimes = .4f;
    

    [Header("Player Settings")]
    public SpeedSettings speedSettings;

    [Header("Events")]
    [Tooltip("Oyun Bittiğinde çalışacak kod")]
    public UnityEvent whenFinish;
    

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        //Random pozisyon belirlenmesi için bilgiler gerekli sınıfa set edilir
        placeRandomly = new PlaceRandomly(platform,offset,ignoreAxis);
        
    }
    private void Start()
    {
        bullet.transform.position = placeRandomly.GetRandomPosition;
        for (int i = 0; i < 30; i++)
        {
            Instantiate(bullet,placeRandomly.GetRandomPosition,Quaternion.identity);
        }
    }

    
}
