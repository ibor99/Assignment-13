using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_13
{
    public class SpeakerRepositoryv1
    {
        private List<Speakerv1> speakers = new List<Speakerv1>();
        private int nextId = 0;

        public int SaveSpeaker(Speakerv1 speaker)
        {
            nextId++;
            speakers.Add(speaker);
            return nextId;
        }

        // Other methods to retrieve, update, or delete speakers...
    }
}
