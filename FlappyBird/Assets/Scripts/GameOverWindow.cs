using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{

    private Text scoreText;

    private void Awake()
    {
        
        scoreText = transform.Find("ScoreText").GetComponent<Text>();

        transform.Find("retryButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        };
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
        
    }
}
