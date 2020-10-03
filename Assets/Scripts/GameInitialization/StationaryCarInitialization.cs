using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class StationaryCarInitialization : MonoBehaviour
{
    List<GameObject> _stationaryCarPrefabs = new List<GameObject>();

    [SerializeField]
    private StationaryCarInfoSO stationaryCarInfoSO;

    private GameObject[] _snowObjects;

    void Start()
    {
        GetSnowObjects();

        if (_snowObjects.Length > 0)
        {
            PoolStationaryCars();
            InitializeStationaryCars();
        }
    }


    private void GetSnowObjects()
    {
        _snowObjects = GameObject.FindGameObjectsWithTag("snow");
    }


    private void PoolStationaryCars()
    {
        //creating as many POOLED Stationary Cars as necessary to fill all SnowObjects.
        //For example if there are 3 Snow Objects on the road and the MaxNumberOfCarsPerSnow is 6
        //(which means that each Snow Segment can have maximum 6 cars) then the number of cars
        //instantiated and POOLED equals 18
        int carNumber = _snowObjects.Length * stationaryCarInfoSO.maxNumberOfCarsPerSnow;

        for (int carCount = 0; carCount < carNumber; carCount++)
        {
            GameObject _StationaryCarPrefab = Instantiate(stationaryCarInfoSO._CarPrefab, stationaryCarInfoSO._carPosition, stationaryCarInfoSO._carRotation);
            _StationaryCarPrefab.SetActive(false);
            _stationaryCarPrefabs.Add(_StationaryCarPrefab);
        }

        print($"created {_stationaryCarPrefabs.Count} cars");
    }


    private void HidePooledStationaryCars()
    {
        var carNumber = _stationaryCarPrefabs.Count;

        if (carNumber > 0)
        {
            for (int carCount = 0; carCount < carNumber; carCount++)
            {
                _stationaryCarPrefabs[carCount].SetActive(false);
            }
        }
    }


    private void InitializeStationaryCars()
    {
        if (_stationaryCarPrefabs.Count > 0)
        {

            HidePooledStationaryCars();

            int numbOfCarsOnSnowSegment;
            Vector3 snowSegmentSize;
            Vector3 snowSegmentPosition;
            Vector3 snowSegmentStartPosition;
            Vector3 snowSegmentEndPosition;

            Vector3 carInitializationPosition;

            float abstractDistanceBetweenCars;

            int indexInPooledCarList = 0;

            for (int snowCount = 0; snowCount < _snowObjects.Length; snowCount++)
            {
                snowSegmentSize = _snowObjects[snowCount].GetComponent<Renderer>().bounds.size;
                snowSegmentPosition = _snowObjects[snowCount].transform.position;
                snowSegmentStartPosition = snowSegmentPosition - new Vector3(0, 0, snowSegmentSize.z / 2.2f);
                snowSegmentEndPosition = snowSegmentPosition + new Vector3(0, 0, snowSegmentSize.z / 2.2f);
                numbOfCarsOnSnowSegment = (snowSegmentSize.z / stationaryCarInfoSO.maxNumberOfCarsPerSnow > stationaryCarInfoSO.carDistanceInFront) ? Random.Range(0, stationaryCarInfoSO.maxNumberOfCarsPerSnow + 1) : Random.Range(0, Mathf.FloorToInt(snowSegmentSize.z / stationaryCarInfoSO.carDistanceInFront) + 1);
                abstractDistanceBetweenCars = (snowSegmentEndPosition.z - snowSegmentStartPosition.z) / numbOfCarsOnSnowSegment;
                carInitializationPosition = snowSegmentStartPosition;

                Assert.IsTrue(abstractDistanceBetweenCars > stationaryCarInfoSO.carDistanceInFront);

                for (int carCount = 0; carCount < numbOfCarsOnSnowSegment; carCount++)
                {
                    carInitializationPosition = new Vector3(Random.Range(-snowSegmentSize.x / 2.5f, snowSegmentSize.x / 2.5f), 0, Random.Range(carInitializationPosition.z, carInitializationPosition.z + abstractDistanceBetweenCars));
                    _stationaryCarPrefabs[indexInPooledCarList + carCount].transform.position = carInitializationPosition;
                    _stationaryCarPrefabs[indexInPooledCarList + carCount].SetActive(true);

                    carInitializationPosition += new Vector3(0, 0, stationaryCarInfoSO.carDistanceInFront);
                }

                indexInPooledCarList += numbOfCarsOnSnowSegment;
            }
        }
        else
        {
            print("No Car Prefabs Pooled To Initialize");
        }
        
    }
    
}
