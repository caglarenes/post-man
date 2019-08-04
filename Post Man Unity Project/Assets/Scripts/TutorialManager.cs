using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] screens;

    void Start()
    {
        Time.timeScale = 1f;
        Invoke("screen0", 4.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void screenopener(int ekran, float sure = 2f)
    {

        foreach (var item in screens)
        {
            item.SetActive(false);
        }
        screens[ekran].SetActive(true);
        Time.timeScale = 0f;
        //Invoke("screen" + (ekran + 1).ToString(), sure);
    }

    public void screen0()
    {
        screenopener(0, 2f);

    }
    public void screen1()
    {
        screenopener(1, 2f);

    }
    public void screen2()
    {
        screenopener(2);
    }
    public void screen3()
    {
        screenopener(3);
    }

    public void screen4()
    {
        screenopener(4);
    }

    public void bekletici(int ekran)
    {
        float sure = 5f;
        switch (ekran)
        {
            case 1:
                sure = 4f;
                break;

            case 2:
                sure = 5.5f;
                break;

            case 3:
                sure = 4f;
                break;

            case 4:
                sure = 4f;
                break;

            default:
                sure = 4f;
                break;
        }

        Invoke("screen" + (ekran).ToString(), sure);



        foreach (var item in screens)
        {
            item.SetActive(false);
        }


        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);

    }

    public void BackButton()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);

    }
}
