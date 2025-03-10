using UnityEngine;

public static class Initializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Execute()
    {
        UnityEngine.Debug.Log("Loaded by the Persist Objects from the Initialzer script");
        Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("PERSISTOBJECTS")));
    }

}
    