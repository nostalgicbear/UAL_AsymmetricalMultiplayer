//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class MoveCamera : MonoBehaviour
    {
        public Transform player;
        public Transform moveableCamera;
        public string targetTag;
        
        public bool destroyOnTargetCollision = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals(targetTag))
            {
                ContactPoint contact = collision.contacts[0];
                RaycastHit hit;

                float backTrackLength = 1f;
                Ray ray = new Ray(contact.point - (-contact.normal * backTrackLength), -contact.normal);
                if (collision.collider.Raycast(ray, out hit, 2))
                {                      
                    moveableCamera.position = contact.point;
                    moveableCamera.forward = player.position - moveableCamera.position;
                    moveableCamera.GetComponent<ControlCamera>().SetCameraAttached(moveableCamera.forward);
                    
                }
                //Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 5, true);

                if (destroyOnTargetCollision)
                    Destroy(this.gameObject);
            }
        }
    }
}