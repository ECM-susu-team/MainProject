using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gAbility {
    protected string name
    {
        get { return name; }
        set { name = value; }
    }
    public float damageAmount
    {
        get { return damageAmount; }
        protected set { damageAmount = value; }
    }
    public virtual void Use()
    {
        Debug.Log( "using ability");
        // ability will be here
    }
}
