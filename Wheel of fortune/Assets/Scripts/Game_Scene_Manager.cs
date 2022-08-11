using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Scene_Manager : MonoBehaviour
{
    private bool win = false;
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject win_can;
    private int money =0;
    [SerializeField]
    private TMP_Text money_sentence;
    [SerializeField]
    private TMP_Text money_to_be_added;

    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        win_can.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(win==true)
        {
            Panel.SetActive(true);
            win_can.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
            win_can.SetActive(false);
        }
    }

    public void enable_win(int mon,int total)
    {
        win = true;
        money = total;
        money_sentence.text = "You have won "+mon+" coins";
    }

    public void onButtonPress()
    {
        win = false;
        money_to_be_added.text = money.ToString();
    }
}
