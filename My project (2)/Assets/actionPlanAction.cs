using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionPlanAction : MonoBehaviour
{
    public enum Type
    {
        Move,
        Attack,
        Talk
    }
    public enum AttackType
    {
        Melee,
        Spell
    }

    public MoveParams moveParams;
    [System.Serializable]
    public class MoveParams {
        public GameObject gm;
        public Vector2Int targetPosition;
        public actionPlanAction onReachedPosition;

        public void ExecuteAction()
        {
            if (gm.GetComponent<EnemyBishop>() != null)
                gm.GetComponent<EnemyBishop>().CalculateMovesToTarget(targetPosition);
            else
                gm.GetComponent<EnemyBishop>().CalculateMovesToTarget(targetPosition);

        }
    }
}
