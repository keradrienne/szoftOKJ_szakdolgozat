using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour
{
    public GameObject youWinScreen;

    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            youWinScreen.SetActive(true);
            player.velocity = new Vector2(0f, 0f);
            Time.timeScale = 0f;
        }
    }
}
