using OppAssignment1;
using OppAssignment3;

namespace OppAssignment2
{
    internal class Cinema1
    {
        private Ticket[] tickets = new Ticket[20];

        // Indexer with validation as required
        public Ticket this[int index]
        {
            get
            {
                if (index >= 0 && index < tickets.Length)
                    return tickets[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < tickets.Length)
                    tickets[index] = value;
                // else do nothing
            }
        }

        public Ticket GetMovieByName(string movieName)
        {
            foreach (var t in tickets)
            {
                if (t != null && t.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return t;
            }
            return null;
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false;
        }
    }


    public class Cinema
    {
        public string CinemaName { get; set; }

        // Composition: Cinema owns the projector
        private Projector _projector;
        private Ticket[] _tickets;
        private int _ticketCount;

        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
            _projector = new Projector(); // Projector created inside the Cinema
            _tickets = new Ticket[20];    // Holds up to 20 tickets
            _ticketCount = 0;
        }

        public void AddTicket(Ticket t)
        {
            if (_ticketCount < _tickets.Length)
            {
                _tickets[_ticketCount] = t;
                _ticketCount++;
            }
            else
            {
                Console.WriteLine("Cinema is full! Cannot add more tickets.");
            }
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("\n========== All Tickets ==========");
            for (int i = 0; i < _ticketCount; i++)
            {
                Console.WriteLine(_tickets[i].ToString());
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("\n========== Cinema Opened ==========");
            _projector.Start();
        }

        public void CloseCinema()
        {
            _projector.Stop();
            Console.WriteLine("========== Cinema Closed ==========\n");
        }
    }

}
