using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aviod : MonoBehaviour
{


    public Transform target;
    Rigidbody rb;

    float rayRange = 10.0f;
    float force = 2000.0f;
    Vector3 direction;

    public Vector3 velocity;
    public Vector3 desiredVelocity;
    public Vector3 steeringForce;
    public float maxSpeed;
    public float maxForce;
    public float maxVelocity;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {


        Obstacle();





        //transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        Move();

    }

    private void Move()
    {
        velocity = rb.velocity;
        desiredVelocity = Vector3.Normalize(target.position - transform.position) * maxVelocity;
        steeringForce = desiredVelocity - velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
        steeringForce = steeringForce / rb.mass;
        velocity = Vector3.ClampMagnitude(velocity + steeringForce, maxSpeed);
        transform.position += velocity;
    }

    private void Obstacle()
    {
        // Setting direction and distance



        RaycastHit hit;


        Vector3 left = transform.position - (transform.right * 0.25f);

        Vector3 right = transform.position + (transform.right * 0.25f);
        //  if shooting a raycats from all the three side of this object with distance to travel

        /*  if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        {

            // if ray not hitting this object and hitting the gameobjects with tag 
            if (hit.transform != transform && hit.collider.gameObject.CompareTag("obb"))
            {
                // startRay += Time.time * 1.0f; 
                Debug.DrawLine(transform.position, transform.position + transform.forward * rayRange, Color.red);
                Vector3 hitNormal = hit.point + hit.normal;
                hitNormal.y = 0.0f;
                //adding normalized hit direction with some pulling away type force
                direction += hitNormal * force; 
                //transform.Rotate(Vector3.up * Time.deltaTime * 20);




            }



        }*/
        Vector3 direction = (target.position - transform.position);


        RaycastHit hit2;
        RaycastHit hit3;


        // To create two raycast left and rigth (to avoid corners



        if (Physics.Raycast(right, transform.forward, out hit, rayRange))
        {
            // if ray not hitting this object and hitting the gameobjects with tag 
            if (hit.collider.gameObject.CompareTag("obb"))
            {
                // startRay += Time.time * 1.0f; 
                Debug.DrawRay(transform.position, hit.point, Color.red);

                Vector3 hitNormal = hit.normal;
                //adding normalized hit direction with some pulling away type force
                // direction += hitNormal * force; 


                Vector3 directionalForce = -direction * 20.0f; 
                rb.AddForce(directionalForce);

            }



        }
        else if (Physics.Raycast(left, transform.forward, out hit, rayRange))
        {
            // if ray not hitting this object and hitting the gameobjects with tag 
            if (hit.collider.gameObject.CompareTag("obb"))
            {
                // startRay += Time.time * 1.0f; 
                Debug.DrawRay(transform.position, hit.point, Color.red);
                Vector3 hitNormal = hit.normal;

                //adding normalized hit direction with some pulling away type force
                //direction += hitNormal * force;

                Vector3 directionalForce = -direction * 20.0f; 
                rb.AddForce(directionalForce);
                    
            }


        }
        Quaternion torotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, torotation, Time.deltaTime);

    }
}
