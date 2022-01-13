using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    public Text Score;

    public AudioClip pickupSoundHealthy;
    public AudioClip pickupSoundUnhealthy;
    public AudioSource audio;

    public int itemsCollected;

    void start()
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.93f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, -7f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);



        if (itemsCollected == 80)
        {
            ChangePos();
            StartCoroutine(WaitForSceneLoadWin());
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
        SceneManager.LoadScene("GamePLay_Level2");
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