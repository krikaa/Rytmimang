using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;
using Unity.VisualScripting;

public class MidiImport : MonoBehaviour
{
    public FallingNotes FN;
    public GameObject Note1, Note2, Note3, Note4, BeatMap;
    public MidiFile importedMidi;
    public string midiName;

    // Start is called before the first frame update
    void Start()
    {
        importedMidi = MidiFile.Read(Application.streamingAssetsPath + "/Import/" + midiName);  //hangib imporditava midifaili m2ngufailide import kausta ja midifaili nime j2rgi
        BPMFinder();                                                                            
        Notes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BPMFinder()                                                // funktsioon, mis hangib midifailist loo tempo ja lisab m2ngule
    {
        TempoMap miditempo = importedMidi.GetTempoMap();            // v6tab imporditavast midifailist tempo andmed
        Tempo tempo = miditempo.GetTempoAtTime((MidiTimeSpan)1);    // v6tab tempo loo algusest
        FN = GetComponent<FallingNotes>();                          // hangib FallingNotes skripti
        FN.beatMapTempo = Convert.ToSingle(tempo.BeatsPerMinute);   // m22rab scriptis tempoks midifailist saadud tempo
    }

    void Notes()                                                                // funktsioon, mis hangib midifailist nootide asukohad ja lisab objektidena m2ngu
    {
        float time;
        short ticksPerQuarterNote;
        TimeDivision timeDivision = importedMidi.TimeDivision;                  // hangib mitu ticki midifailis l66gi kohta on

        if (timeDivision is TicksPerQuarterNoteTimeDivision tpqnTimeDivision)   
        {
            ticksPerQuarterNote = tpqnTimeDivision.TicksPerQuarterNote;         // muudab ticki ja l66kide suhte sobivasse vormi (tick veerandnoodi kohta)

            foreach (var note in importedMidi.GetNotes())                       // teostab iga noodiga:
            {
                time = note.Time / (float)ticksPerQuarterNote * 2;              // leiab ajahetke millal noot m2ngib, arvestades seejuures tickide arvu ja raja kiirusega

                if (note.NoteNumber == 51)                                                                                                                                          // kui noot on D#4,
                {
                    Instantiate(Note1, new Vector3(Note1.transform.position.x, transform.position.y + time, transform.position.z), Note1.transform.rotation, BeatMap.transform);    // loob uue objekti prefabiga Note1 asukohta, mis x teljes vastab esimesele noodiraja tulbale ja y teljes noodi m2ngimishetkele
                }
                else if (note.NoteNumber == 50)                                                                                                                                     // kui noot on D4,
                {
                    Instantiate(Note2, new Vector3(Note2.transform.position.x, transform.position.y + time, transform.position.z), Note2.transform.rotation, BeatMap.transform);    // loob uue objekti prefabiga Note2 asukohta, mis x teljes vastab teisele noodiraja tulbale ja y teljes noodi m2ngimishetkele
                }
                else if (note.NoteNumber == 49)                                                                                                                                     //kui noot on C#4,
                {
                    Instantiate(Note3, new Vector3(Note3.transform.position.x, transform.position.y + time, transform.position.z), Note3.transform.rotation, BeatMap.transform);    // loob uue objekti prefabiga Note3 asukohta, mis x teljes vastab kolmandale noodiraja tulbale ja y teljes noodi m2ngimishetkele
                }
                else if (note.NoteNumber == 48)                                                                                                                                     // kui noot on C4,
                {
                    Instantiate(Note4, new Vector3(Note4.transform.position.x, transform.position.y + time, transform.position.z), Note4.transform.rotation, BeatMap.transform);    // loob uue objekti prefabiga Note4 asukohta, mis x teljes vastab neljandale noodiraja tulbale ja y teljes noodi m2ngimishetkele
                }
            }
        }
        else
        {
            Debug.Log("Error getting time division");
        }
    }
}



        
