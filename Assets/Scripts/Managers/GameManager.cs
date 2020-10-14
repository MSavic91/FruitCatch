using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timerCollectables, randomTimerValueCollectables, timerSpecials;
    private bool GameActive = true;

    void Start()
    {
        randomTimerValueCollectables = Random.Range(0.1f, 2);
        Events.instance.EndGame += GameEnded;
        Events.instance.StartGame += GameStarted;
    }

    void Update()
    {
        if (GameActive)
        {
            timerCollectables = CollectablesSpawner(timerCollectables, 1.5f, "CollectableObjects");
            timerSpecials = CollectablesSpawner(timerSpecials, 5f, "Specials");
        }
    }

    private float CollectablesSpawner(float Timer, float RandomTimerValue, string PoolTag) 
    {
        if (Timer > RandomTimerValue)
        {
            ObjectPooler.instance.SpawnFromPool(PoolTag, new Vector3(Random.Range(-2.3f, 2.3f), 5.3f, 0), Quaternion.identity);
            Timer = 0;
        }
        return Timer += Time.deltaTime;
    }

    private void GameEnded() => GameActive = false;
    private void GameStarted() => GameActive = true;


}
