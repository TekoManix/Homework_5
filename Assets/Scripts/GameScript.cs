using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //=========== GUI Elements 
    public TextMeshProUGUI score;   //Tells us the score of the player 
    public TextMeshProUGUI live;   //Tells us how many lives the player has 

    private int scoreCount = 0;   //Keeps Track of the score 
    private int liveCount = 3;   //Keeps Track of the lives left 

    //========== Ball Controls 
    public GameObject ball;
    public Transform spawnPoint;

    //========== Spike Controls 
    public List<Transform> point;  //Holds all of the points that the spike goes through 
    public float speed = 5;         //The Speed of the spikes movement 
    private int index = 0;          //Which index that spike is moving towards 

    //========== Level Controls 
    public string levelName;

    //Base Functions

    //Preset the texts 
    private void Start()
    {
        score.text = "0";
        //Present the Text to values of 0
    }

    // Update is called once per frame
    void Update()
    {
        //Tells it to move from currently standing in point, to given point at the given speed 
        transform.position = Vector3.MoveTowards(transform.position, point[index].position,
                    speed * Time.deltaTime);
        //Rotate to the direction 
        transform.rotation = point[index].rotation;
        //Checks if the enemy reached their goal 
        if (transform.position == point[index].position)
        {
            //If it's the last spot reset 
            if (index == point.Count - 1)
            {
                index = 0;
            }
            //else just go to next point in the list 
            else
            {
                index++;
            }
        }
    }
    //Extra Functions 
   
    //Lowers the counter of lives, and updates the text 
    public void SpikeUpdate()
    {
        liveCount--;
        live.text = "Life:" + liveCount;
        //Update the text 
        if (liveCount == 0)
        {
            ReturnToMain();
        }
    }


    //Increase the score and updates the text 
    public void GoalKeeper()
    {
        scoreCount++;

        score.text = "Score: " + scoreCount;
    }

    //Creates a new ball
    public void SpawnBall()
    {
        var pos = new Vector3(0, 0, 0);
        var spawn = Instantiate(ball, pos, Quaternion.identity);
        //Create Ball
    }

    //Sends the game back to the main menu scene 
    private void ReturnToMain()
    {
        SceneManager.LoadScene(levelName);
        //Send back to the main menu
    }
}
