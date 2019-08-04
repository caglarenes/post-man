using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot2 : MonoBehaviour
{

    public string isim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(Input.GetKeyDown(KeyCode.J))
        {
            isim = isim + ".png";
            ScreenCapture.CaptureScreenshot(isim, 5);
        }
        
    }
}
