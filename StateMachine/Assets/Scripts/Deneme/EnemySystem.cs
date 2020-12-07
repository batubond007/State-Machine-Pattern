using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : StateMachine
{
    public int AttackRadius;
    void Start()
    {
       SetState(new EnemyBegin(this));
    }
}
