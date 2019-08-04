using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] spawnObjects;

    public Color[] colors;

    public GameObject[] parkingLots;

    public GameObject[] trucks;

    // Use this for initialization
    void Start()
    {
        parkingLots = GameObject.FindGameObjectsWithTag("parkinglot");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject SpawnItem()
    {
        if (!ParkYeriVarMi())
        {
            return null;
        }

        int rastgelenesne = Random.Range(0, spawnObjects.Length);
        int rastgelerenk = Random.Range(0, colors.Length);

        GameObject nesne = Instantiate(spawnObjects[rastgelenesne], transform.position, spawnObjects[rastgelenesne].transform.rotation) as GameObject;
        /* 
        if (nesne.GetComponent<Renderer>() != null)
        {
            nesne.GetComponent<Renderer>().material.color = colors[rastgelerenk];
        }
        */
        SendTruck(rastgelenesne, rastgelerenk, nesne.GetComponent<Item>().ItemID);

        return nesne;

    }

    public void SendTruck(int id, int gelenrenk, int ItemID)
    {
        Debug.Log(id);
        ParkingLot parkyeri = RastgeleBosParkYeriBul();
        GameObject truck = Instantiate(trucks[id], parkyeri.gameObject.transform.position, trucks[id].gameObject.transform.rotation) as GameObject;
        truck.GetComponent<Truck>().park = parkyeri;
        //truck.GetComponent<Renderer>().material.color = colors[gelenrenk];
        truck.GetComponent<Truck>().ItemID = ItemID;

    }

    ParkingLot RastgeleBosParkYeriBul()
    {

        List<GameObject> bosparkyerleri = new List<GameObject>();
        foreach (var item in parkingLots)
        {
            if (item.GetComponent<ParkingLot>().isEmpty)
            {

                bosparkyerleri.Add(item);

            }
        }

        Debug.Log("Boş Park Yeri Sayısı: " + bosparkyerleri.Count);

        if (bosparkyerleri.Count == 0)
        {
            return null;
        }

        GameObject bosparkyeri = bosparkyerleri[Random.Range(0, bosparkyerleri.Count)];
        bosparkyeri.GetComponent<ParkingLot>().isEmpty = false;

        return bosparkyeri.GetComponent<ParkingLot>();

    }

    private bool ParkYeriVarMi()
    {

        List<GameObject> bosparkyerleri = new List<GameObject>();
        foreach (var item in parkingLots)
        {
            if (item.GetComponent<ParkingLot>().isEmpty)
            {

                bosparkyerleri.Add(item);

            }
        }

        Debug.Log("Boş Park Yeri Sayısı: " + bosparkyerleri.Count);

        if (bosparkyerleri.Count == 0)
        {
            Debug.Log("Boş Park Yeri Yok");
            return false;
            
        }

        return true;

    }
}
