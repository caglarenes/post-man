using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public GameObject[] itemler;
    public GameObject levelScreen;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void oyunabasla()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void levelAc()
    {
        levelScreen.SetActive(true);
    }

    public void tutorialBasla()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void levelKapa()
    {
        levelScreen.SetActive(false);
    }

    public void oyunKapa()
    {
        Application.Quit();
    }
}
