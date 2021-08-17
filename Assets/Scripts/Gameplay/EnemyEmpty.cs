using Core;
using Mechanics;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class EnemyEmpty : Simulation.Event<EnemyEmpty>
    {
        private BaseLevel _baseLevel;
        public override void Execute()
        {
            _baseLevel = Simulation.GetModel<BaseModel>().level;
            _baseLevel.Enemies = null;
        }
    }
}