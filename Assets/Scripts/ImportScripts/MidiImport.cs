using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;

public class MidiImport : MonoBehaviour
{
    public FallingNotes FN;
    public GameObject Note1, Note2, Note3, Note4, BeatMap;
    public MidiFile importedMidi;
    public string midiName = "test_level.mid";

    // Start is called before the first frame update
    void Start()
    {
        importedMidi = MidiFile.Read(Application.streamingAssetsPath + "/Import/" + midiName);
        BPMFinder();
        Notes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BPMFinder()
    {
        TempoMap miditempo = importedMidi.GetTempoMap();
        Tempo tempo = miditempo.GetTempoAtTime((MidiTimeSpan)1);
        FN = GetComponent<FallingNotes>();
        FN.beatMapTempo = Convert.ToSingle(tempo.BeatsPerMinute);
    }

    void Notes()
    {
        float time;
        short ticksPerQuarterNote;
        TimeDivision timeDivision = importedMidi.TimeDivision;

        if (timeDivision is TicksPerQuarterNoteTimeDivision tpqnTimeDivision)
        {
            ticksPerQuarterNote = tpqnTimeDivision.TicksPerQuarterNote;

            foreach (var note in importedMidi.GetNotes())
            {
                time = note.Time / (float)ticksPerQuarterNote;

                if (note.NoteNumber == 48) // C4
                {
                    Instantiate(Note1, new Vector3(Note1.transform.position.x, transform.position.y + time, transform.position.z), Note1.transform.rotation, BeatMap.transform);
                }
                else if (note.NoteNumber == 49) // C#4
                {
                    Instantiate(Note2, new Vector3(Note2.transform.position.x, transform.position.y + time, transform.position.z), Note2.transform.rotation, BeatMap.transform);
                }
                else if (note.NoteNumber == 50) // D4
                {
                    Instantiate(Note3, new Vector3(Note3.transform.position.x, transform.position.y + time, transform.position.z), Note3.transform.rotation, BeatMap.transform);
                }
                else if (note.NoteNumber == 51) // D#4
                {
                    Instantiate(Note4, new Vector3(Note4.transform.position.x, transform.position.y + time, transform.position.z), Note4.transform.rotation, BeatMap.transform);
                }
            }
        }
        else
        {
            Debug.Log("Error getting time division");
        }
    }
}



        
