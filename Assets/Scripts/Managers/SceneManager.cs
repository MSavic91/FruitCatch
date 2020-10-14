using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameScreen;
    [SerializeField]
    private GameObject EndGameScreen;

    void Start()
    {
        Events.instance.EndGame += EndGameScreenActivate;
    }

    public void RetryButtonClick() 
    {
        EndGameScreen.SetActive(false);
        GameScreen.SetActive(true);
        Events.instance.StartGameRaiseEvent();
    }

    public void EndGameScreenActivate() {
        EndGameScreen.SetActive(true);
        GameScreen.SetActive(false);
    }
}
