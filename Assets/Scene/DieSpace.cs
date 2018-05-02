using UnityEngine;
using UnityEngine.SceneManagement;

public class DieSpace : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            SceneManager.LoadScene("Scene1");
        }
        if (other.tag == "Box")
        {
            other.gameObject.SetActive(false);
        }
    }
}
