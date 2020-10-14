using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }
    #endregion
    
    int score;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text EndGameScoreText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
    }

    private void Start()
    {
        Events.instance.CollectedScoreChangeEvent += AddScore;
        Events.instance.StartGame += NewGameScoreReset;
        Events.instance.EndGame += EndGame;
    }

    public void AddScore(object sender, Events.CollectableEventArgs e) 
    { 
        score += e.collectableObjectData.Points;
        ScoreText.text = score.ToString();
    }

    public void NewGameScoreReset() 
    {
        score = 0;
        ScoreText.text = "0";
    }

    public void EndGame() 
    {
        EndGameScoreText.text = score.ToString();
    }
    

}
