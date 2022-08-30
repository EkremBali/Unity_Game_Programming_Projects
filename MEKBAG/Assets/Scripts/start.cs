using UnityEngine.SceneManagement;
using UnityEngine;

public class start : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level5");
    }
}
