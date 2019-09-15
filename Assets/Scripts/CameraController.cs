using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region game varaible
    public float FollowSpeed = 2f;
    private Vector2 temp;
    #endregion

    #region reference
    //public Transform background;
    public Transform Target;
    #endregion 

    private void Start()
    {
        this.transform.position = Target.transform.position;
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        temp = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(Target.position.x, Target.position.y), FollowSpeed * Time.deltaTime);
        transform.position = new Vector3(temp.x, temp.y, -10);
    }
}
