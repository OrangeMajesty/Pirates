using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class PlayerWin : Simulation.Event<PlayerWin>
    {
        private UIController _uiController;
        public override void Execute()
        {
            _uiController = Simulation.GetModel<BaseModel>().UIController;
            _uiController.SetActive(1);
        }
    }
}