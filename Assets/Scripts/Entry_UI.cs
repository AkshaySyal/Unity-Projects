using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Entry_UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player_position;
    [SerializeField] TextMeshProUGUI player_name;
    [SerializeField] TextMeshProUGUI player_score;

    public void Initialise(EntryData data)
    {
        player_position.text = data.entrypos.ToString();
        player_score.text = data.entryscore.ToString();
        player_name.text = data.entryname;

    }
}
