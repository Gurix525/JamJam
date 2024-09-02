using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private string _playSceneName;

    public void ChangeSceneToPlay() => SceneManager.LoadScene(_playSceneName, LoadSceneMode.Single);

    public void Quit() => Application.Quit();
}
