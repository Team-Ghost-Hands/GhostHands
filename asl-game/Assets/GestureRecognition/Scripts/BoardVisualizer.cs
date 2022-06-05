using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisualizer : MonoBehaviour
{
    public Material LetterA, LetterB, LetterC, LetterD;

    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void ShowLetterA()
    {
        rend.sharedMaterial = LetterA;
    }

    public void ShowLetterB()
    {
        rend.sharedMaterial = LetterB;

    }

    public void ShowLetterC()
    {
        rend.sharedMaterial = LetterC;
    }

    public void ShowLetterD()
    {
        rend.sharedMaterial = LetterD;
    } 
}
