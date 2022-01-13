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

    public AudioClip pickupSoundHealthy;
    public AudioClip pickupSoundUnhealthy;
    public AudioSource audio;
    // float timeInt;
    float time = 30;

    public Text Score;

    public int itemsCollected;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = false;
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
                    ChangePos();
                    StartCoroutine(WaitForSceneLoadWin());
                }

               
            }
            else
            {
                ChangePos();
                StartCoroutine(WaitForSceneLoadLose());
            }

        }

    }

    private void OnCollisionEnter(Collision other)
    {


        switch (other.gameObject.tag)
        {
            case "Unhealthy":

                audio.PlayOneShot(pickupSoundUnhealthy);
                Destroy(other.gameObject);
                ChangePos();
                StartCoroutine(WaitForSceneLoadLose());
               
                break;
            case "Healthy":

                itemsCollected += 10;
                Score.text = "Score:  " + itemsCollected.ToString();
                audio.PlayOneShot(pickupSoundHealthy);
                Destroy(other.gameObject);
                break;
        }



        //change from if-else to switch

    }

    private IEnumerator WaitForSceneLoadWin()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameWinScene");
    }

    private IEnumerator WaitForSceneLoadLose()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameLoseScene");
    }

    private void ChangePos()
    {
        GetComponent<BoxCollider>().isTrigger = true;

    }






}
