using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    public void ReturnToStart()
    {
        SceneManager.LoadScene("StartScene"); // return meau
    }
}
