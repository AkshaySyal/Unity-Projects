using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBS : MonoBehaviour
{
    // Start is called before the first frame update
    SBsaveData hs = new SBsaveData();
    EntryData data = new EntryData();
    [SerializeField] Transform highscoresHolder;
    [SerializeField] GameObject sbEntry;
    void Start()
    {
        
        DatabaseHandler.GetUsers(users =>
        {
            int i = 0;
            int pos = 1;
            foreach (var user in users)
            {
                if (pos >= 6 || user.Value.score==0)
                {
                    break;
                }

                Debug.Log($"{user.Value.name} {user.Value.score}");
                data.entryname = user.Value.name;
                data.entryscore = user.Value.score;
                data.entrypos = pos;
                hs.highscores.Insert(i,data);
                i++;
                pos++;
            }
            UpdateUI(hs);
        });
    }

    private void UpdateUI(SBsaveData obj)
    {
        foreach (EntryData highscore in obj.highscores)
        {
            Instantiate(sbEntry, highscoresHolder).GetComponent<Entry_UI>().Initialise(highscore);
        }
    }
    
}
