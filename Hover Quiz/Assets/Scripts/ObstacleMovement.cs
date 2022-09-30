using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float obsSpeed = 7f;
    public float pointIncreasePerSec =1f;
    // Update is called once per frame
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        obsSpeed = 7f;
        rb.velocity = new Vector2(0, -obsSpeed);
        pointIncreasePerSec = 1f;

    }
    void Update()
    {
        //rb.velocity = Vector2.down * obsSpeed;
        //transform.position += Vector3.down * obsSpeed * Time.deltaTime;
        //Debug.Log(obsSpeed);
        obsSpeed += pointIncreasePerSec * Time.deltaTime;

    }
}
