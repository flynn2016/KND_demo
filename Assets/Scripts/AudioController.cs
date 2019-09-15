using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private float threatLevelRTPC = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetState("Music_State", "Gameplay");
        AkSoundEngine.SetRTPCValue("AI_ThreatLevel", threatLevelRTPC);
        AkSoundEngine.PostEvent("BackgroundMusic_Event", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        AkSoundEngine.SetRTPCValue("AI_ThreatLevel", threatLevelRTPC);
    }
}
