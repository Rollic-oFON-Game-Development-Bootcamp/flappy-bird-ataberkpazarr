using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gameStarted = false;
    private bool gameOver = false;
    private bool TeleportationOccured = false;
    [SerializeField] private GameObject pressKeyText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    //[SerializeField] private GameObject teleportationGate;




    //ToDo:
    //level progress bar, rotating obstacles,teleportation


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && !gameOver && !TeleportationOccured)
        {


            if (Input.GetKeyDown("space"))
            {


                rb.velocity = Vector2.up * 100f;

            }

            transform.DOMoveX(transform.position.x + 5f, 0.3f).SetEase(Ease.Linear);
        }

        else if (Input.GetKeyDown("space") && !gameOver)
        {
            pressKeyText.SetActive(false);
            gameStarted = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * 30f;

            if (TeleportationOccured)
            {
                TeleportationOccured = false;
            }
        }

        if (transform.position.y < -50.5f || transform.position.y > 57.5f)
        {
            GameOver();
        }

        


    }

    private void OnEnable()
    {
        TeleportationHandler.teleportationOccured += HandleTeleportation;
    }

    private void HandleTeleportation(Vector3 vec)
    {
        //TeleportationOccured = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("pipe"))
        {
            GameOver();

        }

        else if (collision.CompareTag("finishLine"))
        {
            congratulations();

        }
    }

    private void congratulations()
    {
        winPanel.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameOver = true;
        // go to next scene for next level
    }


private void GameOver()
    {
        gameOverPanel.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameOver = true;

    }
}
