// See https://aka.ms/new-console-template for more information
using Assignment_13;
using BusinessLayer;

Console.WriteLine("Hello, World!");
var speaker = new Speaker
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@example.com",
    Experience = 5,
    HasBlog = false,
    BlogURL = "http://johndoe.com",
    Browser = new WebBrowser ("Chrome", 89 ),
    Certifications = new List<string> { "Cert1", "Cert2", "Cert3" },
    Employer = "Micro",
    Sessions = new List<Session>
            {
                new Session ( "Session1", "Description1"),
                new Session ( "Session2", "Description2")
            }
};

var repository = new SpeakerRepository();
/*
try
{
    var speakerId = speaker.Register(repository);
    Console.WriteLine($"Speaker registered with ID: {speakerId}");
}
catch (RegistrationFailedException ex)
{
    Console.WriteLine($"Registration failed: {ex.Message}");
}

*/

var speakerv1 = new Speakerv1
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@aol.com",
    Exp = 5,
    HasBlog = false,
    BlogURL = "http://johndoe.com",
    Browser = new WebBrowser("Chrome", 89),
    Certifications = new List<string> { "Cert1", "Cert2", "Cert3" },
    Employer = "Micro",
    Sessions = new List<Session>
            {
                new Session ( "Session1", "Description1"),
                new Session ( "Session2", "Description2")
            }
};

var repositoryv1 = new SpeakerRepositoryv1();

try
{
    var speakerId = speakerv1.Register(repositoryv1);
    Console.WriteLine($"Speaker registered with ID: {speakerId}");
}
catch (Exception ex)
{
    Console.WriteLine($"Registration failed: {ex.Message}");
}