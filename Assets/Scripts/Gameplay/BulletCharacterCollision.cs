using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class BulletCharacterCollision : Simulation.Event<BulletCharacterCollision>
    {
        public GameObject Bullet;
        public GameObject Character;
        
        public override void Execute()
        {
            float damage = 0;
            string senderTag = null;
            
            if (Bullet.TryGetComponent(out BulletController bulletController))
            {
                damage = bulletController.bulletModel.damage;
                senderTag = bulletController.senderTagName;
            }
            
            if (senderTag != null)
                if (Character.CompareTag(senderTag))
                    return;
            
            Simulation.Shedule<BulletDestroy>().Bullet = Bullet;
            if (Character.TryGetComponent(out Health health))
            {
                health.ApplyDamage(damage);
                if (!health.IsAlive())
                    Simulation.Shedule<CharacterDeath>().Character = Character;
            }
        }
    }
}