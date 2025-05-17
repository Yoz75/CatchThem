using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatchThem
{
    public class SceneLoadHelper : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}