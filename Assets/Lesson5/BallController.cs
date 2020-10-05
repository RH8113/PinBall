using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;

    private GameObject scoreText;
    private int score = 0;
   
    
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
       
    }

    
    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        
        
    }

    void OnCollisionEnter(Collision other)
    {
        this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
        
        if(other.gameObject.tag == "SmallStarTag")
        {
            Debug.Log(this.score += 10);
        }

        else if(other.gameObject.tag == "SmallCloudTag")
        {
            
            Debug.Log(this.score += 20);
        }

        else if(other.gameObject.tag == "LargeStarTag")
        {
        
            Debug.Log(this.score += 30); 
        }

        else if(other.gameObject.tag == "LargeCloudTag")
        {
           
            Debug.Log(this.score += 40);
        }
    }

   
}
