using System;
using Core;
using Gameplay;
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

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_characterShoot)
                {
                    var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    
                    _characterShoot.Shoot(target);

                }
            }
        }
    }
}