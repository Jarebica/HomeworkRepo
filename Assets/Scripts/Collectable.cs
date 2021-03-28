using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum collectableType
{
    SmallPoints, MidiumPoints, BigPoints
}

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private collectableType type = collectableType.SmallPoints;

    private void Start()
    {
       // GetComponent<Renderer>().material.color = GetColor();
    }

    public int NumberOfPoints()
    {
        switch (type)
        {
            case collectableType.SmallPoints:
                return 10;

            case collectableType.MidiumPoints:
                return 20;

            case collectableType.BigPoints:
                return 30;
        }

        return 0;
    }

    /*
    public Color GetColor()
    {
        switch (type)
        {
            case collectableType.SmallPoints:
                return Color.grey;

            case collectableType.BigPoints:
                return Color.yellow;
        }

        return Color.white;
    }*/
}
