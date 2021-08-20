using UnityEngine;

namespace Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        private GunShoot _characterShoot;

        private void Start()
        {
            _characterShoot = GetComponentInChildren<GunShoot>();
        }

        public void Shoot()
        {
            if (_characterShoot)
            {
                var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _characterShoot.Shoot(target);
            }
        }
    }
}