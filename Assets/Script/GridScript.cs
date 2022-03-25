using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript
{
    static public float Width = 1.34f;
    static public float Height = 1.63f;
    static public float CollisionWidth = 1.34f;
    static public float CollisionHeight = 1.63f;
    public Vector2 Point { get;  set; }
    public Vector2 Position { get; set; }
    private bool HasPlant { get; set; } = false;
    private PlantID PlantID
    {
        get
        {
            return PlantID;
        }
        set
        {
            PlantID = value;
            HasPlant = true;
        }
    }


    public GridScript(Vector2 Point,Vector2 Position)
    {
        this.Point = Point;
        this.Position = Position;
    }

}
