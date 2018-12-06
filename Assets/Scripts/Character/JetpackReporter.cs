using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JetpackReporter : MonoBehaviour {
    Image img;
    public Jetpack jetpack;
	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        img.fillAmount = jetpack.fillPercent;
    }
}
