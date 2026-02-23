using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _fadeSpeed;
    [SerializeField] private Door _door;

    private Coroutine _coroutine;
    private float _volumeMax = 1f;
    private float _volumeMin = 0f;

    private void OnEnable()
    {
        _door.HouseLogged += StartChallenge;
        _door.HouseLeft += StopChallenge;
    }

    private void OnDisable()
    {
        _door.HouseLogged -= StartChallenge;
        _door.HouseLeft -= StopChallenge;
    }

    private void StartChallenge()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(IncreaseVolume());
    }

    private void StopChallenge()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        _source.Play();

        while (_source.volume < 1f)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, _volumeMax, _fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        while (_source.volume > 0f)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, _volumeMin, _fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}