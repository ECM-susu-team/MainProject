using UnityEngine;

public class first : gEnemy
{
    private void Start()
    {
        stats.edamage = 1;
        stats.starthpmultiplier = 1 ;
        stats.maxHealth = 50;
        stats.curHealth = stats.maxHealth;
        stats.eXP = 60f;
    }
    public override void DamageEnemy(int damage)
    {
        base.DamageEnemy(damage);
    }
    public override void GetExp()
    {

        Warrior _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Warrior>();
        Debug.Log("Current XP: " + _player.pXP);
        _player.pXP += stats.eXP;
    }
    private void OnCollisionEnter2D(Collision2D _collinfo)
    {
        SomeCharacter _player = _collinfo.collider.GetComponent<SomeCharacter>();

        if (_player != null)
        {
            Debug.Log("EnemyHITS PLayer");
            _player.DamagePlayer( stats.edamage) ;
        }
    }
}