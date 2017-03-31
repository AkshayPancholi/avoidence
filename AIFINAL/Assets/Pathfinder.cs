using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    public Transform player;
    public Transform enemy;


    public NodeClass1[] areaGraph;

    // NodeClass1[] openList;
    // NodeClass1[] closedList;
   





    // Use this for initialization
    void Start()
    {

        //findPath(); 


    }
	
    // Update is called once per frame
    void Update()
    {
    }

   


    public void findPath(Vector3 startPos, Vector3 targetPos)
    {

       
        /* // setting start and target postion 
        NodeClass1 = startPos; 
        NodeClass1 = targetPos; 

        // List of open and close list of nodes (waypoint)

        List<NodeClass1> openList = new List<NodeClass1>(); 
        List <NodeClass1> closedList = new List<NodeClass1>();
        openList.Add(startPos); 


        while (openList.Count > 0)
        {
            
        }*/










    }



    // Finding nearesest node (Waypoint)
    GameObject findNearsest()
    {
        // Array of game object (waypoints) and finding them with waypoints 
        GameObject[] waypoints;
        waypoints = GameObject.FindGameObjectsWithTag("waypoints");

        // Gameobject 
        GameObject closest = null; 

        // Current position of seeker (player/AI)
        Vector3 currentPos = transform.position; 

        // constant distance 
        float distance = Mathf.Infinity; 


        // Used loop for each waypoints 
        foreach (GameObject waypoint in waypoints)
        {
            // getting distance from node (waypoint) to the position of seeker (AI/Player)
            float diff = Vector3.Distance(waypoint.transform.position, currentPos); 

            // if statement
            // if distnace (diff) is less than constant distance 
            if (diff < distance)
            {
                closest = waypoint; 
                distance = diff; 
            }
        }
        // returning closest gameobject after loop 
        return closest; 


    }

}
