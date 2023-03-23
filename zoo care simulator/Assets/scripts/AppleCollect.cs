using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Nibbler")
        {
            ScoreText.points = ScoreText.points + 15;
            Destroy(gameObject);
            Debug.Log("Apple collected!");
        }
    }
}
