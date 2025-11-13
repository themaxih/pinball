using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Sound")]
    public Transform sounds;
    public static Transform soundsInstance;     // Permet de check si sounds est déjà présent pour ne pas le ré-instantier dans DontDestroyOnLoad

    private void Awake()
    {
        // Définir la résolution de l'écran
        Screen.SetResolution(565, 900, false);
        Camera.main.aspect = 565f / 900f;

        #region Faire en sorte que la musique soit persitante entre les morts du joueur
        DontDestroyOnLoad(sounds);

        if (soundsInstance == null)
        {
            soundsInstance = sounds;
        }
        else
        {
            Destroy(sounds.gameObject);
        }
        #endregion
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
        SceneManager.LoadScene(1);  // 1 correspond à l'index de la scène de jeu
    }
}
