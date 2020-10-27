using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool levelLoaded;

    public bool EndSceneLoaded;

    private void Start()
    {
        StartCoroutine(LoadingMap());
    }

    public void LoadGoodFinal()
    {
        SceneManager.LoadScene("Good");
    }

    public void LoadBadFinal()
    {
        SceneManager.LoadScene("Bad");
    }
    private IEnumerator LoadingMap()
    {
        //Loads the map, and then starts the level
        PlayerController.speed = 10000;
        yield return new WaitForSeconds(0.1f);
        levelLoaded = true;
    }

    public IEnumerator LoadAnimationScene()
    {
        //Loads the map, and then starts the level
        PlayerController.speed = 10000;
        yield return new WaitForSeconds(0.1f);
        EndSceneLoaded = true;
    }
}
