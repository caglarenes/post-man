using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    // Start is called before the first frame update

    public int ItemID;
    public ParkingLot park;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        park.isEmpty = true;
        GameObject.Destroy(gameObject);

    }
}
