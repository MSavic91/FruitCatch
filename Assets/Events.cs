using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Events instance;

    public event Action StartGame, EndGame;

    public event EventHandler<CollectableEventArgs> CollectedScoreChangeEvent;
    public event EventHandler<CollectableEventArgs> CollectableFallOutLifeChangeEvent;
    public event EventHandler<CollectableEventArgs> CollectedLifeChangeEvent;
    public event EventHandler<CollectableEventArgs> CollectedTimeChangeEvent;
    public event EventHandler<CollectableEventArgs> CollectedInfoChangeEvent;
    public class CollectableEventArgs : EventArgs
    {
        public CollectableObjectData collectableObjectData;
        public GameObject collectableGameObject;
    }


    private void Awake()
    {
        instance = this;
    }

    public void StartGameRaiseEvent() 
    {
        StartGame?.Invoke();
    }
    public void EndGameRaiseEvent()
    {
        EndGame?.Invoke();
    }

    public void CollectedLifeChangeRaiseEvent(GameObject gameObject, CollectableObjectData CollectableObjectData)
    {
        CollectedLifeChangeEvent?.Invoke(this, new CollectableEventArgs { collectableGameObject = gameObject, collectableObjectData = CollectableObjectData });
    }
    public void CollectedScoreChangeRaiseEvent(GameObject gameObject, CollectableObjectData CollectableObjectData)
    {
        CollectedScoreChangeEvent?.Invoke(this, new CollectableEventArgs { collectableGameObject = gameObject, collectableObjectData = CollectableObjectData });
    }
    public void CollectableFallOutLifeChangeRaiseEvent(GameObject gameObject, CollectableObjectData CollectableObjectData)
    {
        CollectableFallOutLifeChangeEvent?.Invoke(this, new CollectableEventArgs { collectableGameObject = gameObject, collectableObjectData = CollectableObjectData });
    }

    public void CollectedTimeChangeRaiseEvent(GameObject gameObject, CollectableObjectData CollectableObjectData)
    {
        CollectedTimeChangeEvent?.Invoke(this, new CollectableEventArgs { collectableGameObject = gameObject, collectableObjectData = CollectableObjectData });
    }

    public void CollectedInfoChangeRaiseEvent(GameObject gameObject, CollectableObjectData CollectableObjectData)
    {
        CollectedInfoChangeEvent?.Invoke(this, new CollectableEventArgs { collectableGameObject = gameObject, collectableObjectData = CollectableObjectData });
    }

}
