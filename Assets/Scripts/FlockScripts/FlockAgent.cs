using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock;} }  

    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider;} }

    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity; //2d
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
