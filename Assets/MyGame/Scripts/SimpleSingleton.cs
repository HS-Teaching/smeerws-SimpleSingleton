/* This is the simplest singleton implementation, but it has some issues:
 * 1) Singleton is not persistent across the Unity scenes.
 * 2) All the executable code must be attached to GameObject in the hierarchy.
 * 3) Whenever we need a class to be a singlton we have to copy the singleton mechanic in Awake().
 */
 using UnityEngine;

public class SimpleSingleton : MonoBehaviour {

    private readonly string Tag = "simpleSingleton";
    private string yourName = "empty";

    public static SimpleSingleton instance;

    public string Name
    {
        get
        {
            Debug.Log(Tag + " get name " + yourName);
            return yourName;
        }

        set
        {
            yourName = value;
            Debug.Log(Tag + " name set to " + yourName);
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Destroy " + Tag + " " + gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Assign this " + Tag + " instance  with name " + gameObject.name);
            instance = this;
        }
    }
}
