using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public void Seek(Transform _Target)
    {
        target = _Target; 
    }
    void Update()
    {
        Destroy(gameObject, 10f);

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    // Update is called once per frame
}
