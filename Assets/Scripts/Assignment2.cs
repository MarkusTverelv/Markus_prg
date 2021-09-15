using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    public int lines;

    public int lineDensity;
    public Vector2 lineStartPoint;
    public Vector2 lineEndPoint;

    ParabolicCurves pc;

    private void Start()
    {
        for (int x = 0, y = lines; x < lines; x++, y--)
        {
            Line(0, y, x, 0);

            if (x % 3 == 0)
                Stroke(50, 50, 50);
            else
                Stroke(255);
        }
    }
    private void Update()
    {
        pc = new ParabolicCurves(lineDensity, lineEndPoint, lineStartPoint);
    }
}
public class ParabolicCurves : ProcessingLite.GP21
{
    public ParabolicCurves(int numberOfLines) : this(numberOfLines, new Vector2(0, 0), new Vector2(0, 0)) { }   //Chain-calling contructors
    public ParabolicCurves(Vector2 xAxis, Vector2 yAxis) : this(30, xAxis, yAxis) { }   //Chain-calling contructors
    public ParabolicCurves(int numberOfLines, Vector2 xAxis, Vector2 yAxis)     //Chain-calling contructors
    {
        CreateCurve(numberOfLines, xAxis, yAxis);
    }

    private void CreateCurve(int lines, Vector2 axis1, Vector2 axis2)
    {
        for (int i = 0, f = lines; i < lines; i++, f--)
            Line(axis2.x, axis2.y + f, axis1.x + i, axis1.y);
    }
}
