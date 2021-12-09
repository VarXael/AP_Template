using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour {

    public GameObject Projectile;

    public GameObject SpawningPos;

    private float currentFireRate = 0;

    public float shootingFireRate;

    public bool manualShooting;

    public float cannonRotSpeed;
    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SwitchBetweenAutoAndManual();
    }


    private void ShootProjectile()
    {
        Instantiate(Projectile, SpawningPos.transform.position, Quaternion.identity);
    }

    private void ShootingFireRate()
    {
        if(currentFireRate >= shootingFireRate)
        {
            Instantiate(Projectile, SpawningPos.transform.position, Quaternion.identity);
            currentFireRate = 0;
        }
        else
        {
            currentFireRate += Time.deltaTime;
        }
    }

    private void SwitchBetweenAutoAndManual()
    {
        if (manualShooting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootProjectile();
            }
        }
        else
        {
            ShootingFireRate();
        }
    }

    private Quaternion lerpStart;
    private Quaternion lerpEnd;
    private float lerpT;


    private void RestartCannonLerp()
    {
        lerpStart = transform.rotation;
        lerpEnd = Random.rotation;
        lerpT = 0;
    }

    private void LerpCannonRot(Quaternion lerpStart, Quaternion lerpEnd)
    {
        transform.rotation = Quaternion.Slerp(lerpStart, lerpEnd, lerpT);

        lerpT = lerpT + Time.deltaTime * cannonRotSpeed;
    }
}
