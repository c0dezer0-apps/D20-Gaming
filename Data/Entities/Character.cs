using D20.Data.Entities.Awards;

namespace D20.Data.Entities.Characters
{
  interface ICharacter
  {
    string FirstName { get; set; }
    string MiddleName { get; set; }
    string LastName { get; set; }
    string PhysicalDescription { get; set; }
    string Mother { get; set; }
    string Father { get; set; }
    string Children { get; set; }
    string Siblings { get; set; }
    string PersonalityAndTraits { get; set; }
    string WeaknessesAndStrengths { get; set; }
    string Biography { get; set; }
    Employment[] EmploymentHistory { get; set; }
    CharacterAward[] Awards { get; set; }

  }
  /// <summary>
  /// Intended to be a very flexible model. Game Masters decide which values to use.
  /// Validation is intended to be done on on the frontend.
  /// </summary>
  public class Character : ICharacter
  {
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string PhysicalDescription { get; set; }

    public string Mother { get; set; }

    public string Father { get; set; }

    public string Children { get; set; }

    public string Siblings { get; set; }

    public string PersonalityAndTraits { get; set; }

    public string WeaknessesAndStrengths { get; set; }

    public string Biography { get; set; }

    public Employment[] EmploymentHistory { get; set; }

    public CharacterAward[] Awards { get; set; }

    public string GeneralHealth { get; set; }

    public string Injuries { get; set; }

    public string Surgeries { get; set; }

    public string Illnesses { get; set; }

    public string MentalHealth { get; set; }

    public string Modifications { get; set; }

    public string Archetype { get; set; }

    public string PrimaryPosition { get; set; }

    public string SecondaryPosition { get; set; }

    public string Race { get; set; }

    public string Religion { get; set; }

    public string PoliticalAlignment { get; set; }

    public string Gender { get; set; }

    public string Home { get; set; }

    public string Residence { get; set; }

    public string[] Abilities { get; set; }

    public Dictionary<string, int> Skills { get; set; }
    public bool Approved { get; set; }
#nullable enable
    public int? Age { get; set; }
#nullable disable

    public Character()
    {
      FirstName = null;
      MiddleName = null;
      LastName = null;
      PhysicalDescription = null;
      Mother = null;
      Father = null;
      Children = null;
      Siblings = null;
      PersonalityAndTraits = null;
    }

    public Character(string firstName, string middleName, string lastName, string physicalDescription, string mother, string father, string children, string siblings, string personalityAndTraits, string weaknessesAndStrengths, string biography, Employment[] employmentHistory, CharacterAward[] awards, string generalHealth, string injuries, string surgeries, string illnesses, string mentalHealth, string modifications, string archetype, string primaryPosition, string secondaryPosition, string race, string religion, string politicalAlignment, string gender, string home, string residence, string[] abilities, Dictionary<string, int> skills, int age, bool approved)
    {
      FirstName = firstName;
      MiddleName = middleName;
      LastName = lastName;
      PhysicalDescription = physicalDescription;
      Mother = mother;
      Father = father;
      Children = children;
      Siblings = siblings;
      PersonalityAndTraits = personalityAndTraits;
      WeaknessesAndStrengths = weaknessesAndStrengths;
      Biography = biography;
      EmploymentHistory = employmentHistory;
      Awards = awards;
      GeneralHealth = generalHealth;
      Injuries = injuries;
      Surgeries = surgeries;
      Illnesses = illnesses;
      MentalHealth = mentalHealth;
      Modifications = modifications;
      Archetype = archetype;
      PrimaryPosition = primaryPosition;
      SecondaryPosition = secondaryPosition;
      Race = race;
      Religion = religion;
      PoliticalAlignment = politicalAlignment;
      Gender = gender;
      Home = home;
      Residence = residence;
      Abilities = abilities;
      Skills = skills;
      Age = age;
      Approved = approved;
    }
  }
}
