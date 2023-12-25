using UnityEngine;
using UnityEngine.SceneManagement;

public class BattonManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("firstSpawn", 0);
        PlayerPrefs.SetInt("final", 0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
