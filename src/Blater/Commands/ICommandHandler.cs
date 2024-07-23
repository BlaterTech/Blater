using System.Threading.Tasks;

namespace Blater.Commands;

public interface ICommandHandler<in TRequest> where TRequest : BaseCommand
{
    Task Handle(TRequest request);
}