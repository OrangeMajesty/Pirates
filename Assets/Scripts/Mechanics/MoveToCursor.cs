using UnityEngine;

namespace Mechanics
{
    public class MoveToCursor : MonoBehaviour
    {
        private void FixedUpdate()
        {
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = target;
        }
    }
}