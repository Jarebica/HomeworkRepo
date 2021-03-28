using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI fruitsToCollect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void UpdatePoints(int points, int numberOfCollectables)
    {
        pointsText.text = "Current points: " + points.ToString();

        fruitsToCollect.text = "Fruits left: " + numberOfCollectables.ToString();
    }

 }