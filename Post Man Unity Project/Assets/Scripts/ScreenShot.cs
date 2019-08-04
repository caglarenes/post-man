using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update

    public string dosyaadi;

    void Start()
    {
        //ScreenCapture.CaptureScreenshot(dosyaadi + ".png", 3);
        
        SaveScreenshotToFile(dosyaadi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Texture2D TakeScreenShot()
     {
         return Screenshot ();
     }
     
     static Texture2D Screenshot() {
         
         int resWidth = Camera.main.pixelWidth;
         int resHeight = Camera.main.pixelHeight;
         Camera camera = Camera.main;
         RenderTexture rt = new RenderTexture(resWidth, resHeight, 32);
         camera.targetTexture = rt;
         Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.ARGB32, false);
         camera.Render();
         RenderTexture.active = rt;
         screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
         screenShot.Apply ();
         camera.targetTexture = null;
         RenderTexture.active = null; // JC: added to avoid errors
         Destroy(rt);
         return screenShot;
     }
 
     public static Texture2D SaveScreenshotToFile(string fileName)
     {
         Texture2D screenShot = Screenshot ();
         byte[] bytes = screenShot.EncodeToPNG();
         System.IO.File.WriteAllBytes(fileName, bytes);
         return screenShot;
     }
}
