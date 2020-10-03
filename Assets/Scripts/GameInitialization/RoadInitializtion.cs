using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadInitializtion : MonoBehaviour
{
    private GameObject _RoadPrefab;

    [SerializeField]
    private RoadInfoSO roadInfoSO;


    private void Awake()
    {
        InitializeRoadPrefab();
    }


    private void InitializeRoadPrefab()
    {
        if (!_RoadPrefab)
        {
            _RoadPrefab = roadInfoSO._RoadPrefab;

            Instantiate(_RoadPrefab, roadInfoSO.roadPosition, roadInfoSO.roadRotation);
        }
        else
        {
            _RoadPrefab.transform.position = roadInfoSO.roadPosition;
            _RoadPrefab.transform.rotation = roadInfoSO.roadRotation;
        }
    }
}
