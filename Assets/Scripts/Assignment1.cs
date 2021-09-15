using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
        Stroke(50, 50, 50);
        PrintLetterMOutline();
        PrintLetterAOutline();
        PrintLetterROutline();
        PrintLetterKOutline();
        PrintLetterUOutline();
        PrintLetterSOutline();

        Stroke(255, 255, 255);
        PrintLetterM();
        PrintLetterA();
        PrintLetterR();
        PrintLetterK();
        PrintLetterU();
        PrintLetterS();
    }

    private void PrintLetterM()
    {
        // M
        Line(4, 7, 4, 3);
        Line(4, 7, 5, 5);
        Line(5, 5, 6, 7);
        Line(6, 7, 6, 3);
    }
    private void PrintLetterA()
    {
        // A
        Line(8, 3, 9, 7);
        Line(9, 7, 10, 3);
        Line(8.5f, 5, 9.5f, 5);
    }
    private void PrintLetterR()
    {
        // R
        Line(12, 3, 12, 6);
        Circle(13, 6, 2);
        Line(12, 5.6f, 14, 3);
    }
    private void PrintLetterK()
    {
        // K
        Line(16, 3, 16, 7);
        Line(16, 5, 18, 7);
        Line(16, 5, 18, 3);
    }
    private void PrintLetterU()
    {
        // U
        Line(20, 3, 20, 7);
        Line(22, 3, 22, 7);
        Line(20, 3, 22, 3);
    }
    private void PrintLetterS()
    {
        //S
        Line(24, 3, 26, 3);
        Line(26, 3, 26, 5);
        Line(26, 5, 24, 5);
        Line(24, 5, 24, 7);
        Line(24, 7, 26, 7);
    }

    private void PrintLetterMOutline()
    {
        // M
        Line(4.5f, 7, 4.5f, 3);
        Line(4.5f, 7, 5.5f, 5);
        Line(5.5f, 5, 6.5f, 7);
        Line(6.5f, 7, 6.5f, 3);
    }
    private void PrintLetterAOutline()
    {
        // A
        Line(8.5f, 3, 9.5f, 7);
        Line(9.5f, 7, 10.5f, 3);
        Line(8.9f, 5, 10, 5);
    }
    private void PrintLetterROutline()
    {
        // R
        Line(12.5f, 3, 12.5f, 6);
        Circle(14, 6, 2);
        Line(12.5f, 5.6f, 14.5f, 3);
    }
    private void PrintLetterKOutline()
    {
        // K
        Line(16.5f, 3, 16.5f, 7);
        Line(16.5f, 5, 18.5f, 7);
        Line(16.5f, 5, 18.5f, 3);
    }
    private void PrintLetterUOutline()
    {
        // U
        Line(20.5f, 3, 20.5f, 7);
        Line(22.5f, 3, 22.5f, 7);
        Line(20.5f, 3, 22.5f, 3);
    }
    private void PrintLetterSOutline()
    {
        //S
        Line(25.5f, 3, 26.5f, 3);
        Line(26.5f, 3, 26.5f, 5);
        Line(26.5f, 5, 24.5f, 5);
        Line(24.5f, 5, 24.5f, 7);
        Line(24.5f, 7, 26.5f, 7);
    }
}
