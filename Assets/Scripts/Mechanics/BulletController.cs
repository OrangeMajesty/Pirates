using System;
using Core;
using Gameplay;
using Models;
using UnityEngine;

namespace Mechanics
{
    public class BulletController : MonoBehaviour
    {
        public BulletModel bulletModel { get; private set; }
            = Simulation.GetModel<BulletModel>();

        public string senderTagName = null;

        private void OnCollisionEnter2D(Collision2D other)
        {            
            var othTransform = other.transform;
            if (othTransform.CompareTag("Enemy") || othTransform.CompareTag("Player"))
            {
                var schedule = Simulation.Shedule<BulletCharacterCollision>();
                schedule.Bullet = gameObject;
                schedule.Character = other.gameObject;
            }
        }
    }
}