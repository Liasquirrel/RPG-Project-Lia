using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public static UI instance { get; private set; }
    // Start is called before the first frame update

    public Text levelText;

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stats(Unit unit)
    {
        levelText.text = unit.unitName + "\n" +"Class: " + unit.job + "\n" + "Level: " + unit.level + "\n" + "Str: +" + unit.strMod + "\n"
            + "Dex: +" + unit.dexMod + "\n" + "Con: +" + unit.conMod + "\n" + "Wis: +" + unit.wisMod + "\n" + "Int: +" + unit.intelMod + "\n" + "Cha: +" + unit.chaMod;
    }
}
