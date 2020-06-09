using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.3f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;
    private float timer;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0;
                FireGun();
            }
        }
    }

    private void FireGun()
    {

        muzzleParticle.Play();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
        }

    }
}
