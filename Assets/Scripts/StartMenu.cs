using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] string level1 = "SampleScene";
    [SerializeField] string level2 = "InnovationScene";

    public void LoadLevel(int index)
    {
        string scene = index == 2 && Application.CanStreamedLevelBeLoaded(level2) ? level2 : level1;
        SceneManager.LoadScene(scene);
    }

#if UNITY_EDITOR
    public void QuitGame() => UnityEditor.EditorApplication.isPlaying = false;
#else
    public void QuitGame() => Application.Quit();
#endif
}
