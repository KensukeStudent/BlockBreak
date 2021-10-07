using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected abstract bool DontDestroy { get; }

    private static T instance;

    public static T I
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError($"{typeof(T)}のインスタンスが存在しません。");
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if (I != this)
        {
            Destroy(gameObject);
            return;
        }

        if (DontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }

        Init();
    }

    /// <summary>
    /// 派生先用のAwake
    /// </summary>
    protected virtual void Init() { }

    /// <summary>
    /// クラス排除処理
    /// </summary>
    public void Delete()
    {
        if (instance)
        {
            instance = null;
            Destroy(gameObject);
        }
    }
}