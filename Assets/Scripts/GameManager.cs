using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager _instance;


    public TextMeshProUGUI PointsText;
    public int Points = 0;

     public TextMeshProUGUI PostGamePointsText;

    public TextMeshProUGUI HighScoreText;

    public TextMeshProUGUI HealthText;
    public int Health = 3;
    public bool isDead = false;

    public GameObject UIInGameGroup;
    public GameObject UIPostDeathGroup;

    // Start is called before the first frame update
     private void Awake() 
    {
        if (_instance == null)
        _instance = this;
    }

    void Update()
    {
        HealthText.text = "Lives: " + Health.ToString();
        PointsText.text = "Points: " + Points.ToString();

        if (Health <= 0)
        {
            
            //highscore check 
            if (!PlayerPrefs.HasKey("HighScore")) //no playerprefs, set score
            {
                PlayerPrefs.SetInt("HighScore", Points);

            }
            else
            {
                if (Points > PlayerPrefs.GetInt("HighScore"))
                {
                      PlayerPrefs.SetInt("HighScore", Points);
                }
            }
            isDead = true;
            Time.timeScale = 0;
            UIInGameGroup.SetActive(false);
            UIPostDeathGroup.SetActive(true);

            PostGamePointsText.text = "Your score was: " + Points;
            HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                Health = 3;
                Points = 0;
                Time.timeScale = 1;
                isDead = false;
                UIInGameGroup.SetActive(true);
                UIPostDeathGroup.SetActive(false);

                SceneManager.LoadScene(0);
            }

        }
    }
}
