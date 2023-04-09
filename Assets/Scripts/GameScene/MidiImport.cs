using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;

public class MidiImport : MonoBehaviour
{
    public GameObject Beatmap;
    public FallingNotes FN;

    public MidiFile readMidi;
    public string midiName = "test_level.mid";

    // Start is called before the first frame update
    void Start()
    {
        readMidi = MidiFile.Read(Application.streamingAssetsPath + "/Import/" + midiName);
        BPMFinder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BPMFinder()
    {
        TempoMap miditempo = readMidi.GetTempoMap();
        Tempo tempo = miditempo.GetTempoAtTime((MidiTimeSpan)1);
        FN = GetComponent<FallingNotes>();
        FN.beatMapTempo = Convert.ToSingle(tempo.BeatsPerMinute);
    }
}
