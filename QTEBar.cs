using UnityEngine;
using UnityEngine.UI;

public class QTEBar : MonoBehaviour
{
    public PlayerController player;
    public Slider qteBar;

    private void Update()
    {
        qteBar.maxValue = player.qteTime;
        qteBar.value = player.currentTime;
    }
}
