using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : Box
{
    public float timer = 0f;
    public float maxTimer = 10f;
    public bool isHeld = false;
    public float blastRadius = 9f;
    public float blastForce = 11f;
    public bool hasExploded = false;

    public override void PickUp()
    {
        base.PickUp();
        Debug.Log("aaaaaaaaaah");
        isHeld = true;

    }

    public override void PutDown()
    {
        base.PutDown();
        Debug.Log("wow!");
        isHeld = false;
    }


    void Update()
    {
        if (isHeld == true && timer >= 0f)
        {
            timer = timer - Time.deltaTime;
        }


        if (isHeld == false && timer <= maxTimer)
        {
            timer = timer + Time.deltaTime;
        }

        if (timer <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius);
            }
        }


        Destroy(gameObject);
    }
  



    // why no work?
    
}
