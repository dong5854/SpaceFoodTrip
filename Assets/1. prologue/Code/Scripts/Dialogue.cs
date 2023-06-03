using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField]
    private string name;

    public string Name
    {
        get
        {
            return name;
        }
    }
    [SerializeField]
    private List<string> sentences;

    public List<string> Sentences
    {
        get
        {
            return sentences;
        }
    }
}
