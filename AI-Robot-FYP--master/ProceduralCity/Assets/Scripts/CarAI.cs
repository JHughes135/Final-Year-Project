using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{

    public GameObject[] waypoints;
    public float WPradius = 1;
    public int currPoint;
    public string next;
    public float speed = 10;
    public float rotSpeed = 2f;
    int locType;
    public int nextChecked;
    public int nextInt;
    public int nextPoint;
    public int startpoint;
    public int gameover;
    public int firstMove = 0;
    public Transform Car;

    
    


    // Start is called before the first frame update
    void Start()
    {

        //startpoint of the car when it initially spawns
        startpoint = Random.Range(0, 107);
       
        GameObject CityManager = GameObject.Find("CityManager");
        buildCity cityScript = CityManager.GetComponent<buildCity>();
        waypoints = cityScript.waypoints;
        Debug.Log("waypoints " + waypoints);
        int gameover = 0;

        transform.position = new Vector3(waypoints[startpoint].transform.position.x, waypoints[startpoint].transform.position.y + 2, waypoints[startpoint].transform.position.z);

        currPoint = startpoint;

        nextChecked = Check(currPoint);
        next = Next(nextChecked);
        nextInt = Direction(next);
        nextPoint = currPoint + nextInt;

      
 
    }



    // Update is called once per frame
    void Update()
    {

    
        //If car is within radius of nextPoint update nextpoint
        if (Vector3.Distance(waypoints[nextPoint].transform.position, Car.transform.position) < WPradius){

            Debug.Log("car arrived");

            //firstMove++;
            
            currPoint = nextPoint;
        
            nextChecked = Check(currPoint);
            next = Next(nextChecked);
            nextInt = Direction(next);
            nextPoint = currPoint + nextInt;

            Vector3 direction = waypoints[nextPoint].transform.position - Car.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

            //transform.position = Vector3.MoveTowards(transform.position, waypoints[nextPoint].transform.position, Time.deltaTime * speed);

            
        }//car moves toward next point until it is inside the raduius of the waypoint
        if(Vector3.Distance(waypoints[nextPoint].transform.position, gameObject.transform.position) > WPradius){
            
                Vector3 direction = waypoints[nextPoint].transform.position - Car.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotation, rotSpeed * Time.deltaTime);

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoints[nextPoint].transform.position, Time.deltaTime * speed);
                Debug.DrawRay(transform.position, direction, Color.green);
        }

        
    }



    int Direction(string dir)
    {
        if(dir == "up")
        {

            return (-9);
        }

        else if (dir == "down")
        {

            return (9);
        }

        else if (dir == "left")
        {

            return (1);
        }

        else if (dir == "right")
        {

            return (-1);
        }
        else
        {
            return (0);
        }



    }



    string Next(int locType)
    {

        if(locType == 3)
        {
            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "down";
            }

            return next;

        }

        if (locType == 1)
        {
            int rand = Random.Range(0, 3);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "down";
            }
            else if (rand == 2)
            {
                next = "up";
            }

            return next;
        }

        if (locType == 2)
        {
            int rand = Random.Range(0, 3);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "down";
            }
            else if (rand == 2)
            {
                next = "right";
            }

            return next;
        }

        if (locType == 3)
        {
            int rand = Random.Range(0, 3);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "down";
            }
            // else if (rand == 2)
            // {
            //     next = "up";
            // }

            return next;
        }

        if (locType == 4)
        {
            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                next = "down";
            }
            else if (rand == 1)
            {
                next = "right";
            }

            return next;
        }

        if (locType == 5)
        {
            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                next = "up";
            }
            else if (rand == 1)
            {
                next = "right";
            }

            return next;
        }

        if (locType == 6)
        {
            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "up";
            }

            return next;
        }

        if (locType == 7)
        {
            int rand = Random.Range(0, 3);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "right";
            }
            else if (rand == 2)
            {
                next = "up";
            }

            return next;
        }

        if (locType == 8)
        {
            int rand = Random.Range(0, 4);

            if (rand == 0)
            {
                next = "left";
            }
            else if (rand == 1)
            {
                next = "down";
            }
            else if (rand == 2)
            {
                next = "up";
            }
            else if(rand == 3)
            {
                next = "right";
            }

            return next;
        }

        

        if (locType == 9)
        {
            int rand = Random.Range(0, 3);

            if (rand == 0)
            {
                next = "right";
            }
            else if (rand == 1)
            {
                next = "down";
            }
            else if (rand == 2)
            {
                next = "up";
            }

            return next;
        }

        return("error");


    }

    int Check(int currentLoc)
    {

        int other = 0;
      
        if ((currentLoc % 9 == 0) && (currentLoc != 99) )
        {
            locType = 1;
            other++;
            
        }
        else if ((currentLoc >= 1) && (currentLoc <= 7))
        {
            locType = 2;
            other++;
            
        }
        else if (currentLoc == 0)
        {
            locType = 3;
            other++;
           
        }
        else if (currentLoc == 8)
        {
            locType = 4;
            other++;
            
        }
        else if (currentLoc == 107)
        {
            locType = 5;
            other++;
           
        }
        else if (currentLoc == 99)
        {
            locType = 6;
            other++;
            
        }
        else if ((currentLoc >= 100) && (currentLoc <= 106))
        {
            locType = 7;
            other++;
            
        }
        else if (other != 1) 
        {
            locType = 8;
        } 
        else if((currentLoc == 17) || (currentLoc == 26) || (currentLoc == 35) || (currentLoc == 44) || (currentLoc == 53) || (currentLoc == 62) || (currentLoc == 71) || (currentLoc == 80) || (currentLoc == 89) || (currentLoc == 98)){
            locType = 9;
            other++;
        }


        return (locType);
    }
}
