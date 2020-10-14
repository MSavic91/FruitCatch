using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private int life;
    private int valueToAdd;

    [SerializeField]
    private Text LifeText;

    void Start()
    {
        life = 3;
        LifeText.text = life.ToString();
        Events.instance.CollectableFallOutLifeChangeEvent += AddOrSubtractLife;
        Events.instance.CollectedLifeChangeEvent += AddOrSubtractLife;
        Events.instance.StartGame += NewGameLifeReset;
    }

    public void AddOrSubtractLife(object sender, Events.CollectableEventArgs e)
    {
        if(e.collectableObjectData.LifeIfFallOut != 0)
            valueToAdd = e.collectableObjectData.LifeIfFallOut;
        else
            valueToAdd = e.collectableObjectData.LifeIfCollected;

        if (life < 5 || valueToAdd < 0)
        {
            life += valueToAdd;
            LifeText.text = life.ToString();
            //Debug.Log("Life " + life);
        }

        if (life <= 0)
        {
            Events.instance.EndGameRaiseEvent();
        }
    }

    public void NewGameLifeReset() 
    {
        life = 3;
        LifeText.text = "3";
    }

}
