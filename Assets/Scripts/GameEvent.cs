using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEvent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI currentEventText;

    private PlayerBrain player;
    private int score;
    private OtherEvents events;

    private void Awake()
    {
        events = OtherEvents.inStart;
    }

    private void Start()
    {
        player = GameObject.Find("PlayerBall").GetComponent<PlayerBrain>();
    }

    private void Update()
    {
        if (events == OtherEvents.inStart && !player.alive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }

        if (events == OtherEvents.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void StartGame()
    {
        player.alive = true;
        events = OtherEvents.inGame;
        currentEventText.enabled = false;
    }

    public void GameOver()
    {
        player.alive = false;
        events = OtherEvents.gameOver;
        currentEventText.enabled = true;
        currentEventText.text = "GameOver\nPress R To Restart";
    }

    public void Score(int i)
    {
        score += i;
        scoreText.text = score.ToString();
    }
}
enum OtherEvents
{
    inGame,
    inStart,
    gameOver
}