using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisualizer : MonoBehaviour
{
    public Material LetterA, LetterB, LetterC, LetterD, LetterE, LetterF, LetterG, LetterH;

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

    public void ShowLetterE()
    {
        rend.sharedMaterial = LetterE;
    } 

    public void ShowLetterF()
    {
        rend.sharedMaterial = LetterF;
    } 

    public void ShowLetterG()
    {
        rend.sharedMaterial = LetterG;
    } 

    public void ShowLetterH()
    {
        rend.sharedMaterial = LetterH;
    } 
}
