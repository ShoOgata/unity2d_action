
using UnityEngine;


// シングルトン化する継承先のクラスの宣言は以下のようにする
// public class xxxManager : Singleton<xxxManager>

// シングルトン化したクラスへのアクセス方法
// xxxManager.Instance.Func();


public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{

    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                // インスペクターにあるかチェック。ある場合は取得
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    // なければ作成
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    Debug.LogWarning("指定したシングルトンのオブジェクトが見つからなかったので作成" + typeof(T));
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
