using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBody : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 initialVelocity;

    void Start()
    {
        GravityManager.Instance.AddToList(this);
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(initialVelocity);
    }
    void OnDestroy()
    {
        GravityManager.Instance.RemoveFromList(this);
    }
}
