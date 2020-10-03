using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialization : MonoBehaviour
{
    private Transform _truckPrefabTransform;

    [SerializeField]
    protected PlayerInfoSO playerInfoSO;


    void Start()
    {
        InitializePlayer();
    }


    private void InitializePlayer()
    {
        if (!_truckPrefabTransform)
        {
            GameObject _TruckPrefab = Instantiate(playerInfoSO._TruckPrefab, playerInfoSO.truckPosition, playerInfoSO.truckRotation);
            _truckPrefabTransform = _TruckPrefab.GetComponent<Transform>();
        }
        else
        {
            _truckPrefabTransform.position = playerInfoSO.truckPosition;
            _truckPrefabTransform.rotation = playerInfoSO.truckRotation;
        }
    }

}
