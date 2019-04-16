using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject[] waypoints;
    int current = 0; 
    float rotSpped;
    public float speed;
    float Wpradius = 1;
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(waypoints[current].transform.position, transform.position)< Wpradius)
        {
            current++;
            if(current >= waypoints.Length)
            {
                current = 0; 
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
		
	}
}
