using System;
using Mechanics;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BaseModel
    {
        public PlayerController player;
        public UIController UIController;
        public Transform enemyGunTarget;
        public Transform enemyPathTarget;
        public int deathEnemies;
        public BaseLevel level;
    }
}