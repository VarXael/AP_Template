using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : ProjectileMethods
{

    public GameObject testArray;



    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        ApplyRandomForce(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        ProjectileLifetime();
    }

    private void FixedUpdate()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(BallIteration <= 0)
            {
                DestroyProjectile();
            }
            else
            {
                DivideMe();
            }
        }
    }



    private void DoNotCollideWithOtherSpawnedBalls()
    {

    }
}
