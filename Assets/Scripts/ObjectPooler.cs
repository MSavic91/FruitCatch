using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
        public string Tag;
        public List<GameObject> ListOfObjects;
    }

    #region Singletone
    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, List<GameObject>> poolDictionary;
    public List<GameObject> ActiveGameObjects;

    
    void Start()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();

        foreach (var pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            foreach (GameObject gameObject in pool.ListOfObjects)
            {
                int numberOfObjectInstances = gameObject.GetComponent<CollectableDataHolder>().collectableObjectData.NumberOfInstances;
                for (int i = 0; i <= numberOfObjectInstances; i++)
                {
                    var newGameObjectInstance = Instantiate(gameObject);
                    newGameObjectInstance.transform.parent = this.gameObject.transform;
                    newGameObjectInstance.SetActive(false);
                    objectPool.Add(newGameObjectInstance);
                }
            }
            poolDictionary.Add(pool.Tag, objectPool); 
        }

        Events.instance.CollectableFallOutLifeChangeEvent += ReturnToPool;
        Events.instance.CollectedLifeChangeEvent += ReturnToPool;
        Events.instance.CollectedScoreChangeEvent += ReturnToPool;
        Events.instance.CollectedTimeChangeEvent += ReturnToPool;
        Events.instance.EndGame += DeactivateAllObjects;

    }

    public void SpawnFromPool(string poolTag, Vector3 position, Quaternion rotation) 
    {
        GameObject objectToSpawn = null;

        do
        {
            objectToSpawn = poolDictionary[poolTag].ElementAt(Random.Range(0, poolDictionary[poolTag].Count));
        }
        while (objectToSpawn.activeSelf);
    
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        ActiveGameObjects.Add(objectToSpawn);
    }

    private void ReturnToPool(object sender, Events.CollectableEventArgs e)
    {
        e.collectableGameObject.SetActive(false);
        ActiveGameObjects.RemoveAt(ActiveGameObjects.IndexOf(e.collectableGameObject));
    }

    private void DeactivateAllObjects() 
    {
        foreach (GameObject gameObject in ActiveGameObjects)
        {
            gameObject.SetActive(false);
        }
    }

}
