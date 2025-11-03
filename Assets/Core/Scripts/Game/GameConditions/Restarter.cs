using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            Restart();
        }
    }
    public void Restart ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}