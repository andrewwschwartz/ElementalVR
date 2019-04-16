using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Projectile : MonoBehaviour
    {

        //init variables

        //input Action
        public SteamVR_Action_Boolean action;
        //spawn location
        public Hand hand;
        //projectile prefab
        public Rigidbody projectile;
        //force of projectile
        public float projectileSpeed;
        public GameObject firePoint; 

        //direction of projectile


        //methods

        //action event -- the trigger is pulled

        // projectile is spawned at spawn location, goes forward in direction, is destroyed after certain distance or time





        //    use this for initialization

        void Start()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();


            action.AddOnChangeListener(OnShootActionChange, hand.handType);
        }

        //    update is called once per frame
        //void Update()
        //{
        //    if (action.state)
        //    {
        //        Shoot();
        //    }
            


        //}
        private void OnShootActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
            if (newValue)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Rigidbody shot = Instantiate(projectile,firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
            shot.AddForce(firePoint.transform.forward * projectileSpeed);
            Destroy(shot.gameObject, 5.0f);

        }

        void Update()
        {
           // Shoot(); 
        }


    }

}