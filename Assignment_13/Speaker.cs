using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment_13;
using BusinessLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Represents a single speaker
	/// </summary>
	public class Speaker
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int? Experience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; }
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; }
		public string Employer { get; set; }
		public int RegistrationFee { get; set; }
		public List<BusinessLayer.Session> Sessions { get; set; }

		/// <summary>
		/// Register a speaker
		/// </summary>
		/// <returns>speakerID</returns>
		public int? Register(IRepository repository)
		{
			CheckForNullDetails();
			CheckSpeakerRequirements();

			CalculateRegistrationFee();

			try
			{
				return repository.SaveSpeaker(this);
			}
			catch(Exception ex) 
			{
				throw new RegistrationFailedException("Failed to register speaker.", ex);
			}

			/**
			//lets init some vars
			int? speakerId = null;
			bool good = false;
			bool appr = false;
			//var nt = new List<string> {"MVC4", "Node.js", "CouchDB", "KendoUI", "Dapper", "Angular"};
			var ot = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };

			//DEFECT #5274 DA 12/10/2012
			//We weren't filtering out the prodigy domain so I added it.
			var domains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };

			if (!string.IsNullOrWhiteSpace(FirstName))
			{
				if (!string.IsNullOrWhiteSpace(LastName))
				{


					if (!string.IsNullOrWhiteSpace(Email))
					{
						//put list of employers in array
						var emps = new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };

						//DFCT #838 Jimmy 
						//We're now requiring 3 certifications so I changed the hard coded number. Boy, programming is hard.
						good = ((Exp > 10 || HasBlog || Certifications.Count() > 3 || emps.Contains(Employer)));



						if (!good)
						{
							//need to get just the domain from the email
							string emailDomain = Email.Split('@').Last();

							if (!domains.Contains(emailDomain) && (!(Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9)))
							{
								good = true;
							}
						}

						if (good)
						{
							//DEFECT #5013 CO 1/12/2012
							//We weren't requiring at least one session
							if (Sessions.Count() != 0)
							{
								foreach (var session in Sessions)
								{
									//foreach (var tech in nt)
									//{
									//    if (session.Title.Contains(tech))
									//    {
									//        session.Approved = true;
									//        break;
									//    }
									//}

									foreach (var tech in ot)
									{
										if (session.Title.Contains(tech) || session.Description.Contains(tech))
										{
											session.Approved = false;
											break;
										}
										else
										{
											session.Approved = true;
											appr = true;
										}
									}
								}
							}
							else
							{
								throw new ArgumentException("Can't register speaker with no sessions to present.");
							}

							if (appr)
							{






								//if we got this far, the speaker is approved
								//let's go ahead and register him/her now.
								//First, let's calculate the registration fee. 
								//More experienced speakers pay a lower fee.
								if (Exp <= 1)
								{
									RegistrationFee = 500;
								}
								else if (Exp >= 2 && Exp <= 3)
								{
									RegistrationFee = 250;
								}
								else if (Exp >= 4 && Exp <= 5)
								{
									RegistrationFee = 100;
								}
								else if (Exp >= 6 && Exp <= 9)
								{
									RegistrationFee = 50;
								}
								else
								{
									RegistrationFee = 0;
								}



								//Now, save the speaker and sessions to the db.
								try
								{
									speakerId = repository.SaveSpeaker(this);
								}
								catch (Exception e)
								{
									//in case the db call fails 
								}
							}
							else
							{
								throw new NoSessionsApprovedException("No sessions approved.");
							}
						}
						else
						{
							throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
						}

					}
					else
					{
						throw new ArgumentNullException("Email is required.");
					}
				}
				else
				{
					throw new ArgumentNullException("Last name is required.");
				}
			}
			else
			{
				throw new ArgumentNullException("First Name is required");
			}

			//if we got this far, the speaker is registered.
			return speakerId;
			**/
		}

		private void CheckForNullDetails()
		{
			if(string.IsNullOrWhiteSpace(FirstName))
				throw new ArgumentNullException(nameof(FirstName),"First Name is required.");
			if (string.IsNullOrWhiteSpace(LastName))
				throw new ArgumentNullException(nameof(LastName), "Last name is required.");
			if (string.IsNullOrWhiteSpace(Email))
				throw new ArgumentNullException(nameof(Email), "Email is required.");
		}

		private void CheckSpeakerRequirements()
		{
			if(Experience <= 1 || Experience >= 10 || HasBlog || Certifications.Count > 3 || EmployerIsRecognized())
			{
				if (Sessions == null || Sessions.Count == 0 || !AnySessionApproved())
					throw new RegistrationFailedException("Speaker doesn't meet registration requirements.");
			}
			else
			{
				throw new RegistrationFailedException("Speaker doesn't meet our arbitrary standards.");
			}
		}

		private bool EmployerIsRecognized()
		{
			var recognizedEmployers = new List<string> { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
			return recognizedEmployers.Contains(Employer);
		}

		private bool AnySessionApproved()
		{
			foreach(var session in Sessions)
			{
				var obsoleteTechnologies = new List<string> { "Cobol", "Punch Cards", "Commodore", "VBScript" };
				if (session.Title.ContainsAny(obsoleteTechnologies) || session.Description.ContainsAny(obsoleteTechnologies))
					return false;
			}
			return true;
		}


		private void CalculateRegistrationFee()
		{
			if(Experience <= 1)
			{
				RegistrationFee = 500;
			}
			else if (Experience >= 2 && Experience <= 3)
			{
				RegistrationFee = 250;
			}
			else if(Experience >= 4 && Experience <= 5)
			{
				RegistrationFee = 100;
			}
			else if(Experience >= 6 && Experience <= 9)
			{
				RegistrationFee = 50;
			}
			else
			{
				RegistrationFee = 0;
			}
		}
		/**
		#region Custom Exceptions
		public class SpeakerDoesntMeetRequirementsException : Exception
		{
			public SpeakerDoesntMeetRequirementsException(string message)
				: base(message)
			{
			}

			public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
				: base(string.Format(format, args)) { }
		}

		public class NoSessionsApprovedException : Exception
		{
			public NoSessionsApprovedException(string message)
				: base(message)
			{
			}
		}
		#endregion
		**/
	}
}