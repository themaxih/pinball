using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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
