using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Barrel;
    public float force = 100;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject spawned = Instantiate(BulletPrefab,Barrel.position,Barrel.rotation);
        Rigidbody2D rbs = spawned.GetComponent<Rigidbody2D>();
        if(rbs != null)
        {
            rbs.AddForce(Barrel.right*force*Time.deltaTime,ForceMode2D.Impulse);
            rb.AddForce(-Barrel.right*force*2*Time.deltaTime,ForceMode2D.Impulse);
        }
        Destroy(spawned,4);
    }
}
