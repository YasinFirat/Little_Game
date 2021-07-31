using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Mermilerin dizilim işlemini yapar.
/// </summary>
public class InventoryStack : MonoBehaviour
{
    [Tooltip("Başlangıç noktası")]
    public Vector3 origin;
    [SerializeField] public Stack<Rigidbody> inventoryObject = new Stack<Rigidbody>();
    private Vector3 keepPosition;
    [Tooltip("Dizilim için aralık bırakma miktarını girebilirsiniz.")]
    public Vector3 offset;

   
    public void AddInventory(Rigidbody inventoryObj)
    {
        inventoryObj.transform.Rotate(0,90,0);
        inventoryObj.transform.SetParent(transform);
        keepPosition = origin;
       
        keepPosition.x -= (inventoryObj.transform.localScale.z+offset.z) * inventoryObject.Count;
        inventoryObj.transform.localPosition = keepPosition;
        inventoryObject.Push(inventoryObj);


    }
}
