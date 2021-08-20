using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics
{
    public class LayerController : MonoBehaviour
    {
        public void RestartCurrentLayer()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(currentScene);
        }
    }
}