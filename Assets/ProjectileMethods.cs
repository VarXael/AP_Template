using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMethods : MonoBehaviour {

    public Rigidbody rb;

    public GameObject Projectile;
    
    private float currentLifeTime;

    public float projectileLifeTime;
    
    public int BallIteration;

    public float forceStrenght;

    public float divideOffSet;

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }


    public void DivideMe()
    {
        SpawnAndManageProjectile(SpawnSmallerProjectileLeft());
        SpawnAndManageProjectile(SpawnSmallerProjectileRight());
        Destroy(gameObject);
    }

    private void SpawnAndManageProjectile(GameObject Projectile)
    {
        Projectile.transform.localScale = Projectile.transform.localScale / 2;
        Projectile.GetComponent<ProjectileScript>().BallIteration--;
        Projectile.GetComponent<Rigidbody>().velocity = rb.velocity; //mantain momentum.
    }

    private GameObject SpawnSmallerProjectileLeft()
    {
        GameObject p1 = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z + divideOffSet), Quaternion.identity);
        return p1;
    }
    private GameObject SpawnSmallerProjectileRight()
    {
        GameObject p2 = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z - divideOffSet), Quaternion.identity);
        return p2;
    }

    public void ApplyRandomForce(GameObject objectToApplyForceTo)
    {
        rb.AddForce((new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)) - objectToApplyForceTo.transform.position) * forceStrenght);
    }



    public void ProjectileLifetime()
    {
        if (currentLifeTime >= projectileLifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            currentLifeTime += Time.deltaTime;
        }
    }
}
