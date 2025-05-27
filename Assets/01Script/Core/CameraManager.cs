using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

namespace DKProject.Core
{
    public class CameraManager : MonoSingleton<CameraManager>
    {
        private CinemachineVirtualCameraBase _currentCamera;
        private CinemachineBasicMultiChannelPerlin _currentMultiChannel;

        private Sequence _shakeSequence;

        private void Start()
        {
            _currentCamera = CinemachineCore.GetVirtualCamera(0);
            _currentMultiChannel = _currentCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void ShakeCamera(float amplitude, float frequency, float time, AnimationCurve curve)
        {
            if (_shakeSequence != null && _shakeSequence.IsActive()) _shakeSequence.Kill();
            _shakeSequence = DOTween.Sequence();

            _shakeSequence
                .Append(
                    DOTween.To(() => amplitude,
                    value => _currentMultiChannel.AmplitudeGain = value,
                    0, time).SetEase(curve))
                .Join(
                    DOTween.To(() => frequency,
                    value => _currentMultiChannel.FrequencyGain = value,
                    0, time).SetEase(curve));
        }
        public void ShakeCamera(float amplitude, float frequency, float time, Ease ease = Ease.Linear)
        {
            if (_shakeSequence != null && _shakeSequence.IsActive()) _shakeSequence.Kill();
            _shakeSequence = DOTween.Sequence();

            _shakeSequence
                .Append(
                    DOTween.To(() => amplitude,
                    value => _currentMultiChannel.AmplitudeGain = value,
                    0, time).SetEase(ease))
                .Join(
                    DOTween.To(() => frequency,
                    value => _currentMultiChannel.FrequencyGain = value,
                    0, time).SetEase(ease));
        }
    }
}
