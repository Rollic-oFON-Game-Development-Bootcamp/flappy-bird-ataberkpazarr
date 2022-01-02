using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject bird;

    private bool teleportationOccured = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (!teleportationOccured)
        {
            transform.DOMove(new Vector3(bird.transform.position.x - 15, 2.7f, -10), 1f);

        }
        //transform.position = bird.transform.position;

    }

    private void OnEnable()
    {
        TeleportationHandler.teleportationOccured += setBirdPos;
    }

    private void setBirdPos(Vector3 vec)
    {
        teleportationOccured = true;
        transform.DOMove(new Vector3(vec.x - 15, 2.7f, -10), 0.05f).OnComplete(()=>BackUsualCamMove());


    }

    private void BackUsualCamMove()
    {

        teleportationOccured = false;
    }
}
