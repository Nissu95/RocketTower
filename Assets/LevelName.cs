using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelName : MonoBehaviour {
    int currentname; 
    Text name;
    [SerializeField] private string[] stageName;

    void Awake()
    {
        name = GetComponent<Text>();
    }

    void Reset()
    {
        currentname = 0;
        name.text = stageName[currentname];
    }

    void Next()
    {
        currentname++;
        if (currentname > stageName.Length - 1)
        {
            currentname = 0;
        }
        name.text = stageName[currentname];
    }
    void Previous()
    {
        currentname--;
        if (currentname < 0)
        {
            currentname = stageName.Length - 1;
        }
        name.text = stageName[currentname];
    }
}
