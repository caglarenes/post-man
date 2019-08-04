using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packer : MonoBehaviour
{
    public GameObject[] boxs;
    public Vector3 baslangicyeri;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Renderer>() != null)
        {
            other.GetComponent<Renderer>().material.color = Color.yellow;
        }

        

        other.gameObject.SetActive(false);
        GameObject yaratilanbox = Instantiate(boxs[Random.Range(0, boxs.Length)], baslangicyeri, Quaternion.identity) as GameObject;
        yaratilanbox.transform.Rotate(0f, Random.Range(-10f,10f), 0f);
        yaratilanbox.GetComponent<Box>().ItemID = other.GetComponent<Item>().ItemID;

    }
}
