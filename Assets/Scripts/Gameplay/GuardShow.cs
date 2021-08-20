using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class GuardShow : Simulation.Event<GuardShow>
    {
        public GameObject guard;
        public override void Execute()
        {
            guard.SetActive(true);
        }
    }
}