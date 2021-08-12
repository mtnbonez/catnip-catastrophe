using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    // Singleton
    RhythmManager m_Instance;

    public float m_SongBpm;
    public float m_OffsetToFirstBeat;

    // Debug stuff
    public bool m_DebugSongBpmOverlayEnabled;
    public int m_BeatsToDisplay;

    AudioSource m_SongSource;
    float m_SecondsPerBeat;
    float m_SongPositionSeconds;
    float m_SongPositionBeats;
    float m_DspSongTime;

    int m_lastBeat = -1;

    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_SongSource = GetComponent<AudioSource>();

        m_SecondsPerBeat = 60.0f / m_SongBpm;

        m_DspSongTime = (float)AudioSettings.dspTime;

        // We're letting the cat play the music :3
        //m_SongSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        m_SongPositionSeconds = ((float)AudioSettings.dspTime - m_DspSongTime - m_OffsetToFirstBeat);
        m_SongPositionBeats = m_SongPositionSeconds / m_SecondsPerBeat;

        // Count whole numbered beats
        int currentBeatRounded = Mathf.RoundToInt(m_SongPositionBeats);
        float diffToNextBeat = Mathf.Abs(m_SongPositionBeats - currentBeatRounded);
        if (diffToNextBeat < 0.01f && currentBeatRounded > m_lastBeat)
        {
            m_lastBeat = currentBeatRounded;
        }

        if (m_DebugSongBpmOverlayEnabled)
        {
            DrawDebugOverlay();
        }
    }

    void DrawDebugOverlay()
    {
        for (int i = -m_BeatsToDisplay; i < m_BeatsToDisplay; ++i)
        {
            Debug.DrawLine(new Vector3(i * m_SecondsPerBeat * 6.25f, -10, 0), new Vector3(i * m_SecondsPerBeat * 6.25f, 0, 0), Color.red);
        }
    }
}
