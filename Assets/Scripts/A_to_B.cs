using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_to_B : MonoBehaviour
{
    public float speed;

    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        transform.position = pointA;
        target = pointB;
        
    }
        


    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            // Swap the position of the cylinder.
            if (target == pointA)
            {
                target = pointB;
            }

            else if (target == pointB)
            {
                target = pointA;
            }
        }
    }


}