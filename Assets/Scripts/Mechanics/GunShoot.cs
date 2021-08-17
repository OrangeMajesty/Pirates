using System;
using Core;
using Models;
using UnityEngine;

namespace Mechanics
{
    public class GunShoot : MonoBehaviour
    {
        public BulletModel bulletModel = Simulation.GetModel<BulletModel>();
        public float bulletSpeed = 30f;
        public float cooldown = .8f;
        public float nextShoot;

        public void Shoot(Vector3 target, string senderTag = null)
        {
            if (nextShoot > Time.time)
                return;
            
            var bullet = Instantiate(bulletModel.prefab, transform.position, Quaternion.identity);
            if (bullet.TryGetComponent(out Rigidbody2D rigidbody))
            {
                var heading = target - transform.position;
                var vector = heading / heading.magnitude;
                rigidbody.velocity = vector * bulletSpeed;
            }

            if (bullet.TryGetComponent(out BulletController bulletController))
            {
                bulletController.senderTagName = senderTag;
            }

            nextShoot = Time.time + cooldown;
        }
    }
}