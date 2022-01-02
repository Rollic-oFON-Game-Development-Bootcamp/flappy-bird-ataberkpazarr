using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TeleportationTrigger : MonoBehaviour
{
    //public static Action<Vector3> spawnTeleportationGate;

    [SerializeField] private GameObject teleportationGate;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaaa");
        if (collision.CompareTag("bird"))
        {
            Vector3 colPos = collision.transform.position;
            Vector3 offset = new Vector3(15,0,0);
            Vector3 newPos = colPos + offset;
            GameObject gam =Instantiate(teleportationGate,newPos,Quaternion.identity);
            Collider2D col = GetComponent<Collider2D>();
            col.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("aaaa");
        if (other.CompareTag("bird"))
        {
            Vector3 colPos = other.transform.position;
            Vector3 offset = new Vector3(2, 0, 0);
            Vector3 newPos = colPos + offset;
            GameObject gam = Instantiate(teleportationGate, newPos, Quaternion.identity);
            Collider2D col = GetComponent<Collider2D>();
            col.isTrigger = false;
        }
    }
}
