using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_spin : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private float z = 0f;
    [SerializeField]
    private float decrement_min = 10f;
    [SerializeField]
    private float decrement_max = 12f;
    private float decrement = 0f;
    [SerializeField]
    private bool spin = false;
    private float original_speed;
    [SerializeField]
    private float division = 0f;
    [SerializeField]
    private int index = 0;
    [SerializeField]
    private float current_rot = 0f;
    private bool check_once = false;
    private int money_max = 0;

    private Game_Scene_Manager event_handler;
    private Wheel_numbers get_array;
    // Start is called before the first frame update
    void Start()
    {
        decrement = Random.Range(decrement_min, decrement_max);
        original_speed = speed;
        event_handler = GameObject.Find("Game_screen_Manager").GetComponent<Game_Scene_Manager>();
        if(event_handler==null)
        {
            Debug.Log("Event Handler not found");
        }
        get_array = this.GetComponent<Wheel_numbers > ();

        if (get_array == null)
        {
            Debug.Log("Event Handler not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        current_rot = transform.eulerAngles.z;
        if (spin)
        {
            decrement = Random.Range(decrement_min, decrement_max);
            spin_motion();
            check_once = true;
        }
        else
        {
            if (check_once)
            {
                check_division();
                check_once = false;
                if (event_handler != null && get_array != null)
                {
                    money_max += get_array.division[index];
                    event_handler.enable_win(get_array.division[index], money_max);
                }
            }
        }

    }

    private void spin_motion()
    {

        z += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (speed > 0)
        {
            speed = speed - decrement * Time.deltaTime;
        }
        else
        {
            speed = 0f;
            spin = false;
            speed=original_speed;
        }
    }

    private void check_division()
    {
        division= transform.eulerAngles.z;
        if(division<0)
        {
            division = 360 - division;
        }
        index =(int) ((division+15f) / 30f);
    }

    public void OnButtonPress()
    {
        if (spin == false)
        {
            spin = true;
        }
    }
}
