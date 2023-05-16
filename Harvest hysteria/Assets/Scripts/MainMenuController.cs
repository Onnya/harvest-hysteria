using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void CreateNewGame()
    {
        Debug.Log("New game");
    }

    public void ContinueGame()
    {
        Debug.Log("Continue");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
