using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _fadeSpeed;

    private Coroutine _coroutine;
    private float _volumeMax = 1f;
    private float _volumeMin = 0f;

    public void StartChallenge()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(_volumeMax));
    }

    public void StopChallenge()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(_volumeMin));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _source.Play();

        while (_source.volume != targetVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if(_source.volume == _volumeMin)
        {
            _source.Stop();
        }
    }
}