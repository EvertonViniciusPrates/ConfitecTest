namespace Confitec.Application.Commands.Users
{
    public class RemoveUsuarioCommand : Command
    {
        public int Id { get; set; }

        public RemoveUsuarioCommand(int id) => Id = id;

        public RemoveUsuarioCommand()
        {
        }
    }
}
