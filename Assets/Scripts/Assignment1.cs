using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    float xPos;
    float yPos;
    

    // Start is called before the first frame update
    void Start()
    {
        PrintLetterM(xPos,yPos);
        PrintLetterA(xPos, yPos);
        PrintLetterR(xPos, yPos);
        PrintLetterK(xPos, yPos);
        PrintLetterU(xPos, yPos);
        PrintLetterS(xPos, yPos);
        
        PrintLetterMOutline(xPos,yPos);
        PrintLetterAOutline(xPos, yPos);
        PrintLetterROutline(xPos, yPos);
        PrintLetterKOutline(xPos, yPos);
        PrintLetterUOutline(xPos, yPos);
        PrintLetterSOutline(xPos, yPos);
    }

    private void PrintLetterM(float x, float y)
    {
        // M
        Line(4, 7, 4, 3);
        Line(4, 7, 5, 5);
        Line(5, 5, 6, 7);
        Line(6, 7, 6, 3);
    }
    private void PrintLetterA(float x, float y)
    {
        // A
        Line(8, 3, 9, 7);
        Line(9, 7, 10, 3);
        Line(8.5f, 5, 9.5f, 5);
    }
    private void PrintLetterR(float x, float y)
    {
        // R
        Line(12, 3, 12, 6);
        Circle(13, 6, 2);
        Line(12, 5.6f, 14, 3);
    }
    private void PrintLetterK(float x, float y)
    {
        // K
        Line(16, 3, 16, 7);
        Line(16, 5, 18, 7);
        Line(16, 5, 18, 3);
    }
    private void PrintLetterU(float x, float y)
    {
        // U
        Line(20, 3, 20, 7);
        Line(22, 3, 22, 7);
        Line(20, 3, 22, 3);
    }
    private void PrintLetterS(float x, float y)
    {
        //S
        Line(24, 3, 26, 3);
        Line(26, 3, 26, 5);
        Line(26, 5, 24, 5);
        Line(24, 5, 24, 7);
        Line(24, 7, 26, 7);
    }

    private void PrintLetterMOutline(float x, float y)
    {
        // M
        Line(5, 7, 5, 3);
        Line(5, 7, 6, 5);
        Line(6, 5, 7, 7);
        Line(7, 7, 7, 3);
    }
    private void PrintLetterAOutline(float x, float y)
    {
        // A
        Line(9, 3, 10, 7);
        Line(10, 7, 11, 3);
        Line(9.4f, 5, 10.5f, 5);
    }
    private void PrintLetterROutline(float x, float y)
    {
        // R
        Line(13, 3, 13, 6);
        Circle(14, 6, 2);
        Line(13, 5.6f, 15, 3);
    }
    private void PrintLetterKOutline(float x, float y)
    {
        // K
        Line(17, 3, 17, 7);
        Line(17, 5, 19, 7);
        Line(17, 5, 19, 3);
    }
    private void PrintLetterUOutline(float x, float y)
    {
        // U
        Line(21, 3, 21, 7);
        Line(23, 3, 23, 7);
        Line(21, 3, 23, 3);
    }
    private void PrintLetterSOutline(float x, float y)
    {
        //S
        Line(26, 3, 27, 3);
        Line(27, 3, 27, 5);
        Line(27, 5, 25, 5);
        Line(25, 5, 25, 7);
        Line(25, 7, 27, 7);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
