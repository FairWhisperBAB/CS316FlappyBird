using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private int score = 0;
    public bool isGameOver = false;
    public float scrollSpeed = -1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        //Creates a game manager if there isn't one in the scene already
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            //reloads scene when restarting
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScore()
    {
        //bird dont score if its dead
        if (isGameOver)
            return;
        //increases the score counter
        score++;
        //puts the score counter on the screen
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        //makes the game over screen visable
        gameOverText.SetActive(true);

        //makes true so no more score can be added
        isGameOver = true;
    }
}
