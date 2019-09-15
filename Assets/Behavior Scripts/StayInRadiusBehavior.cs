﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/StayInRadius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector2 center;
    public float radius;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 center_offset = center - (Vector2)agent.transform.position;
        float t = center_offset.magnitude / radius;
        if (t < 0.9f)
            return Vector2.zero;
        else
            return center_offset * t * t;
    }
}
