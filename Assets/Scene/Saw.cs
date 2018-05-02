using UnityEngine.SceneManagement;
using UnityEngine;

public class Saw : MonoBehaviour {
	void Update () {
        transform.Rotate(new Vector3(0f, 0f, -100f)*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.tag == "Box")
        {
            other.gameObject.SetActive(false);
        }
    }
}
