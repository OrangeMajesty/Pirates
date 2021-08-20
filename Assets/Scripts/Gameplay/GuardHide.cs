using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class GuardHide : Simulation.Event<GuardHide>
    {
        public GameObject guard;
        public override void Execute()
        {
            guard.SetActive(false);
        }
    }
}