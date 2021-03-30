using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public interface IRealCollectionHandler
{
    public void PlayerDidCollectItem(GameObject item);
}
public class RealGameManager : MonoBehaviour, IRealCollectionHandler

{

    private int numberOfCollectables;
    private int numberOfItemsCollected = 0;
    private int numberOdItemsToCollect;

    private int points;

    public RealPlayerController player;
    public UIManager uIManager;
    public LevelLoader levelLoader;

    private int levelIndex;


    void Start()
    {
        player.realCollectionHandeler = this;
        numberOfCollectables = GameObject.FindGameObjectsWithTag(Tags.Collectable).Length;

        numberOdItemsToCollect = numberOfCollectables;

        uIManager.UpdatePoints(points, numberOdItemsToCollect);
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
    }


    public void PlayerDidCollectItem(GameObject item)
    {
        points += item.GetComponent<Collectable>().NumberOfPoints();
        numberOdItemsToCollect = numberOfCollectables - numberOfItemsCollected - 1;
        uIManager.UpdatePoints(points, numberOdItemsToCollect);

        Destroy(item);
        numberOfItemsCollected++;

        Debug.Log("Points" + points);

        if (numberOfItemsCollected >= numberOfCollectables)
        {
            levelLoader.loadNextLevel(levelIndex);
            //SceneManager.LoadScene(SceneNames.Level1);
        }
    }
}
