using UnityEngine;
using System.Collections;

public class gEnemy : MonoBehaviour
{

    [System.Serializable]
    public struct EnemyStats
    {
        private bool _dead;
        public bool dead
        {
            get { return _dead; }
            set { _dead = value; }
        }

        private float _eXP;
        public float eXP
        {
            get { return _eXP; }
            set { _eXP = value; }
        }
        public int edamage;
        public float starthpmultiplier;
        private float _maxHealth;
        public float maxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }
        private float _curHealth;
        public float curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
    }
    public EnemyStats stats = new EnemyStats();
    void DropLoot()
    {

    }
    public void KillEnemy(gEnemy other)
    {
        GetExp();
        Destroy(other.gameObject);
    }
    public virtual void GetExp()
    {
    
    }
    public virtual void DamageEnemy(int damage)
    {

        if (stats.curHealth<= 0 && gameObject.tag == "Enemy")
        {
            KillEnemy(this);
        }
        else
        {
            stats.curHealth -= damage;
        }
    }
    }


