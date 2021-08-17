using System;
using Core;
using Models;
using Models.Base;
using UnityEngine;

namespace Mechanics
{
    public class EnemySpawn : MonoBehaviour
    {
        private int _currentEnemy;
        private GameObject[] _leveData;

        private void Start()
        {
            _leveData = Simulation.GetModel<BaseModel>().level.Enemies;
            _currentEnemy = 0;
            Spawn();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Enemy"))
                Spawn();
        }

        private void Spawn()
        {
            if (_currentEnemy >= _leveData.Length)
                return;
            
            var enemy = _leveData[_currentEnemy];
            var obj = Instantiate(enemy, transform.position, Quaternion.identity);
            obj.transform.SetParent(transform);
            
            _currentEnemy++;
        }
    }
}