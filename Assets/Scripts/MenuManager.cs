using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(619, 900, false);
        Camera.main.aspect = 619f / 900f;
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
