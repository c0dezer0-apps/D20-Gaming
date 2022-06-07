using System.ComponentModel.DataAnnotations;
using D20.Data.Entities.Characters;

namespace D20.Data.Entities.Awards
{
    interface IBaseAward
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime DateCreated();
        CharacterAward PresentAward(string reason, Character recipient, Character presenter, Plot plot, Game game);
        GameAward PresentAward(string reason, Game game, Plot plot, GameEvent gameEvent);
    }

    interface ICharacterAward
    {
        string Reason { get; set; }
        Character Recipient { get; set; }
        Character Presenter { get; set; }
        Game Game { get; set; }
        DateTime DateAwarded { get; }
#nullable enable
        Plot? Plot { get; set; }
#nullable disable
    }

    interface ISimAward
    {
        string Reason { get; set; }
        Game Game { get; set; }
        DateTime DateAwarded { get; }
#nullable enable
        Plot? Plot { get; set; }
        GameEvent? Event { get; set; }
#nullable disable
    }

    public class Award : IBaseAward
    {
        private protected readonly DateTime Created;
        private string _name;
        private string _description;

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name should be 5 to 100 characters long.")]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [Required]
        [StringLength(500, MinimumLength = 100, ErrorMessage = "Description should be short but descriptive. 100 - 500 characters.")]
        [MinLength(100)]
        [MaxLength(500)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public Award(string name, string description)
        {
            Name = name;
            Description = description;
            Created = DateTime.Now;
        }

        public DateTime DateCreated()
        {
            return Created;
        }

        public CharacterAward PresentAward(string reason, Character recipient, Character presenter, Plot plot, Game game)
        {
            return new CharacterAward(_name, _description, recipient, presenter, plot, reason, game);
        }

        public GameAward PresentAward(string reason, Game game, Plot plot = null, GameEvent gameEvent = null)
        {
            return new GameAward(_name, _description, reason, game, plot, gameEvent);
        }
    }

    public class CharacterAward : Award, ICharacterAward
    {
        private string _reason;
        private Character _recipient;
        private Character _presenter;
        private Plot _plot;
        private Game _game;

        private readonly DateTime _dateAwarded = DateTime.Now;

        [Required]
        [StringLength(500, MinimumLength = 100, ErrorMessage = "Reason must be 100-500 characters.")]
        [MinLength(100)]
        [MaxLength(500)]
        public string Reason 
        { 
            get
            {
                return _reason;
            }
            set 
            {
                _reason = value;    
            }
        }

        [Required]
        public Character Recipient 
        {
            get 
            {
                return _recipient;
            } 
            set 
            {
                _recipient = value;
            }
        }

        [Required]
        public Character Presenter 
        { 
            get
            {
                return _presenter;
            }
            set
            {
                _presenter = value;
            }
        }

        [Required]
        public DateTime DateAwarded 
        { 
            get
            {
                return _dateAwarded;
            }
        }

        [Required]
        public Plot Plot 
        {
            get
            {
                return _plot;
            }
            set
            {
                _plot = value;
            }
        }

        [Required]
        public Game Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }

        public CharacterAward(string name, string description, Character recipient, Character presenter, Plot plot, string reason, Game game) : base(name, description)
        {
            Reason = reason;
            Recipient = recipient;
            Presenter = presenter;
            Plot = plot;
            Game = game;
        }
    }

    public class GameAward : Award, ISimAward
    {
        private string _reason;
        private Game _game;
#nullable enable
        private Plot? _plot;
        private GameEvent? _event;
#nullable disable
        private readonly DateTime _dateAwarded = DateTime.Now;

        [Required]
        [StringLength(500, MinimumLength = 100, ErrorMessage = "Reason should be between 100 to 500 characters.")]
        [MinLength(100)]
        [MaxLength(500)]
        public string Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value;
            }
        }

        [Required]
        public Game Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }

        [Required]
        public DateTime DateAwarded
        {
            get
            {
                return _dateAwarded;
            }
        }

        public Plot Plot
        {
            get
            {
                return _plot;
            }
            set
            {
                _plot = value;
            }
        }

        public GameEvent Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        public GameAward(string name, string description, string reason, Game game, Plot plot = null, GameEvent gameEvent = null) : base(name, description)
        {
            Reason = reason;
            Game = game;
            Plot = plot;
            Event = gameEvent;
        }
    }
}
