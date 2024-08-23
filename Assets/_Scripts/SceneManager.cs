using UnityEngine;
using UnityEngine.SceneManagement; // Add this using directive


public class SceneManager : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex); // Use the fully qualified name
        // SceneManager.LoadScene(sceneIndex); // Use the using directive
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
