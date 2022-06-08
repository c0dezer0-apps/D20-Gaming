using D20.Data.Entities.Characters;
using D20.Data.Forms.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace D20.Data.Entities.Users
{
  interface IUser
  {
    string RealName { get; set; }
    string Username { get; set; }
    string Email { get; set; }
    int Age { get; set; }
    Collection<Character> Characters { get; set; }
    DateTime Created { get; }
    Moderator CreateModerator(string moderatorName);
  }

  public class User : IUser
  {
    private string _realName;
    private string _username;
    private string _email;
    private int _age;
    private Collection<Character> _characters = new();

    private readonly DateTime _created = DateTime.Now;

    [Required]
    [StringLength(1000, ErrorMessage = "Let's not fool our selves. There's no way your character is this long!")]
    [MaxLength(1000)]
    public string RealName
    {
      get
      {
        return _realName;
      }
      set
      {
        _realName = value;
      }
    }

    [Required]
    [Username]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Username must be 5 to 25 characters long.")]
    [MinLength(5)]
    [MaxLength(25)]
    public string Username
    {
      get
      {
        return _username;
      }
      set
      {
        _username = value;
      }
    }

    [Required]
    [EmailAddress]
    public string Email
    {
      get
      {
        return _email;
      }
      set
      {
        _email = value;
      }
    }

    [Required]
    [Range(18, 200, ErrorMessage = "You must be at least 18 to play.")]
    public int Age
    {
      get
      {
        return _age;
      }
      set
      {
        _age = value;
      }
    }

    public Collection<Character> Characters
    {
      get
      {
        return _characters;
      }
      set
      {
        _characters = value;
      }
    }

    public DateTime Created
    {
      get
      {
        return _created;
      }
    }

    public User(string realName, string username, string email, int age)
    {
      RealName = realName;
      Username = username;
      Email = email;
      Age = age;
    }

    public Moderator CreateModerator(string moderatorName)
    {
      return new Moderator(_realName, _username, _email, _age, moderatorName);
    }
  }

  interface IModerator
  {
    string ModeratorName { get; set; }
    Game[] Games { get; set; }
  }

  /// <summary>
  /// A moderator moderates a game in whatever way a game master sees fit. A moderator's identity is separate
  /// from any character they may play, and will not be connected to any characters they have.
  /// </summary>
  public class Moderator : User, IModerator
  {
    private string _moderatorName;
    private Game[] _games;

    [Required]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Name must be 5 to 25 characters.")]
    [MinLength(5)]
    [MaxLength(25)]
    public string ModeratorName
    {
      get
      {
        return _moderatorName;
      }
      set
      {
        _moderatorName = value;
      }
    }

    [Required]
    public Game[] Games
    {
      get
      {
        return _games;
      }
      set
      {
        _games = value;
      }
    }

    public Moderator(string username, string realName, string email, int age, string moderatorName) : base(realName, username, email, age)
    {
      ModeratorName = moderatorName;
    }
  }
}
