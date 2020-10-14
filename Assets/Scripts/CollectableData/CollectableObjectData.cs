using UnityEngine;

[CreateAssetMenu]
public class CollectableObjectData : ScriptableObject
{
    //public GameObject Model;
    public int NumberOfInstances;
    public int Points;
    public int LifeIfCollected;
    public int LifeIfFallOut;
    public int TimeAdd;
    public int DiamondAdd;
    public bool Special;
    public string SpecialText;
    public bool PowerUp;
    public int PowerUpTime;
    public bool FruitWave;
    public bool CollectAll;
    public bool PointsBoost;
    public bool ResetSpeed;
    public bool LevelChange;
}
