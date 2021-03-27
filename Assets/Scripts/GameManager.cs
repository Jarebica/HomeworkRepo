using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectionHandler
{
    public void PlayerDidCollectItem(GameObject item);
}

public class GameManager : MonoBehaviour, ICollectionHandler
{

    public int NumberOfCollectables;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player.collectionHandeler = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDidCollectItem(GameObject item)
    {

    }
}
