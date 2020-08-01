using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //All the stats
    public int level=1;
    public int hp, mHp;
    public int str=10, strMod;
    public int dex=10, dexMod;
    public int con=10, conMod;
    public int intel=10, intelMod;
    public int wis=10, wisMod;
    public int cha=10, chaMod;
    public int hitDie=8, hitDieSize;

    public bool hostile;


    //Written things
    public string race="Human", unitName, job="Fighter";

    //constructors

    public Unit() { }

    //For quickly making baseline stat npc
    public Unit(string unitName, bool hostile)
    {
        this.unitName = unitName;
        this.hostile = hostile;
        getClassStats();
        calcMods();
        calcMHp();
        this.hp = mHp;
    }

    //When we need full details. Mostly partymembers or specific enemies
    public Unit(int level, string unitName, int str, int dex, int con, int intel, int wis, int cha, string race, string job, bool hostile) {
        this.level = level;
        this.race = race;
        this.job = job;
        this.unitName = unitName;
        this.str = str;
        this.dex = dex;
        this.con = con;
        this.wis = wis;
        this.intel = intel;
        this.cha = cha;
        this.hitDie = level;
        this.hostile = hostile;
        getClassStats();
        calcMods();
        calcMHp();
        this.hp = mHp;
    }

    //copy function
    public Unit(Unit unit)
    {
        this.level = unit.level;
        this.race = unit.race;
        this.job = unit.job;
        this.unitName = unit.unitName;
        this.str = unit.str;
        this.dex = unit.dex;
        this.con = unit.con;
        this.wis = unit.wis;
        this.intel = unit.intel;
        this.cha = unit.cha;
        this.hitDie = level;
        this.hostile = unit.hostile;
        getClassStats();
        calcMods();
        calcMHp();
        this.hp = mHp;

    }

    //Ability score mods
    public void calcMods()
    {
        //iunno if I need to floor it yet, will change when I find out
        strMod = (str - 10) / 2;
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
