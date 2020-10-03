using UnityEngine;

[CreateAssetMenu(fileName = "StationaryCarInfoSO", menuName = "ScriptableObjects/StationaryCarInfoSO", order = 1)]
public class StationaryCarInfoSO : ScriptableObject
{
    public GameObject _CarPrefab;

    public float max_Y_rotation;

    public float carDistanceInFront;

    public int maxNumberOfCarsPerSnow;

    public Vector3 _carPosition;

    public Quaternion _carRotation;
}

