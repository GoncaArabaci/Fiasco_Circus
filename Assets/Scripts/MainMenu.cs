using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
        public void GoTo1(string sceneName)
        {
            SceneManager.LoadScene(sceneName);

        }

        public void QuitApp()
        {
            Application.Quit();
            Debug.Log("Application has quit.");
        }
}
