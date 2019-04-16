using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonEffect : MonoBehaviour {

    public ParticleSystem particles;

    private void OnCollisionEnter(Collision collision)
    {
     
        foreach(ContactPoint contact in collision.contacts)
        {
            GameObject particle = Instantiate(particles.gameObject, contact.point, Quaternion.LookRotation(contact.normal));
            Destroy(this.gameObject);
            if (collision.gameObject.tag == "Enemy")
            {
              
            }
            Destroy(gameObject.GetComponentInParent(typeof(ParticleSystem)),1);
            Destroy(particle, 2);

        }
    }
}
