using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    public float player_speed;
    public float player_rotation_speed;
    // Start is called before the first frame update

    void Start()
    {
        mRigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void OnFixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        mRigidbody.velocity = new Vector2(x * player_speed, y * player_speed);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg), Time.deltaTime * player_rotation_speed);
        }
    }
}
