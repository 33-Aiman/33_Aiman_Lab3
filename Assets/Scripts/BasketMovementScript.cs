using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    //Text and time
    public Text TimeScoreText;
    public Text HighScoreText;
    public bool timeinmain = true;
    public bool firstgame = true;
    float timeInt;
    float time;

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
        pos.y = Mathf.Clamp(pos.y,0.1f, -7f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);





    }





}
