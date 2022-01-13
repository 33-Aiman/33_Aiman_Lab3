using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript_level2 : MonoBehaviour
{
    public float speed;

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

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.93f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, -7f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);



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

    private void OnCollisionEnter(Collision other)
    {


        switch (other.gameObject.tag)
        {
            case "Unhealthy":

                Destroy(other.gameObject);
                SceneManager.LoadScene("GameLoseScene");


                break;
            case "Healthy":

                itemsCollected += 10;
                Score.text = "Score:  " + itemsCollected.ToString();

                Destroy(other.gameObject);
                break;
        }



        //change from if-else to switch

    }






}
