using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTriggerInteraction: TriggerInteractionBase
{
    public enum DoorToSpawnAt
    {
        None,
        One, //Forest scene
        Two, //Waterfall scene
        Three, //Success screen
        Four, //Fail screen
    }

    [Header("Spawn To")]
    [SerializeField] private DoorToSpawnAt DoorToSpawnTo; // The target spawn as defined in this door
    [SerializeField] private SceneField _sceneToLoad;        // The scene to load

    [Space(10f)]
    [Header("This Door")]
    public DoorToSpawnAt CurrentDoorPosition;

    public override void Interact()
    {
        //TriggerInteractionBase.Interact()
        SceneSwapManager.SwapSceneFromDoorUse(_sceneToLoad, DoorToSpawnTo); //**Old Method**      
        //SceneSwapManager.instance.SwapSceneFromDoorUse(_sceneToLoad, DoorToSpawnTo);

    }
}
