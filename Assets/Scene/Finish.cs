using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}
