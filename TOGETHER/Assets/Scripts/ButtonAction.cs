using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    void Update()
    {
        string RestartSceneName = SceneManager.GetActiveScene().name;
        if (RestartSceneName == "Win")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
