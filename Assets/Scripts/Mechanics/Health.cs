using UnityEngine;
using UnityEngine.UI;

namespace Mechanics
{
    public class Health : MonoBehaviour
    {
        public GameObject healthBar;
        public bool showIndicator = true;
        public float maxPoint;
        
        private float _currentPoint;
        private Slider _currentHealthBar;

        public void ApplyDamage(float point)
        {
            if (point < 0)
                point = -point;
            
            var health = _currentPoint - point;
            
            if (health < 0)
                health = 0;
            
            _currentPoint = health;

            if (_currentHealthBar)
                _currentHealthBar.value = health;
        }
        public bool IsAlive()
            => _currentPoint > 0;
        private void Start()
        {
            if (healthBar && showIndicator)
            {
                var bar = Instantiate(healthBar, transform, false);
                _currentHealthBar = bar.GetComponentInChildren<Slider>();
            }
            
            _currentHealthBar.maxValue = maxPoint;
            SetHealth(maxPoint);
        }
        private void SetHealth(float point)
        {
            _currentPoint = point;
            _currentHealthBar.value = point;
        }
    }
}