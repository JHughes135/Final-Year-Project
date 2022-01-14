using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int goalpoint;
    public GameObject[] waypoints;
    public float WPradius = 3;
    public GameObject player;
    public GameObject aiCar;
    public GameObject Goal;

    // Start is called before the first frame update
    void Start()
    {
        goalpoint = Random.Range(0, 107);

        GameObject CityManager = GameObject.Find("CityManager");
        //GameObject player = GameObject.Find("Human");
        buildCity cityScript = CityManager.GetComponent<buildCity>();
        waypoints = cityScript.waypoints;

        Goal.transform.position = new Vector3(waypoints[goalpoint].transform.position.x, waypoints[goalpoint].transform.position.y + 2, waypoints[goalpoint].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, Goal.transform.position) < WPradius)
        {

            Win();

        }

        if (Vector3.Distance(aiCar.transform.position, player.transform.position) < WPradius)
        {

            GameOver();

        }
    }


    void GameOver()
    {
        Debug.Log("Game Over");
    }

    void Win()
    {
        Debug.Log("You Win!!");
    }
}

