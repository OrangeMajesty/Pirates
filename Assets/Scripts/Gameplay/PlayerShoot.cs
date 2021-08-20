using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class PlayerShoot : Simulation.Event<PlayerShoot>
    {
        private PlayerController _playerController;
        public override void Execute()
        {
            _playerController = Simulation.GetModel<BaseModel>().player;
            _playerController.Shoot();
        }
    }
}