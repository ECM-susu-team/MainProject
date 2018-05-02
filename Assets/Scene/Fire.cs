using UnityEngine;

public class Fire : MonoBehaviour {
    GameObject WarriorClass;
    Warrior wrr;
    private int curHP = 0;
    int damage = 1;
    void Start()
    {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            wrr.DamagePlayer(damage);
        }
    }
}
