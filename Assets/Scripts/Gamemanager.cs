using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Collections;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public float gamespeed = 5;
    [SerializeField]
    public float SpeedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gamestart;
    [SerializeField] private GameObject gameoverMess;
    private bool isGameOver = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public float GetGammespeed()
    {
        return gamespeed;
    }
    void Start()
    {
        starGame();
    }

    // Update is called once per frame
    void Update()
    {
       
        HanleStartGameInput();
        if(!isGameOver)
        {
            UpdateGamespeed();
            UpdateSCore();
        }
    }
    private void UpdateGamespeed()
    {
        gamespeed += Time.deltaTime * SpeedIncrease;
    }
    private void UpdateSCore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "SCore:" + Mathf.FloorToInt(score);
    }
    private void starGame()
    {
        Time.timeScale = 0;
        scoreTextObject.SetActive(false);
        gamestart.SetActive(true);
        gameoverMess.SetActive(false);
    }
    private void HanleStartGameInput()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            scoreTextObject.SetActive(true);
            gamestart.SetActive(false);
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        gameoverMess.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(ReloadScene());
    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
