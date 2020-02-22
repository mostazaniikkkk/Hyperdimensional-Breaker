using UnityEngine;

public class Singleton <T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance {get; private set;}
    [SerializeField] private bool _onAwakeDestroyDuplicateGameObject = false;

    protected virtual void Awake(){
        if (Instance != null && Instance != this as T){
            if (_onAwakeDestroyDuplicateGameObject) Destroy(gameObject);
            else enabled = false;

            return;
        }
        Instance = this as T;
    }

    protected virtual void OnDestroy(){
        if (Instance == this as T){
            Instance = null;
        }
    }
}
