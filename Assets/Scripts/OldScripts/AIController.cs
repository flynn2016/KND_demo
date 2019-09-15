using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Vector3 player_pos;
    public float patrol_range;
    public float ai_speed;
    public float ai_rotation_speed;
    public float alert_range;
    public float alert_zone_rate;
    public float chaseTime;
    [HideInInspector]
    public enum States {wandering,chasing,backing};
    public States AI_state;
    private Vector3 start_pos;

    //
    private bool hasDest = false;
    private Vector3 temp_dest;
    private Transform alert_zone;

    [HideInInspector]
    public float timer = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        alert_zone = this.transform.GetChild(0);
        AI_state = States.wandering;
        start_pos = this.transform.position;
        temp_dest = this.transform.position;

    }

    // Update is called once per frame
    public void OnFixedUpdate()
    {
        UpdatingAlertZone();
        UpdatingAIMove();
    }

    private void UpdatingAIMove()
    {
        //Debug.Log(AI_state);
        if (AI_state == States.wandering)
        {
            DetectPlayer();
            if (!hasDest)
            {
                temp_dest = new Vector3(start_pos.x + Random.Range(-patrol_range, patrol_range), start_pos.y + Random.Range(-patrol_range, patrol_range), start_pos.z);
                hasDest = true;
            }
            else
            {
                MoveTo(temp_dest);
            }

            if (Vector3.Distance(temp_dest, this.transform.position) < 0.1f)
            {
                hasDest = false;
            }
        }

        if (AI_state == States.chasing)
        {
            DetectPlayer();
            timer += Time.deltaTime;
            MoveTo(player_pos);
            if (timer > chaseTime)
            {
                timer = 0;
                AI_state = States.backing;
            }
        }

        if(AI_state == States.backing)
        {
            MoveTo(start_pos);
            if (Vector3.Distance(start_pos, this.transform.position) < 0.1f)
            {
                AI_state = States.wandering;
            }
        }
    }

    private void UpdatingAlertZone()
    {
        if (AI_state == States.wandering)
        {
            if (alert_zone != null)
            {
                alert_zone.localScale = new Vector3(alert_zone.localScale.x + alert_zone_rate, alert_zone.localScale.y + alert_zone_rate, alert_zone.localScale.z);
                alert_zone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alert_zone.GetComponent<SpriteRenderer>().color.a - alert_zone_rate / alert_range);
                if (alert_zone.localScale.x > alert_range)
                {
                    alert_zone.localScale = new Vector3(0, 0, alert_zone.localScale.z);
                    alert_zone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
            }
        }

        else if(AI_state == States.chasing)
        {
            alert_zone.localScale = new Vector3(patrol_range - patrol_range*timer / chaseTime, patrol_range - patrol_range*timer / chaseTime, alert_zone.localScale.z);
            alert_zone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }

        else if (AI_state == States.backing)
        {

        }
    }

    private void DetectPlayer()
    {
        player_pos = GameController.Instance.Player.transform.position;
        if (Vector3.Distance(player_pos, this.transform.position) < alert_range)
        {
            AI_state = States.chasing;
        }
    }

    private void MoveTo(Vector3 Target)
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, ai_speed * Time.deltaTime);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2((Target.y - this.transform.position.y), (Target.x - this.transform.position.x)) * Mathf.Rad2Deg-90), ai_rotation_speed * Time.deltaTime);
    }
}
