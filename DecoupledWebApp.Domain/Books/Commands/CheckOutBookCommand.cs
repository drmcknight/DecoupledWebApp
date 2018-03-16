using DecoupledWebApp.Mediation.Commands;

namespace DecoupledWebApp.Domain.Books.Commands
{
    public class CheckOutBookCommand : ICommand
    {
        public CheckOutBookCommand(string userName, string bookTitle)
        {
            UserName = userName;
            BookTitle = bookTitle;
        }

        public string UserName { get; private set; }
        public string BookTitle { get; private set; }
    }
}
