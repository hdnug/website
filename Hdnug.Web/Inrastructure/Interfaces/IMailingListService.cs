namespace Hdnug.Web.Inrastructure.Interfaces
{
    public interface IMailingListService
    {
        void AddMember(string listname, string email);
        void AddMember(string listname, string firstname, string lastname, string company, string email);
    }
}
