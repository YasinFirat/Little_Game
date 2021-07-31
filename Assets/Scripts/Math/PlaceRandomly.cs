using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Axis durumu belirtirlir.
/// </summary>
public enum Axis
{
    X_Axis,
    Y_Axis,
    Z_Axis,
    nothing

}
/// <summary>
///  Bir alanda rastgele konum belirler.
/// </summary>
[System.Serializable]
public class PlaceRandomly
{
    [Tooltip("orgin noktası")]
    public Vector3 orgin;
    [Tooltip("Uzunluk değerleri")]
    public Vector3 scale;
   [Tooltip("Sapma durumuna karşı (objelerin konumu orta noktalarından referans alındığından dolayı birazcık yukarı çekmek isteyebilirsiniz :) )")]
    public Vector3 offset;
    [Tooltip("Hangi düzlemde rastgele değer üretilmesini istiyorsanız o düzlemi seçiniz.")]
    public Axis ignoreAxis;
    private Vector3 keepRandomPlace;
    private PlaceRandomly() { }
    public PlaceRandomly(Vector3 orgin,Vector3 scale,Vector3 offset,Axis ignoreAxis)
    {
        this.orgin = orgin;
        this.scale = scale;
        this.offset = offset;
        this.ignoreAxis = ignoreAxis;
    }
    public PlaceRandomly(Transform _transform,Vector3 offset,Axis ignoreAxis)
    {
        this.orgin = _transform.position;
        this.scale = _transform.localScale;
        this.offset = offset;
        this.ignoreAxis = ignoreAxis;
    }
    /// <summary>
    /// Eğer orgin ve scale değeri girildiyse rastgele konum oluşturur.
    /// </summary>
    public Vector3 GetRandomPosition
    {
        get
        {
            keepRandomPlace= new Vector3(GetRandom(orgin.x, scale.x), GetRandom(orgin.y, scale.y), GetRandom(orgin.z, scale.z));
            //istenilen düzlemde dağılım yapılabilir.
            switch (ignoreAxis)
            {
                case Axis.X_Axis: 
                    keepRandomPlace.x = orgin.x+offset.x;
                    break;
                case Axis.Y_Axis:
                    keepRandomPlace.y = orgin.y+offset.y;
                    break;
                case Axis.Z_Axis:
                    keepRandomPlace.z = orgin.z+offset.z;
                    break;
                default:
                    break;
            }
            return keepRandomPlace;
        }
    }
    /// <summary>
    /// İstenilen axis için random değer üretir.
    /// </summary>
    /// <param name="orginAxis">İşlem yapmak istediğiniz eksenin orgin değerini giriniz. örn; x için orgin.x</param>
    /// <param name="scaleAxis">işlem yapmak istediğiniz eksenin scale değerini giriniz.</param>
    /// <returns></returns>
    private float GetRandom(float orginAxis,float scaleAxis)
    {//Bir alan içerisinde rastgele değerler atanmasını istediğinizde koordinat sisteminde
        // başlangıç noktası ile uzunluğun yarısını toplamanız veya çıkarmanız yeterli olacaktır.
        // 2.5 ile bölme nedenim dağılımın tam sınır noktasına erişimini engellemektir.
        return Random.Range(orginAxis-scaleAxis/2.5f,orginAxis+scaleAxis/2.5f);
    }

}
