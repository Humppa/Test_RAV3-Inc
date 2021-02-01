using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionplayer : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string footstepPath;
    FMOD.Studio.EventInstance eventInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            print("space key was pressed");
            eventInstance = FMODUnity.RuntimeManager.CreateInstance(footstepPath);
            eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        }
    }
}
