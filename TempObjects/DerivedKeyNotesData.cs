using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace EasyCard.TempObjects
{
    internal class DerivedKeyNotesData
    {

        #pragma warning disable 0649
        public string Id;
        public string name;
        public HideFlags hideFlags;
        public string KeynoteName;
        public string Description;
        public string DescriptionExtended;
        #pragma warning restore 0649

        public static List<KeyNotesData> createKeysNotesDatas(List<DerivedKeyNotesData> dKeyNotes)
        {

            // Check the List //
            if (dKeyNotes == null) return null;

            // Create the KeyNotesDataList //
            List<KeyNotesData> keyNotes = new List<KeyNotesData>();

            // Copy all KeyNotesData //
            foreach (DerivedKeyNotesData dKeyNotesData in dKeyNotes)
            {
                KeyNotesData keyNote = UnityEngine.ScriptableObject.CreateInstance<KeyNotesData>();
                keyNote.id = dKeyNotesData.Id;
                keyNote.name = dKeyNotesData.name;
                keyNote.hideFlags = dKeyNotesData.hideFlags;
                keyNote.keynoteName = dKeyNotesData.KeynoteName;
                keyNote.description = dKeyNotesData.Description;
                keyNote.descriptionExtended = dKeyNotesData.DescriptionExtended;
                keyNotes.Add(keyNote);
            }

            // Return the List //
            return keyNotes;
        }


    }
}
