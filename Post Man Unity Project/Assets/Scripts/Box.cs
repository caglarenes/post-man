using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{

    public int ItemID;
    public GameManager gamemanager;
    public GameObject worldcanvas;

    public Text pointText;

    int layermask = 1 << 9;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        worldcanvas = GameObject.FindGameObjectWithTag("WorldCanvas");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left * 3f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 3f, layermask))
        {
            Debug.Log("Kamyona Değdi");
        }


    }

    void OnMouseDown()
    {
        Debug.Log("Tıklandı");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 3f, layermask))
        {

            if (hit.transform.gameObject.GetComponent<Truck>().ItemID == ItemID)
            {
                Debug.Log("Doğru Kutu");

                GameObject yazi = Instantiate(pointText.gameObject, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y + 1f, hit.transform.gameObject.transform.position.z),
                pointText.gameObject.transform.rotation, worldcanvas.transform) as GameObject;

                pointText.text = "+" + (9 + gamemanager.level).ToString();
                GameObject.Destroy(yazi, 0.5f);
                hit.transform.gameObject.GetComponent<Truck>().Destroy();
                GameObject.Destroy(gameObject);
                gamemanager.Skor();
            }
            else
            {
                Debug.Log("YanlışKutu");
            }
        }


    }
}
