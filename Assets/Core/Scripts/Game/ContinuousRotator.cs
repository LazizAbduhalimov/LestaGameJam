using UnityEngine;

/// <summary>
/// Простая компонента, которая бесконечно вращает объект.
/// Укажите скорость вращения в градусах в секунду по каждой оси.
/// Можно выбрать вращение в локальном или мировом пространстве.
/// </summary>
public class ContinuousRotator : MonoBehaviour
{
    [Tooltip("Скорость вращения в градусах/сек по осям X/Y/Z")]
    [SerializeField]
    private Vector3 _rotationSpeed = new Vector3(0f, 90f, 0f);

    [Tooltip("Если true — вращение в локальном пространстве (transform.Rotate со Space.Self), иначе — Space.World")]
    [SerializeField]
    private bool _useLocalSpace = true;

    [Tooltip("Если true — использовать unscaledDeltaTime (игнорировать паузу/slowmotion)")]
    [SerializeField]
    private bool _useUnscaledTime = false;

    private void Update()
    {
        float dt = _useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        Vector3 delta = _rotationSpeed * dt;
        transform.Rotate(delta, _useLocalSpace ? Space.Self : Space.World);
    }

    /// <summary>
    /// Установить скорость вращения программно (в градусах/сек)
    /// </summary>
    public void SetRotationSpeed(Vector3 degreesPerSecond)
    {
        _rotationSpeed = degreesPerSecond;
    }
}
