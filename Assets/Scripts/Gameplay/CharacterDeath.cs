using Core;
using UnityEngine;

namespace Gameplay
{
    public class CharacterDeath : Simulation.Event<CharacterDeath>
    {
        public GameObject Character;
        public override void Execute()
        {
            GameObject.Destroy(Character);
        }
    }
}