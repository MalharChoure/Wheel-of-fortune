using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wheel_numbers : MonoBehaviour
{
    private int children = 0;
    private TMP_Text[] ar;
    [SerializeField]
    public int[] division = {0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField]
    public Sprite[] sp= {null,null}; 
    // Start is called before the first frame update
    void Start()
    {
        children= transform.childCount;
        ar = new TMP_Text[children];
        for (int i = 0; i < 12; i++)
        {
            ar[i] = transform.GetChild(i).GetComponent<TMP_Text>();
            ar[i].text = division[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
