using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    private int highscorea;
    // Start is called before the first frame update
    void Start()
    {
        highscorea=((int)PlayerPrefs.GetFloat("Highscore"));
        highscoreText.text = "Highscore : " +highscorea.ToString();
       // Debug.Log("Highscore : " + highscorea);
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

}
