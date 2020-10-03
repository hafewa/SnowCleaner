using UnityEngine;

[CreateAssetMenu(fileName = "RoadInfoSO", menuName = "ScriptableObjects/RoadInfoSO", order = 1)]
public class RoadInfoSO : ScriptableObject
{

    public GameObject _RoadPrefab;

    public Vector3 roadPosition;

    public Quaternion roadRotation;
}