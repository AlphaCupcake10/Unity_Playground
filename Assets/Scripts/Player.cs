using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 100;
    Vector2 moveDirection;
    float angle;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void PlayerInput()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        angle = Mathf.Atan2(worldPosition.y-transform.position.y,worldPosition.x-transform.position.x) * Mathf.Rad2Deg;

        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        transform.rotation = Quaternion.AngleAxis(angle,transform.forward);
    }
    void FixedUpdate()
    {
        rb.AddForce(moveDirection*moveForce*50);
    }
}
