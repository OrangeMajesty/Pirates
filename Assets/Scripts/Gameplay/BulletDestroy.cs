using Core;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class BulletDestroy : Simulation.Event<BulletDestroy>
    {
        public GameObject Bullet;
        public override void Execute()
        {
            if (Bullet)
                GameObject.Destroy(Bullet);
        }
    }
}