using System.Collections;
using Core;
using Models;
using UnityEngine;

namespace Mechanics
{
    public class EnemyController : MonoBehaviour
    {
        public bool isAttacking = false;
        public float speedMove = 0.3f;
        
        private GunShoot _gunShoot;
        private Transform _targetGun;
        private Transform _targetMove;
        private bool _isMoving;
        private float offsetRaycastX = 400f;

        private void Start()
        {
            _targetGun = Simulation.GetModel<BaseModel>().enemyGunTarget;
            _targetMove = Simulation.GetModel<BaseModel>().enemyPathTarget;
            _gunShoot = GetComponentInChildren<GunShoot>();
            _isMoving = true;
            
            StartCoroutine(Attack());
        }

        private void Update()
        {
            RaycastHit2D hit2D = Physics2D.Raycast(((Vector2)transform.position) + Vector2.left * offsetRaycastX, Vector2.left, Mathf.Infinity);
            if (hit2D.collider != null && hit2D.collider.CompareTag("Enemy"))
            {
                float distance = Mathf.Abs(hit2D.point.x - transform.position.x);

                if (distance <= 600f)
                {
                    _isMoving = false;
                }
                else
                {
                    _isMoving = true;
                }
            }
            else
            {
                _isMoving = true;
            }
            
            if (_isMoving)
            {
                var pos = transform.position;
                var posTarget = new Vector2(_targetMove.position.x, pos.y);
                transform.position = Vector2.Lerp(pos, posTarget, speedMove * Time.deltaTime);
            }
        }

        private IEnumerator Attack()
        {
            while (isAttacking)
            {
                var target = Trajectory.GetTarget(transform.position, _targetGun.position, 284, 148);
                Debug.Log(target);
                if (target != Vector3.zero)
                    _gunShoot.Shoot(target, transform.tag);
                yield return null;
            }
        }
    }
}