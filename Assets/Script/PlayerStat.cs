using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    public int HP;
    public int TotalHP;
    public TextMeshProUGUI HowManyLiveLeft;
    public GameObject LoseScene;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FinalScore;
    
    public int scoreIncrement = 1; 
    public float interval = 10f;
    
    private int score = 0;
    private float timer = 0f;
    
    public int KillPrize = 50;

    void Start()
    {
        TotalHP = HP;
    }

    void Update()
    {
        HowManyLiveLeft.text = " " + TotalHP.ToString();
        scoreText.text = "Score: " + score;

        timer += Time.deltaTime;

        if (timer >= interval){
            score += scoreIncrement;

            timer = 0f;

            if (scoreText != null){
                scoreText.text = "Score: " + score;
            }
        }
        
    }

    public void ReduceHP(){
        TotalHP = TotalHP - 1;
        if(TotalHP == 0){
            Destroy(gameObject);
            LoseScene.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GoneHP(){
        Destroy(gameObject);
        LoseScene.SetActive(true);
        FinalScore.text = "FinalScore: " + score;
        Time.timeScale = 0;
    }

    public void KillEnemy(){
        score = score + KillPrize;
    }
}

