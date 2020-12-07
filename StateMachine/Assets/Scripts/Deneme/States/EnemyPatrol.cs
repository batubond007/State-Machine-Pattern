using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

internal class EnemyPatrol : State
{
    #region Construction
    public EnemyPatrol(EnemySystem enemySystem) : base(enemySystem)
    {
        EnemySystem.StartCoroutine(Start());
        Debug.Log("Patrolling");
    }
    #endregion

    #region Execution Overrides
    public override IEnumerator Start()
    {
        C_Patroling = EnemySystem.StartCoroutine(Patroling());
        C_Update = EnemySystem.StartCoroutine(Update());
        yield break;
    }
    public override IEnumerator Update()
    {
        while (true)
        {

            if (CheckAttackPlayer(PositionManager.manager.Player))
            {
                EnemySystem.StopCoroutine(C_Patroling);
                EnemySystem.SetState(new EnemyAttack(EnemySystem));
                yield break;
            }
                
            yield return new WaitForEndOfFrame();
        }
    }
    public override IEnumerator Patroling()
    {
        while (true)
        {
            float Destination_x = EnemySystem.transform.position.x + Random.insideUnitSphere.x * Random.Range(10,15);
            float Destination_z = EnemySystem.transform.position.z + Random.insideUnitSphere.z * Random.Range(10,15);
            Vector3 Destination = new Vector3(Destination_x, .5f, Destination_z);
            float RandomizedTime = Random.Range(1f, 1.5f);
            EnemySystem.transform.DOMove(Destination, RandomizedTime).SetEase(Ease.Linear);
            yield return new WaitForSeconds(RandomizedTime);
        }
    }
    #endregion

    #region State Changers
    public bool CheckAttackPlayer(GameObject player)
    {
        if (Vector3.Distance(EnemySystem.transform.position, player.transform.position) <= EnemySystem.AttackRadius)
            return true;
        else
            return false;
    }
    #endregion
}
