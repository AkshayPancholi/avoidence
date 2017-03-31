using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClass1 : MonoBehaviour
{

    public Vector3 position;
    public int BA;
    public Transform nodes;

   
    // List of Edge class
    List<Edge> links;
    public NodeClass1 parent;
    public GameObject Player;

    public int g = 0;

    // public float f = 0;
    public int h = 0;



    public List <NodeClass1> neighbours = null;
    // Use this for initialization
    void Start()
    {
        // New list of the class edge 
        links = new List<Edge>();

        // array of gameobjects with tag
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("waypoints"); 




        RaycastHit hit; 

        // loop used for each Gameobject in waypoints (Array of gameObject)
        foreach (GameObject waypoint in waypoints)
        {
            // Getting the distance of this node to the target node 
            float maxDis = Vector3.Distance(transform.position, waypoint.transform.position);

            // if statment if raycast is returns false from this postion to the target position and this gameobject is not equal to the waypoint (GameObjects)
            if (!Physics.Raycast(transform.position, waypoint.transform.position - transform.position, out hit, maxDis) && this.gameObject != waypoint)
            {
                //getting componenet from that waypoint (TARGET)
                NodeClass1 thatNode = waypoint.GetComponent<NodeClass1>(); 

                // New from this node to the target node
                Edge orangeX = new Edge(this, thatNode); 

                // adding this edge in the links (lists of Edge)
                links.Add(orangeX); 


            }


        }


        foreach (Edge edge in links)
        {
            // used to check if the a edge is hit to the target node
            Debug.Log(edge.startNode.name + "--->" + edge.endNode.name);
        }


    }
	
    // Update is called once per frame
    void Update()
    {
        // drawing a line for each edge in links
        foreach (Edge edge in links)
        {
            Debug.DrawLine(edge.startNode.transform.position, edge.endNode.transform.position, Color.red);
        }
    }

    // a constructor used to initialize the data members of this class
    public NodeClass1(Vector3 Postion, int AB, NodeClass1 Parent, List <NodeClass1> Neighbours = null)
    {
        position = Postion; 
        BA = AB; 
        parent = Parent; 
        neighbours = Neighbours; 
    }

    // Returnning the fcost (G + H)
    public int  fCost
    {
        get
        {
            return g + h; 
        }
    }

   


    
}
