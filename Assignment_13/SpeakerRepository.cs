using BusinessLayer;

public class SpeakerRepository : IRepository
{
    private List<Speaker> speakers = new List<Speaker>();
    private int nextId = 0;

    public int SaveSpeaker(Speaker speaker)
    {
        nextId++;
        speakers.Add(speaker);
        return nextId;
    }

    // Other methods to retrieve, update, or delete speakers...
}
