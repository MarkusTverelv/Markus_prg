using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    public int lines;

    private void Start()
    {
        for (int x = 0, y = lines; x < lines; x++)
        {
            y--;
            Line(0, y, x, 0);

            if (x % 3 == 0)
                Stroke(50, 50, 50);
            else
                Stroke(255);
        }
    }
}
public class ParabolicCurves : ProcessingLite.GP21
{
    public ParabolicCurves(Vector2 xAxis, Vector2 yAxis, int numberOfLines)
    {
        for (int i = 0, f = numberOfLines; i < numberOfLines; i++)
        {
            f--;
            Line(yAxis.x, yAxis.y + f, xAxis.x + i, xAxis.y);
        }
    }
}
