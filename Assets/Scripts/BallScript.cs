using UnityEngine;

public class BallScript : MonoBehaviour
{

    public GameScript gameScript;   //Connects to game controlling script that will let you update 

    //Connects the new ball to the Game Script 
    private void Start()
    {
        gameScript = GameObject.Find("SpikeParent").transform.Find("Spike").GetComponent<GameScript>();
    }

    //===============================================================
    //Extra Functions 
    //===============================================================

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the ball collided with a spike 
        if (other.CompareTag("Spike"))
        {
            gameScript.SpikeUpdate();
            Destroy(gameObject);
        }
        //Checks if the ball has collided with the goal 
        else if (other.CompareTag("Goal"))
        {
            gameScript.GoalKeeper();
            Destroy(gameObject);
        }
    }

}
