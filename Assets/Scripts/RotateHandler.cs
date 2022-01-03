using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RotateHandler : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToRotate;

    private bool Level3 = false;


    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName=="Level 3")
        {
            Level3 = true;
        }
    }

    void Update()
    {
    
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            if (Level3) // in level 3 rotation of pipes are bi-directional and faster
            {
                if (i % 2 == 0)
                {

                    objectsToRotate[i].transform.Rotate(0, 0, 75 * Time.deltaTime);

                }

                else if (i % 2 == 1)
                {

                    objectsToRotate[i].transform.Rotate(0, 0, -75 * Time.deltaTime);


                }

            }

            else
            {

                objectsToRotate[i].transform.Rotate(0, 0, 50 * Time.deltaTime);
            }
          
        }

       
    }

    
}
