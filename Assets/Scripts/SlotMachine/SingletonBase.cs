using UnityEngine;

[DisallowMultipleComponent]
public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("BoolShitSingleton")]
    [SerializeField] private bool doNotDestroyOnLoad;
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this as T;

        if (doNotDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
