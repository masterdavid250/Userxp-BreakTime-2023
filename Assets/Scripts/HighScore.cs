using UnityEngine;

[System.Serializable]
public class HighScore
{
    public string _name;
    public int _score;

    public HighScore(string name, int score)
    {
        this._name = name;
        this._score = score;
    }
}
