using UnityEngine;

[CreateAssetMenu(fileName = "MovingCarInfoSO", menuName = "ScriptableObjects/MovingCarInfoSO", order = 1)]
public class MovingCarInfoSO : ScriptableObject
{
    public GameObject _CarPrefab;

    public Quaternion carRotation;

    public float carDistanceInFront;

    public int carCountToInitialize;
}