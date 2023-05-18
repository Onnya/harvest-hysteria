using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("Menu");
    }
}
