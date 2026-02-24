using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _armSystem;
    [SerializeField] private Detector _detector;

    private void OnEnable()
    {
        _detector.HouseLogged += _armSystem.StartChallenge;
        _detector.HouseLeft += _armSystem.StopChallenge;
    }

    private void OnDisable()
    {
        _detector.HouseLogged -= _armSystem.StartChallenge;
        _detector.HouseLeft -= _armSystem.StopChallenge;
    }
}