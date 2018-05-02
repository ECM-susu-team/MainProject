using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;

    void Update() {
        if (player!= null)
        { transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2, -10f); }
        else
        {
            // something do with camera
        }
	}
}
