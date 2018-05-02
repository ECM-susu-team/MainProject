using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Warrior {
    //gEnemy _enemy;
    void Start () {
      //  _enemy = GetComponent<gEnemy>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // foreach (ContactPoint2D contact in collision.contacts)
        gEnemy _enemy = collision.gameObject.GetComponent<gEnemy>();
        if (collision.gameObject.tag == "Enemy")
            {
                if (gameObject != null)
                {
                    Debug.Log("PlayerHitsEnemy");
                    _enemy.DamageEnemy(pdamage);
                }
        }
        
    }
}
