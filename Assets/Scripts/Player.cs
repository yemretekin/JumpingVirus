using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public Text scoreText;
    public Text highscoreText;

    private float score = 0;
    private float highScore = 0;

    public Transform cam;

    public GameObject panel;

    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    
    
    void Update()
    {
        if (rb.velocity.y > 0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        scoreText.text = Mathf.Round(score).ToString();

        if (cam.position.y > transform.position.y + 7f)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", score);
            highscoreText.text = "HIGHSCORE: " + Mathf.Round(score).ToString();
            PlayerPrefs.Save();

        }

        
        MovementPlayer();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;

        Time.timeScale = 1;

        highScore = PlayerPrefs.GetFloat("highScore");
        highscoreText.text = "HIGHSCORE: " + Mathf.Round(highScore).ToString();
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    void MovementPlayer()
    {
        if (moveLeft)
        {
            horizontalMove = speed;
        }

        else if (moveRight)
        {
            horizontalMove = -speed;
        }

        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}



