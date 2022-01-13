using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Text and time
    public Text TimeScoreText;

    public bool timeinmain = true;
    public bool firstgame = true;
    // float timeInt;
    float time = 100;

    public Text Score;

    public int itemsCollected;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeinmain == true)
        {
            time -= Time.deltaTime;
            //timeInt = Mathf.FloorToInt(time % 60);
            TimeScoreText.text = "Time: " + time.ToString();

            if (time >= 0)
            {
                if (itemsCollected == 80)
                {
                    SceneManager.LoadScene("GameWinScene");
                }
            }

        }
    }
}
