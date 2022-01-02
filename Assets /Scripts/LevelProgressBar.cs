using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private Image UIFillImage;
    [SerializeField] private TextMeshProUGUI UIStartText;
    [SerializeField] private TextMeshProUGUI UIEndText;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;

    private Vector3 endLinePosition;

    private float DistanceAtBeginning;


    public void SetLevelTexts(int level)
    {

        UIStartText.text = level.ToString();
        UIEndText.text = (level + 1).ToString();
    }

    private float GetDistance()
    {
        return Vector3.Distance(playerTransform.position,endLinePosition);

    }

    private void UpdateProgressBar(float fl)
    {
        UIFillImage.fillAmount = fl;

    }

    // Start is called before the first frame update
    void Start()
    {
        endLinePosition = endLineTransform.position; // since it is constant, it is better to cache it rather than taking it at every frame
        DistanceAtBeginning = GetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(DistanceAtBeginning,0F,newDistance);
        UpdateProgressBar(progressValue);

        
    }
}
