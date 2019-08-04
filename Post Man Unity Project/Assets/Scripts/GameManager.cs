using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{




    SpawnManager spawnManager;

    public int scorepoint = 0;
    public float timer = 0f;

    public int level = 1;
    public float levelhizi = 1f;
    public int yüklemesayisi = 0;
    public float dusussikligi = 5f;

    public GameObject GameOverScreen;
    public GameObject levelUpScreen;
    public GameObject pauseScreen;

    public Text ScoreText;
    public Text levelScreen;
    public Text yuklemeSayisiText;
    public Text saat;



    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();

        InvokeRepeating("Spawn", 0, dusussikligi);

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        timer = timer + Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        saat.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }

    void Spawn()
    {
        GameObject gelenObje = spawnManager.SpawnItem();
    }

    public void Skor()
    {

        scorepoint = scorepoint + 10;
        ScoreText.text = scorepoint.ToString();
        yüklemesayisi++;
        yuklemeSayisiText.text = yüklemesayisi.ToString();

        if (level <= (yüklemesayisi / 5))
        {
            level++;
            levelScreen.text = level.ToString();
            LevelUp();
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);

    }

    public void LevelUp()
    {

        levelUpScreen.GetComponent<Animator>().SetTrigger("LevelUp");

        levelhizi = levelhizi + 0.25f;

        foreach (var item in GameObject.FindGameObjectsWithTag("yol"))
        {
            item.GetComponent<LinearConveyor>().ChangeSpeed(levelhizi);
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("yoldonus"))
        {
            item.GetComponent<RadialConveyor>().ChangeSpeed(levelhizi);
        }

        CancelInvoke("Spawn");
        dusussikligi = dusussikligi - 0.25f;

        if (dusussikligi < 1)
        {
            dusussikligi = 1f;
        }
        
        InvokeRepeating("Spawn", 0, dusussikligi);
    }

    public void YüklemeSayisi()
    {




    }

    public void RestartButton()
    {

        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void durdur()
    {

        Time.timeScale = 0f;
        pauseScreen.SetActive(true);

    }

    public void devam()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;


    }

    public void Back()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }


}
