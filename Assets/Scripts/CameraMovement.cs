using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject bird;

    private bool teleportationOccured = false;


    void LateUpdate()
    {
        transform.DOMove(new Vector3(bird.transform.position.x - 15, 2.7f, -10), 1f);
        

    }

    
}
