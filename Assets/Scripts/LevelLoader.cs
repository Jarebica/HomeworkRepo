using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;



    public void loadNextLevel(int levelIndex)
    {
       StartCoroutine(loadLevel(levelIndex));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
