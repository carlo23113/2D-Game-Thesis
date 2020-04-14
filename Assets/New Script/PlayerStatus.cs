using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
    private int health = 3;

    public int Health{
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
}
