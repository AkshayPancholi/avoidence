using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObbMath : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    public Vector3 velocity;
    public Vector3 desiredVelocity;
    public Vector3 steeringForce;
    public float maxSpeed;
    public float maxForce;
    public float maxVelocity;
    public Transform AI;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
	
    // Update is called once per frame
    void Update()
    {

        Move(); 
    }

    /* private void ObsatcleAvoidence(Transform AI, Transform target, int force)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float length = direction.sqrMagnitude;

        if (length < force)
        {
            Vector3 adjustment = Vector3.zero; 
            float diff = force - length; 

            adjustment = new Vector3(direction.x, direction.y); 
            adjustment.Normalize(); 
            adjustment *= diff; 
            velocity -= adjustment;
            float angle = Mathf.Atan2(velocity.y, velocity.x); 
            AI.transform.Rotate(0, angle, 0); 
           
        

        }


    }*/

    private void ObstacleAvoidence()
    {
        Vector3 ahead = transform.position + velocity.normalized * 10.0f; 
        Vector3 ahead2 = transform.position + velocity.normalized * 10.0f * 0.5f;

        Vector3 direction = (target.position - transform.position).normalized; 

        GameObject[] obstacles; 
        obstacles = GameObject.FindGameObjectsWithTag("obb");

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
}
