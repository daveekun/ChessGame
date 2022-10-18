using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRook : Enemy
{
    public override void CalculateMovesToTarget(Vector2Int cords)
    {
        base.CalculateMovesToTarget(cords);
        int diffX = cords.x - currentCords.x;
        int diffY = cords.y - currentCords.y;
        if (diffX < 0)
        {
            for (int i = 0; i < -diffX - 1; i++)
            {
                movesToDo.Add("Left");
            }
        }
        else
        {
            for (int i = 0; i < diffX - 1; i++)
            {
                movesToDo.Add("Right");
            }
        }
        if (diffY < 0)
        {
            for (int i = 0; i < -diffY - 1; i++)
            {
                movesToDo.Add("Down");
            }
        }
        else
        {
            for (int i = 0; i < diffY - 1; i++)
            {
                movesToDo.Add("Up");
            }
        }
        StartCoroutine(IRookMover());
    }
    public override void Move(string direction)
    {
        switch (direction)
        {
            case "Up":
                currentCords.y += 1;
                transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 0.5f, 0);
                break;
            case "Down":
                currentCords.y -= 1;
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 0.5f, 0);
                break;
            case "Left":
                currentCords.x -= 1;
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y + 0.5f, 0);
                break;
            case "Right":
                currentCords.x += 1;
                transform.position = new Vector3(transform.position.x + 1f, transform.position.y - 0.5f, 0);
                break;
        }
    }
    IEnumerator IRookMover()
    {
        for (int i = 0; i < movesToDo.Count; i++)
        {
            Move(movesToDo[i]);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
