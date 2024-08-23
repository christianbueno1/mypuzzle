using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SceneManager _sceneManager;
    
    void Start()
    {
        _sceneManager = FindObjectOfType<SceneManager>();
    }
    public void PlayGame()
    {
        // scene at index 1 is the first level
        _sceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        _sceneManager.QuitGame();
    }

    
}
