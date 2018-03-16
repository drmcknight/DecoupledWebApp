using DecoupledWebApp.Mediation.Commands;

namespace DecoupledWebApp.Domain.Books.Commands
{
    public class ReturnBookCommand : ICommand
    {
        public ReturnBookCommand(int bookID)
        {
            BookID = BookID;
        }
        
        public int BookID { get; private set; }
    }
}
