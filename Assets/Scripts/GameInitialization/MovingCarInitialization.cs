using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCarInitialization : MonoBehaviour
{
    List<Transform> _movingCarPrefabTransforms = new List<Transform>();

    [SerializeField]
    private MovingCarInfoSO movingCarInfoSO;

    [SerializeField]
    private PlayerInfoSO playerInfoSO;

    void Start()
    {
        InitializeMovingCars();
    }


    private void InitializeMovingCars()
    {
        if (_movingCarPrefabTransforms.Count == 0)
        {
            for (int carCount = 0; carCount < movingCarInfoSO.carCountToInitialize; carCount++)
            {
                GameObject _MovingCarPrefab = Instantiate(movingCarInfoSO._CarPrefab, playerInfoSO.truckPosition - new Vector3(0, 0, movingCarInfoSO.carDistanceInFront * (carCount+1)), movingCarInfoSO.carRotation);

                Transform _movingCarTransform = _MovingCarPrefab.GetComponent<Transform>();

                _movingCarPrefabTransforms.Add(_movingCarTransform);
            }
        }
        else
        {
            for (int carCount = 0; carCount < _movingCarPrefabTransforms.Count; carCount++)
            {
                _movingCarPrefabTransforms[carCount].position = playerInfoSO.truckPosition - new Vector3(0, 0, movingCarInfoSO.carDistanceInFront * (carCount + 1));
                _movingCarPrefabTransforms[carCount].rotation = movingCarInfoSO.carRotation;
            }
        }

    }

}
