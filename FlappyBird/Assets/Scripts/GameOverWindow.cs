using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{

    private Text scoreText;
    private Text highscoreText;

    private void Awake()
    {
        
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        highscoreText = transform.Find("HighscoreText").GetComponent<Text>();

        transform.Find("retryButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        };

        transform.Find("retryButton").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("mainMenuButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        };
        transform.Find("mainMenuButton").GetComponent<Button_UI>().AddButtonSounds();
    }
    // Start is called before the first frame update
    private void Start()
    {
        Hide();
        Bird.GetInstance().OnDied += Bird_OnDied;
    }
    private void Bird_OnDied(object sender, System.EventArgs e)
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
        if(Level.GetInstance().GetPipesPassedCount() >= Score.GetHighscore())
        {
            highscoreText.text = "NEW HIGHSCORE";
        } else
        {
            highscoreText.text = "HIGHSCORE: " + Score.GetHighscore();
        }
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Loader.Load(Loader.Scene.GameScene);
        }
    }
}
