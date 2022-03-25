using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantID
{
    Null,
    Sun,
    PeaShooter,
    DoubleShooter,
    IcePea,
    WallNut,
    TallNut,
    Pumpkin,
    Cherry
};

public class PlantBasic : MonoBehaviour
{
    private PlantID PlantID {get; set;}
    private float Blood;
    private float SkillCD;
    private float NowCD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
