using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class CharacterDeath : Simulation.Event<CharacterDeath>
    {
        public GameObject Character;
        private UIController _uiController;
        private BaseLevel _baseLevel;
        private BaseModel _baseModel;
        public override void Execute()
        {
            _baseModel = Simulation.GetModel<BaseModel>();

            _uiController = _baseModel.UIController;
            _baseLevel = _baseModel.level;
            
            if (Character.CompareTag("Player"))
            {
                Simulation.Shedule<PlayerLose>();

            } else if (Character.CompareTag("Enemy"))
            {
                _baseModel.deathEnemies++;
                if (_baseModel.deathEnemies >= _baseLevel.Enemies.Length)
                    Simulation.Shedule<PlayerWin>();
            }
            
            GameObject.Destroy(Character);
        }
    }
}