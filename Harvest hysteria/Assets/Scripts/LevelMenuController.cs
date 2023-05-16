using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }
}
