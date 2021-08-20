using Core;
using Gameplay;
using Models;
using UnityEngine;

namespace Mechanics
{
    public class GuardControll : MonoBehaviour
    {
        public GameObject guard;
        
        public void Show()
        {
            Simulation.Shedule<GuardShow>().guard = guard;
        }
    }
}