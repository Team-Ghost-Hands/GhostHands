using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisualizer : MonoBehaviour
{
    public Material rock, scissors, paper;

    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void ShowRock()
    {
        rend.sharedMaterial = rock;
    }

    public void ShowScissors()
    {
        rend.sharedMaterial = scissors;
    }

    public void ShowPaper()
    {
        rend.sharedMaterial = paper;

    }
}
