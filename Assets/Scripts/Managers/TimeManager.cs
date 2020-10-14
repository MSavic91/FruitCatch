using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float time = 60;
    bool gameStart = true;
    
    [SerializeField]
    private Text TimeText;

    private void Start()
    {
        Events.instance.CollectedTimeChangeEvent += addTime;
        Events.instance.EndGame += gameEnded;
        Events.instance.StartGame += gameStarted;
    }

    void Update()
    {
        if (gameStart)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            Events.instance.EndGameRaiseEvent();
        }
        TimeText.text = time.ToString();
    }

    private void gameEnded()
    {
        gameStart = false;
    }

    public void gameStarted() 
    {
        gameStart = true;
        time = 60;
    }

    public void addTime(object sender, Events.CollectableEventArgs e) 
    { 
        time += e.collectableObjectData.TimeAdd; 
        //Debug.Log("Score " + time); 
    }



}
