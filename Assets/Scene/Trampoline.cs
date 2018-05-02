using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
    public GameObject hint,spring;
    private Rigidbody2D RB;
    public float timeHint = 0f;
    bool flagTranslate = false;
    void Start()
    {
        hint.SetActive(false);
    }

    void Update () {
        if (timeHint>-1)
            timeHint -= Time.deltaTime;
        if (timeHint != 0)
            hint.SetActive(true);
        if (timeHint <= 0)
            hint.SetActive(false);
        if ( (timeHint <= 0) && (flagTranslate == true) )
        {
            transform.Translate(new Vector3(0, -3, Time.deltaTime * 1.5f));
            spring.transform.Translate(new Vector3(0, -3, Time.deltaTime * 1.5f));
            flagTranslate = false;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        timeHint = 6f;
        if ( (Input.GetKey(KeyCode.J)) && (flagTranslate == false) )
        {
            RB = other.gameObject.GetComponent<Rigidbody2D>();
            RB.AddForce(new Vector2(0, 3000));
            hint.SetActive(false);
            transform.Translate(new Vector3(0, 3, Time.deltaTime*1.5f));
            spring.transform.Translate(new Vector3(0, 3, Time.deltaTime * 1.5f));
            flagTranslate = true;
        }         
    }
}
