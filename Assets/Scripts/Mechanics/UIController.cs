using UnityEngine;

namespace Mechanics
{
    public class UIController : MonoBehaviour
    {
        public GameObject[] panels;

        public void SetActive(int num = 0)
        {
            SetDisableAll();
            if (panels.Length >= num)
                panels[num].SetActive(true);
        }

        public void SetDisableAll()
        {
            foreach (var panel in panels)
            {
                panel.SetActive(false);
            }
        }

        private void OnEnable()
        {
            SetDisableAll();
        }
    }
}