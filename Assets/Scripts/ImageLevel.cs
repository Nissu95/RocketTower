using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLevel : MonoBehaviour {
    int currentImage;
    new Image name;
    [SerializeField] private Sprite[] stageName;

    void Awake()
    {
        name = GetComponent<Image>();
    }

    void Reset()
    {
        currentImage = 0;
        name.sprite = stageName[currentImage];
    }

    void Next()
    {
        currentImage++;
        if (currentImage > stageName.Length - 1)
        {
            currentImage = 0;
        }
        name.sprite = stageName[currentImage];
    }
    void Previous()
    {
        currentImage--;
        if (currentImage < 0)
        {
            currentImage = stageName.Length - 1;
        }
        name.sprite = stageName[currentImage];
    }
}
