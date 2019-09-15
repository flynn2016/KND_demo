using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Coheison")]
public class CoheisonBehaviour : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //
        Vector2 coheisonMove = Vector2.zero;
        foreach (Transform item in context) 
        {
            coheisonMove += (Vector2)item.position;
        }

        coheisonMove /= context.Count;

        //offset from agent position
        coheisonMove -= (Vector2)agent.transform.position;
        return coheisonMove; 
    }
}
