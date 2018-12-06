using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour {
    public float MaxValue = 5f;
    public float CurrentContents = 5f;
    public float smallRefillValue = 0.5f;
    public bool inUse = false;
    public float fillPercent
    {
        get { return CurrentContents / MaxValue; }
    }
	// Use this for initialization
	void Start () {
        CurrentContents = MaxValue;
    }
    public int inUseCooldown = 5;
	void Update () {
        if (inUse)
        {
            inUseCooldown--;
            if (inUseCooldown <= 0)
            {
                inUse = false;
            }
        }
    }
    public void Fill(float value)
    {
        CurrentContents += value;
        if (CurrentContents > MaxValue)
        {
            CurrentContents = MaxValue;
        }
    }
    public void SmallRefill()
    {
        Fill(smallRefillValue);
    }
    public bool Use(float value)
    {
        if (CurrentContents > value)
        {
            inUse = true;
            inUseCooldown = 5;

            CurrentContents -= value;
            return true;
        }
        return false;
    }
}
