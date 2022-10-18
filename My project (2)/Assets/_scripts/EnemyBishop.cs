using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBishop : Enemy
{
    public override void CalculateMovesToTarget(Vector2Int cords)
    {
        base.CalculateMovesToTarget(cords);
        if ((cords.x + cords.y) % 2 == (currentCords.x + currentCords.y) % 2)
        {
            int diffBishopX = ((cords.x + cords.y) - (currentCords.x + currentCords.y)) / 2;
            int diffBishopY = cords.y - currentCords.y - diffBishopX;
            if (diffBishopX < 0)
            {
                for (int i = 0; i < -diffBishopX; i++)
                {
                    movesToDo.Add("Left");
                }
            }
            else
            {
                for (int i = 0; i < diffBishopX; i++)
                {
                    movesToDo.Add("Right");
                }
            }
            if (diffBishopY < 0)
            {
                for (int i = 0; i < -diffBishopY; i++)
                {
                    movesToDo.Add("Down");
                }
            }
            else
            {
                for (int i = 0; i < diffBishopY; i++)
                {
                    movesToDo.Add("Up");
                }
            }
            StartCoroutine(IBishopMover());
        }
        else 
        {
            Debug.Log("Needs new calculations so shut up");
        }
    }
    public override void Move(string direction)
    {
        switch (direction)
        {
            case "Down":
                currentCords.x += 1;
                currentCords.y -= 1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
                break;
            case "Up":
                currentCords.x -= 1;
                currentCords.y += 1;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
                break;
            case "Left":
                currentCords.x -= 1;
                currentCords.y -= 1;
                transform.position = new Vector3(transform.position.x - 2, transform.position.y, 0);
                break;
            case "Right":
                currentCords.x += 1;
                currentCords.y += 1;
                transform.position = new Vector3(transform.position.x + 2, transform.position.y, 0);
                break;
        }
    }
    IEnumerator IBishopMover()
    {
        for (int i = 0; i < movesToDo.Count; i++)
        {
            Move(movesToDo[i]);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
