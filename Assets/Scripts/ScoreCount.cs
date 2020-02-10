using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxdifficultyLevel = 0;
    private int scoreToNextLevel = 0;
    
    public Text scoreText;
    public DeathMenu deathMenu;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        return;

        if(score <= scoreToNextLevel)
        levelUP();

        score += Time.deltaTime * difficultyLevel ;
        scoreText.text = ((int)score).ToString();
        //Debug.Log("score"+score);

    }

    void levelUP()
    {
        if(difficultyLevel == maxdifficultyLevel)
        return;

        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<Movement>().setSpeed (difficultyLevel);
        Debug.Log(difficultyLevel);

    }
    
     public void onDeath()
     {
        isDead = true;
        //saving the score
        if(PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore",score);
        
        deathMenu.ToggleEndMenu(score);
        //Debug.Log("OD");
     }
     
}
