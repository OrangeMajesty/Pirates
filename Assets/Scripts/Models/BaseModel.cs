using System;
using Mechanics;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BaseModel
    {
        public PlayerController player;
        public Transform enemyGunTarget;
        public Transform enemyPathTarget;
        public BaseLevel level;
    }
}