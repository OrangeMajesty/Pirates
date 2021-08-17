using UnityEngine;

namespace Mechanics
{
    public class OverGameTrigger : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(other.gameObject);
        }
    }
}