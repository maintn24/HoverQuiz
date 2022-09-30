using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public UnityEngine.GameObject obstacle;
    public float width = 3f;

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            UnityEngine.GameObject newobs = Instantiate(obstacle);
            newobs.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            Destroy(newobs, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
