using UnityEngine;

public class InformationBetweenScenes : MonoBehaviour
{
    InformationBetweenScenes informationBetweenScenes;
    void Awake()
    {
        if (informationBetweenScenes == null){
            informationBetweenScenes = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
