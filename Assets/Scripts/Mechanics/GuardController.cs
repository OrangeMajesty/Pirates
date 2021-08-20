using Core;
using Gameplay;
using UnityEngine;

namespace Mechanics
{
    public class GuardController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                Simulation.Shedule<GuardHide>().guard = gameObject;
                Simulation.Shedule<BulletDestroy>().Bullet = other.gameObject;
            }
        }
    }
}