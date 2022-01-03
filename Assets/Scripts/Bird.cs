using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gameStarted = false;
    private bool gameOver = false;
    private bool TeleportationOccured = false;
    [SerializeField] private GameObject pressKeyText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    bool congratulations = false; 


    //ToDo:
    //level progress bar, rotating obstacles,teleportation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameStarted && !gameOver  )
        {
            if (Input.GetKeyDown("space"))
            {
                rb.velocity = Vector2.up * 100f;
            }

            transform.DOMoveX(transform.position.x + 5f, 0.3f).SetEase(Ease.Linear);
        }


        else if (Input.GetKeyDown("space") && !gameOver )
        {
            pressKeyText.SetActive(false);
            gameStarted = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * 30f;

        }


        if (transform.position.y < -50.5f || transform.position.y > 57.5f &&!congratulations)
        {
            GameOver();
        }

    }

   
    


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("pipe"))
        {
            GameOver();

        }

        else if (collision.CompareTag("finishLine"))
        {
            congratulations = true;
            Congratulations();

        }
    }

    private void Congratulations()
    {
        winPanel.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName != "Level 3")
        {


            UiManager.Instance.LoadNextScene();
        }

    }


private void GameOver()
    {
        gameOverPanel.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameOver = true;
    }
}
