using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Level1Diamond;
    [SerializeField] TextMeshProUGUI Level1Time;
    [SerializeField] TextMeshProUGUI Level1Jump;

    [SerializeField] TextMeshProUGUI Level2Diamond;
    [SerializeField] TextMeshProUGUI Level2Time;
    [SerializeField] TextMeshProUGUI Level2Jump;

    [SerializeField] TextMeshProUGUI Level3Diamond;
    [SerializeField] TextMeshProUGUI Level3Time;
    [SerializeField] TextMeshProUGUI Level3Jump;

    [SerializeField] TextMeshProUGUI Level4Diamond;
    [SerializeField] TextMeshProUGUI Level4Time;
    [SerializeField] TextMeshProUGUI Level4Jump;

    [SerializeField] TextMeshProUGUI Level5Diamond;
    [SerializeField] TextMeshProUGUI Level5Time;
    [SerializeField] TextMeshProUGUI Level5Jump;

    // get the Data in here!!
    private int lvl1Diamond = 4;
    private int lvl2Diamond = 24;
    private int lvl3Diamond = 2;
    private int lvl4Diamond = 34;
    private int lvl5Diamond = 2523;

    private float lvl1Time = 000015f;
    private float lvl2Time = 1.0f;
    private float lvl3Time = 1.0f;
    private float lvl4Time = 1.0f;
    private float lvl5Time = 1.0f;

    private int lvl1Jump = 2;
    private int lvl2Jump = 24;
    private int lvl3Jump = 23;
    private int lvl4Jump = 46;
    private int lvl5Jump = 523;
    private void Start()
    {
        Level1Diamond.text = FromInt(lvl1Diamond);
        Level2Diamond.text = FromInt(lvl2Diamond);
        Level3Diamond.text = FromInt(lvl3Diamond);
        Level4Diamond.text = FromInt(lvl4Diamond);
        Level5Diamond.text = FromInt(lvl5Diamond);
        
        Level1Time.text = FromFloat(lvl1Time);
        Level2Time.text = FromFloat(lvl2Time);
        Level3Time.text = FromFloat(lvl3Time);
        Level4Time.text = FromFloat(lvl4Time);
        Level5Time.text = FromFloat(lvl5Time);

        Level1Jump.text = FromInt(lvl1Jump);
        Level2Jump.text = FromInt(lvl2Jump);
        Level3Jump.text = FromInt(lvl3Jump);
        Level4Jump.text = FromInt(lvl4Jump);
        Level5Jump.text = FromInt(lvl5Jump);
    }

    private string FromInt(int lvl)
    {
    string levelText = lvl.ToString();
        return levelText;
    }
    private string FromFloat(float lvl)
    {
        string levelText = lvl.ToString();
        return levelText;
    }
}
