using System;
using System.Globalization;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour {
    private int point_S;
    private int numberBalls_S;

    private double percentage2Point_S;
    private double percentage3Point_S;
    private double percentageExtraLong_S;
    private string p2Point_STR;
    private string p3Point_STR;
    private string pExtraLong_STR;

    private int addingPoints_S;
    private float chanceSpeed_S;

    private float stamina_S;

    private Player playerScript;
    private Bar barScript;
    private Ball ballScript;
    private Stamina staminaScript;

    private void Awake() {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        barScript = GameObject.Find("Bar").GetComponent<Bar>();
        ballScript = GameObject.Find("Ball").GetComponent<Ball>();
        staminaScript = GameObject.Find("Stamina").GetComponent<Stamina>();
    }

    public void SaveCharacteristicsAndPoints() {
        percentage2Point_S = playerScript.GetCurrentPercentage(2);
        p2Point_STR = percentage2Point_S.ToString();
        PlayerPrefs.SetString("Percentage2Point", p2Point_STR);

        percentage3Point_S = playerScript.GetCurrentPercentage(3);
        p3Point_STR = percentage3Point_S.ToString();
        PlayerPrefs.SetString("Percentage3Point", p3Point_STR);

        percentageExtraLong_S = playerScript.GetCurrentPercentage(4);
        pExtraLong_STR = percentageExtraLong_S.ToString();
        PlayerPrefs.SetString("PercentageExtraLong", pExtraLong_STR);

        point_S = ballScript.GetPointsBallsAddingPoints(1);
        PlayerPrefs.SetInt("Points", point_S);
        numberBalls_S = ballScript.GetPointsBallsAddingPoints(2);
        PlayerPrefs.SetInt("Ball", numberBalls_S);

        PlayerPrefs.Save();
    }

    public void SaveBarSpeed() {
        chanceSpeed_S = barScript.GetCurrentChance();
        PlayerPrefs.SetFloat("chanceSpeed", chanceSpeed_S);

        PlayerPrefs.Save();
    }

    public void SaveAddingPoints() {
        addingPoints_S = ballScript.GetPointsBallsAddingPoints(3);
        PlayerPrefs.SetInt("addingPoints", addingPoints_S);

        PlayerPrefs.Save();
    }

    public void SaveStamina() {
        stamina_S = staminaScript.GetStamina();
        PlayerPrefs.SetFloat("stamina", stamina_S);

        PlayerPrefs.Save();
    }

    public void SaveDateTime (string key, DateTime value) {
        string convertedToString = value.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, convertedToString);
    }

    public DateTime LoadDateTime (string key, DateTime defaultValue) {
        if (PlayerPrefs.HasKey(key)) {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else  {
            return defaultValue;
        }
    }

    public void LoadCharacteristics() {
        p2Point_STR = PlayerPrefs.GetString("Percentage2Point");
        percentage2Point_S = double.Parse(p2Point_STR, CultureInfo.InvariantCulture);
        p3Point_STR = PlayerPrefs.GetString("Percentage3Point");
        percentage3Point_S = double.Parse(p3Point_STR, CultureInfo.InvariantCulture);
        pExtraLong_STR = PlayerPrefs.GetString("PercentageExtraLong");
        percentageExtraLong_S = double.Parse(pExtraLong_STR, CultureInfo.InvariantCulture);
    }

    public void LoadPointsAndBalls() {
        point_S = PlayerPrefs.GetInt("Points");
        numberBalls_S = PlayerPrefs.GetInt("Ball");
    }

    public void LoadBarSpeed() {
        chanceSpeed_S = PlayerPrefs.GetFloat("chanceSpeed");
    }

    public void LoadAddingPoints() {
        addingPoints_S = PlayerPrefs.GetInt("addingPoints");
    }

    public void LoadStamina() {
        stamina_S = PlayerPrefs.GetFloat("stamina");
    }

    public void ResetData() {
        PlayerPrefs.DeleteAll();
        point_S = 0;
        numberBalls_S = 0;
    }
    public int GetPoints() {
        return point_S;
    }
    public int GetBalls() {
        return numberBalls_S;
    }
    public double GetPercentage2Point() {
        return percentage2Point_S;
    }
    public double GetPercentage3Point() {
        return percentage3Point_S;
    }
    public double GetPercentageExtraLong() {
        return percentageExtraLong_S;
    }
    public int GetAddingPoint() {
        return addingPoints_S;
    }
    public float GetBarSpeed() {
        return chanceSpeed_S;
    }
    public float GetStamina() {
        return stamina_S;
    }
}