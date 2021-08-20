using System;
using Core;
using Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerGunAreaController : MonoBehaviour
    {
        private Collider2D _collider2D;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider == _collider2D)
                    Simulation.Shedule<PlayerShoot>();
            }
        }
    }
}