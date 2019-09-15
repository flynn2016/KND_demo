using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    #region Singleton
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    public CameraController Camera;
    public PlayerController Player;
    public Flock flock_1;
    public Flock flock_2;
    public Flock flock_3;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flock_1.OnUpdate();
        flock_2.OnUpdate();
        flock_3.OnUpdate();
        Camera.OnUpdate();
        Player.OnUpdate();
    }

    // Update is called once per frame

}
