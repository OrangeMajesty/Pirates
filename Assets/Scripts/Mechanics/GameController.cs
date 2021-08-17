using System;
using Core;
using Models;
using UnityEngine;

namespace Mechanics
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        public BaseModel baseModel = Simulation.GetModel<BaseModel>();

        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        private void Update()
        {
            if (Instance == this) Simulation.Tick();
        }
    }
}