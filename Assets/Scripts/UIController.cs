using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddAI()
    {
        GameController.Instance.AI_array.Add(GameObject.Instantiate(GameController.Instance.AI_prefab,
            new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-8.0f, 8.0f), 0), Quaternion.identity).GetComponent<AIController>());
    }

    public void ResetPlayerPos()
    {
        GameController.Instance.Player.transform.position = new Vector3(0, 0, 0);
    }
}
