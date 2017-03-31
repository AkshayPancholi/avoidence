using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avoidence : MonoBehaviour
{


    public Transform target;
    Rigidbody rb;

    float rayRange = 10.0f;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	
    // Update is called once per frame
    void Update()
    {




        // Setting direction and distance

        Vector3 direction = (target.position - transform.position).normalized;
      
        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;

        //  if shooting a raycats from all the three side of this object with distance to travel

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        {
            
            // if ray not hitting this object and hitting the gameobjects with tag 
            if (hit.collider.gameObject.CompareTag("obb"))
            {
                // startRay += Time.time * 1.0f; 
                Debug.DrawLine(transform.position, transform.position + transform.forward * rayRange, Color.red);
                Vector3 hitNormal = hit.point + hit.normal;
                hitNormal.y = 0.0f;
                //adding normalized hit direction with some pulling away type force
                direction = transform.forward + hitNormal * 300.0f; 
                //transform.Rotate(Vector3.up * Time.deltaTime * 20);




            }



        }

       


        // To create two raycast left and rigth (to avoid corners
        Vector3 left = transform.position;
         
        Vector3 right = transform.position;
       

        if (Physics.Raycast(right + (transform.right), transform.forward, out hit, rayRange))
        {
            // if ray not hitting this object and hitting the gameobjects with tag 
            if (hit.collider.gameObject.CompareTag("obb"))
            {
                // startRay += Time.time * 1.0f; 
                Debug.DrawRay(transform.position, hit.point, Color.red);

                Vector3 hitNormal = hit.normal;
                //adding normalized hit direction with some pulling away type force
                direction += hitNormal * 30.0f; 



            }
        }

        if (Physics.Raycast(left - (transform.right), transform.forward, out hit, rayRange))
        {
            // if ray not hitting this object and hitting the gameobjects with tag 
            if (hit.collider.gameObject.CompareTag("obb"))
            {
                // startRay += Time.time * 1.0f; 
                Debug.DrawRay(transform.position, hit.point, Color.red);
                Vector3 hitNormal = hit.normal;

                //adding normalized hit direction with some pulling away type force
                direction += hitNormal * 30.0f;

            }
        }


        Quaternion torotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, torotation, Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * 5f);

   
    }
}
