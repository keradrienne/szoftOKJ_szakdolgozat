using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreScript : MonoBehaviour
{
    public static int score = 0;

    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.active = true)
            scoreText.GetComponent<UnityEngine.UI.Text>().text = (score + " / 10").ToString();
            
    }
}
