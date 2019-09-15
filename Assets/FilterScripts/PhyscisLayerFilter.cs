using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/PhyscisLayer")]
public class PhyscisLayerFilter : ContextFilter
{
    public LayerMask[] masks;

    public override List<Transform> Filtered(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            for (int i = 0; i < masks.Length; i++)
            {
                if (masks[i] == (masks[i] | (1 << item.gameObject.layer)))
                {
                    filtered.Add(item);
                }
            }

        }
        return filtered;
    }
}
