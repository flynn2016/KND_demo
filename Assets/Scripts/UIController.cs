using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void ResetPlayerPos()
    {
        GameController.Instance.Player.transform.position = new Vector3(0, 0, 0);
    }
}
