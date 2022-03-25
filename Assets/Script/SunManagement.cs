using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManagement : MonoBehaviour
{
    public GameObject SunPrefab;
    public static int TotalSun = 0;
    private float GenerateInterval = 5.0f;
    private float HorizontalMin = 0, HorizontalMax = 13.7f;


    private void Start()
    {
        InvokeRepeating(nameof(CreateSun), GenerateInterval, GenerateInterval);
    }

    private void Update()
    {
        
    }

    void CreateSun()
    {
        float HorizontalOriin = Random.Range(HorizontalMin, HorizontalMax);
        SkySun skySun = GameObject.Instantiate<GameObject>(SunPrefab, transform.position + new Vector3(HorizontalOriin, 0, 0), Quaternion.identity, transform).GetComponent<SkySun>();
    }
}
