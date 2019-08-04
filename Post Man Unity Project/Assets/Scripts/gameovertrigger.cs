using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovertrigger : MonoBehaviour
{

    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider carpan)
    {

            gamemanager.GameOver();
    }
}
