using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public interface ICollectionHandler
{
    public void PlayerDidCollectItem(GameObject item);
}

public class GameManager : MonoBehaviour, ICollectionHandler
{

    private int numberOfCollectables;
    private int numberOfItemsCollected = 0;
    private int numberOdItemsToCollect;

    private int points;
    
    public PlayerController player;
    public UIManager uIManager;      
    public LevelLoader levelLoader;

    private int levelIndex;




    void Start()
    {
        player.collectionHandeler = this;
        numberOfCollectables = GameObject.FindGameObjectsWithTag(Tags.Collectable).Length;

        numberOdItemsToCollect = numberOfCollectables;

        uIManager.UpdatePoints(points, numberOdItemsToCollect);
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }


    public void PlayerDidCollectItem(GameObject item)
    {
        points += item.GetComponent<Collectable>().NumberOfPoints();
        numberOdItemsToCollect = numberOfCollectables - numberOfItemsCollected-1;
        uIManager.UpdatePoints(points, numberOdItemsToCollect);
        
        Destroy(item);
        numberOfItemsCollected++;

        Debug.Log("Points" + points);

        if(numberOfItemsCollected >= numberOfCollectables)
        {
            levelLoader.loadNextLevel(levelIndex);
            //SceneManager.LoadScene(SceneNames.Level1);
        }
    }
}


