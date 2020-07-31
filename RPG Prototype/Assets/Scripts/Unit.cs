using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //All the stats
    public int level;
    public int hp, mHp;
    public int str, strMod;
    public int dex, dexMod;
    public int con, conMod;
    public int intel, intelMod;
    public int wis, wisMod;
    public int cha, chaMod;
    public int hitDie, hitDieSize;

    //Written things
    public string race, unitName, job="Fighter";

    //constructors

    public Unit() { }

    public Unit(Unit unit)
    {
        this.level = unit.level;
        this.race = unit.race;
        this.job = unit.job;
        this.unitName = unit.unitName;
        this.hp = unit.hp;
        this.str = unit.str;
        this.dex = unit.dex;
        this.con = unit.con;
        this.wis = unit.wis;
        this.intel = unit.intel;
        this.cha = unit.cha;
        this.hitDie = level;
        getClassStats();
        calcMods();
        calcMHp();

    }

    //Ability score mods
    public void calcMods()
    {
        strMod = (str - 10) / 2);
        dexMod = (int)Mathf.Floor((dex - 10) / 2);
        conMod = (int)Mathf.Floor((con - 10) / 2);
        intelMod = (int)Mathf.Floor((intel - 10) / 2);
        wisMod = (int)Mathf.Floor((wis - 10) / 2);
        chaMod = (int)Mathf.Floor((cha - 10) / 2);
    }
    public void calcMHp()
    {
        //Ok this looks like a mess.
        //We take your total conMod time your level(If level 2 with a mod of +3, you get 6), plus your full hitdie for level 1(if a d6, it's 6)
        //Then the average roll of your hitdie rounded up(total hitdie divided in half + 1) but only for each level after 1.
        //In example above, we'd have 16 hp(6+6+4)
        mHp = (conMod * level) + hitDieSize + (((hitDieSize / 2)+1) * (level - 1));
    }

    //This will get us things such as proficienies and the like. For now it's just for hitdie
    public void getClassStats()
    {
        switch (job)
        {
            case "Fighter":
                hitDieSize = 10;
                break;
            case "Wizard":
                hitDieSize = 6;
                break;
            case "Cleric":
                hitDieSize = 8;
                break;
        }

    }
}
