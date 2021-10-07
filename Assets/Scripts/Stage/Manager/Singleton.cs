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
                    Debug.LogError($"{typeof(T)}�̃C���X�^���X�����݂��܂���B");
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
    /// �h����p��Awake
    /// </summary>
    protected virtual void Init() { }

    /// <summary>
    /// �N���X�r������
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