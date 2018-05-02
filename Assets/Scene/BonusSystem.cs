using UnityEngine;

public class BonusSystem : MonoBehaviour{

    public int score = 0;
    GameObject WarriorClass;
    Warrior wrr;
    void Start()
    {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            this.score++;
            GlobalControl.Instance.score = this.score;
            other.gameObject.SetActive(false);
            wrr.pXP = wrr.pXP + 5;
        }
        if (other.gameObject.name == "DieSpace")
        {
            this.score = 0;
            GlobalControl.Instance.score = this.score;
        }
        if (other.gameObject.tag == "CoinX2")
        {
            this.score = this.score + 2;
            GlobalControl.Instance.score = this.score;
            other.gameObject.SetActive(false);
            wrr.pXP = wrr.pXP + 10;
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Score: " + score);
    }
}
