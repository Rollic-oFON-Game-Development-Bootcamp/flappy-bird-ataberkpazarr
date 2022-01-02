using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TeleportationHandler : MonoBehaviour
{
    public static Action<Vector3> teleportationOccured;
     private Vector3 spawnPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnPosition = GameObject.FindWithTag("Respawn").transform.position;

    }
    void Start()
    {
        transform.DORotate(transform.eulerAngles + new Vector3(0, 0, 90), 1);
        transform.DOScale(new Vector3(3, 3, 3), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bird"))
        {
            //Camera.main.transform.position = spawnPosition-new Vector3(-2,0,0);
            teleportationOccured.Invoke(spawnPosition);
            //collision.transform.DOMove(spawnPosition,0.1f);
            collision.transform.position = spawnPosition*Time.deltaTime;

            Destroy(this.gameObject);
        }


    }
}
