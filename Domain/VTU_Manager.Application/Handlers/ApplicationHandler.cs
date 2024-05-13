using MediatR;

namespace VTU_Manager.Application.Handlers
{
    public class ApplicationHandler : IRequestHandler<TestQuery>
    {
        public Task Handle(TestQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public record TestQuery() : IRequest;
}
