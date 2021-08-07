using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    // Singleton
    RhythmManager m_Instance;

    public float m_SongBpm;
    public float m_OffsetToFirstBeat;
    public bool m_DebugSongBpmOverlayEnabled;

    AudioSource m_SongSource;
    float m_SecondsPerBeat;
    float m_SongPositionSeconds;
    float m_SongPositionBeats;
    float m_DspSongTime;

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

        m_SongSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        m_SongPositionSeconds = ((float)AudioSettings.dspTime - m_DspSongTime - m_OffsetToFirstBeat);
        m_SongPositionBeats = m_SongPositionSeconds / m_SecondsPerBeat;
        // Count whole numbered beats
        Debug.Log("Beat: " + m_SongPositionBeats);
        if (Mathf.Approximately(m_SongPositionBeats, Mathf.RoundToInt(m_SongPositionBeats)))
        {
            Debug.Log("Actual Beat: " + m_SongPositionBeats);
        }

        if (m_DebugSongBpmOverlayEnabled)
        {
            DrawDebugOverlay();
        }
    }

    void DrawDebugOverlay()
    {
        for (int i = 0; i < 128; ++i)
        {
            Debug.DrawLine(new Vector3(i * m_SecondsPerBeat, -10, 0), new Vector3(i * m_SecondsPerBeat, 0, 0), Color.red);
        }
    }
}