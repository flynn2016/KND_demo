using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region game varaible
    public float FollowSpeed = 2f;
    public float ZoomSpeed = 0.1f;
    public float Camera_dist = 5f;
    private Vector2 temp;

    public bool zoomStart = false;
    public bool isZooming = false;
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
    public void OnFixedUpdate()
    {
        temp = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(Target.position.x, Target.position.y), FollowSpeed * Time.deltaTime);
        transform.position = new Vector3(temp.x, temp.y, -10);

        if (zoomStart)
        {
            if (!isZooming)
            {
                this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.GetComponent<Camera>().orthographicSize, Camera_dist, ZoomSpeed);
            }
            if (Mathf.Abs(this.GetComponent<Camera>().orthographicSize - Camera_dist) < 0.01f)
            {
                isZooming = false;
                zoomStart = false;
            }
        }

    }

    public void Zoom(Transform _target, float _zoomspeed, float _camdist)
    {
        zoomStart = true;

        Target = _target;
        ZoomSpeed = _zoomspeed;
        Camera_dist = _camdist;
    }
}
