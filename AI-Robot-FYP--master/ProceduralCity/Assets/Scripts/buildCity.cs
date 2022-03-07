using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some of this code was gathered from tutorials and other online resources BuildCity

public class buildCity : MonoBehaviour
{

    public GameObject[] buildings;
    public GameObject xstreets;
    public GameObject zstreets;
    public GameObject crossroad;
    public GameObject Waypoint;
    public GameObject[] waypoints;
    public int mapWidth = 100;
    public int mapHeight = 100;
    int buildingFootprint = 24;
    int[,] mapgrid;
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        mapgrid = new int[mapWidth, mapHeight];
        

        for (int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapHeight; w++)
            {
                mapgrid[w,h] = (int) (Mathf.PerlinNoise(w / 10.0f, h / 10.0f) * 10);
                
            }
        }
        


        //build streets
        int x = 0;
        for(int n = 0; n < 50; n++)
        {
            for(int h = 0; h < mapHeight; h++)
            {
                mapgrid[x, h] = -1;
            }
            x += Random.Range(4, 4);
            if (x >= mapWidth)
                break;
        }

        int z = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                Debug.Log(z);
                if (mapgrid[w, z] == -1)
                    mapgrid[w, z] = -3;
                else
                    mapgrid[w, z] = -2;
              
            }
            z += Random.Range(3, 3);
            if (z >= mapHeight)
                break;
        }
        for (int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                
                int result = mapgrid[w, h];
                Debug.Log(result);
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                if (result < -2)
                {
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
                    waypoints[i] = Instantiate(Waypoint, pos, Waypoint.transform.rotation) as GameObject;
                    i++;

                    Debug.Log("mapgrid: " + waypoints);
                }
                else if (result < -1)
                {
                    Instantiate(xstreets, pos, xstreets.transform.rotation);
                }
                else if (result < 0)
                {
                    Instantiate(zstreets, pos, zstreets.transform.rotation);
                }
                else if (result < 3)
                {
                    Instantiate(buildings[0], pos, Quaternion.identity);
                }
                else if (result < 5)
                {
                    Instantiate(buildings[1], pos, Quaternion.identity);
                }
                else if (result < 7)
                {
                    Instantiate(buildings[2], pos, Quaternion.identity);
                }
                else if (result < 8)
                {
                    Instantiate(buildings[3], pos, Quaternion.identity);
                }
                else if (result < 10)
                {
                    Instantiate(buildings[4], pos, Quaternion.identity);
                }

            }
        }
        
    }

}
