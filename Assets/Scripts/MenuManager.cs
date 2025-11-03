using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(565, 900, false);
        Camera.main.aspect = 565f / 900f;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayGame();       
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
