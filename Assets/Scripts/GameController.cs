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
    public GameObject AI_prefab;
    public List<AIController> AI_array = new List<AIController>();
    // Start is called before the first frame update
    void Start()
    {
        AI_array.Add(GameObject.Instantiate(AI_prefab,new Vector3(5,5,0),Quaternion.identity).GetComponent<AIController>());
    }

    // Update is called once per frame
    void Update()
    {
        print(Player.latest_enemy_time);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.OnFixedUpdate();
        Player.OnFixedUpdate();

        for(int i = 0; i < AI_array.Count; i++)
        {
            AI_array[i].OnFixedUpdate();
        }
    }
}
